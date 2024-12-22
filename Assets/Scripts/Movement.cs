using UnityEngine;
using UnityEngine.UI; // Required if you are using a UI Slider for the power bar

public class Movement : MonoBehaviour
{
    public float maxJumpForce = 20f;  // Maximum jump force
    public float chargeRate = 10f;    // Rate at which jump power charges
    public Transform arrow;           // Reference to the directional arrow
    public GameObject powerBar;       // Reference to the power bar UI
    public GameObject rotationArrow;  // Reference to the rotation arrow UI
    private Rigidbody rb;
    public float rotationSpeed = 100f;

    private bool isGrounded = false;
    private float currentPower = 0f;  // Current jump power
    private bool isAiming = true;     // Is the player in the aiming phase?
    private Vector3 lockedDirection;  // Locked direction for the jump

    private Slider powerBarSlider;

    [Header("Audio")]
    public AudioSource sfx;
    public AudioClip jump, hit;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        if (arrow == null)
        {
            Debug.LogError("Arrow Transform is not assigned!");
        }

        if (powerBar == null || rotationArrow == null)
        {
            Debug.LogError("UI elements (Power Bar or Rotation Arrow) are not assigned!");
        }

        if (powerBar != null)
        {
            powerBarSlider = powerBar.GetComponent<Slider>(); // Get the Slider component if power bar is a slider
        }

        // Initially, show the rotation arrow and power bar
        rotationArrow.SetActive(true);
        powerBar.SetActive(false);
    }

    void Update()
    {
        if (isAiming)
        {
            HandleAiming();
        }
        else
        {
            HandlePowerCharging();
        }
    }

    private void FixedUpdate()
    {

        if (isGrounded)
        {
            rotationArrow.SetActive(true);
        }
        else
        {
            rotationArrow.SetActive(false);
            powerBar.SetActive(false);
        }
    }

    private void HandleAiming()
    {
        // Rotate the arrow while holding the button
        if (Input.GetKey(KeyCode.Space))
        {
            // Rotate around the Z-axis in local space
            arrow.localEulerAngles += new Vector3(0f, 0f, -rotationSpeed * Time.deltaTime); // Negative for clockwise
        }

        // Lock the direction when releasing the button
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Calculate the locked direction based on the arrow's current rotation
            Vector3 direction = new Vector3(
                Mathf.Cos(arrow.localEulerAngles.z * Mathf.Deg2Rad),
                Mathf.Sin(arrow.localEulerAngles.z * Mathf.Deg2Rad),
                0f
            );

            powerBar.SetActive(true);
            rotationArrow.SetActive(false);

            lockedDirection = direction.normalized; // Save the normalized 2D direction
            isAiming = false; // Switch to the power charging phase
        }
    }

    private void HandlePowerCharging()
    {
        // Start charging power
        if (Input.GetKey(KeyCode.Space))
        {
            currentPower += chargeRate * Time.deltaTime;
            currentPower = Mathf.Clamp(currentPower, 0, maxJumpForce); // Clamp power

            // Update the slider value for the power bar if it's assigned
            if (powerBarSlider != null)
            {
                powerBarSlider.value = currentPower / maxJumpForce; // Set slider value based on current power
            }
        }

        // Execute jump when releasing the button
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
            sfx.clip = jump;
            sfx.Play();
        }
    }

    private void Jump()
    {
        // Hide the power bar and rotation arrow when jumping
        powerBar.SetActive(false);
        rotationArrow.SetActive(false);

        // Apply force in the locked direction with the selected power
        rb.AddForce(lockedDirection * currentPower, ForceMode.Impulse);
        currentPower = 0f;  // Reset power

        // Reset the power bar slider if it's used
        if (powerBarSlider != null)
        {
            powerBarSlider.value = 0f; // Reset slider to 0
        }

        isAiming = true;    // Return to aiming phase
    }

    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            sfx.clip = hit;
            sfx.Play();
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            sfx.clip = hit;
            sfx.Play();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}