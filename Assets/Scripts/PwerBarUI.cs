using UnityEngine;
using UnityEngine.UI;

public class PowerBarUI : MonoBehaviour
{
    public Slider powerBar;       // Reference to the slider UI
    public float maxPower = 20f;  // Maximum power
    public float chargeRate = 10f; // Speed of power charging
    private float currentPower = 0f;
    private bool isCharging = false;

    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    isCharging = true;
        //    currentPower += chargeRate * Time.deltaTime;
        //    currentPower = Mathf.Clamp(currentPower, 0, maxPower);
        //    powerBar.value = currentPower / maxPower; // Update slider value
        //}

        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    isCharging = false;
        //    currentPower = 0f;
        //    powerBar.value = 0f; // Reset power bar
        //}
    }
}
