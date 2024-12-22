using UnityEngine;

public class RandomLaunchPlayer : MonoBehaviour
{
    [SerializeField] private float launchForce = 15f; // Adjust the strength of the launch
    [SerializeField] private bool constrainVertical = true; // Option to constrain the vertical direction

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                // Generate a random direction
                Vector3 randomDirection = new Vector3(
                    Random.Range(-1f, 1f),
                    constrainVertical ? Random.Range(0.5f, 1f) : Random.Range(-1f, 1f),
                    Random.Range(-1f, 1f)
                ).normalized;

                // Apply the launch force based on the random direction
                playerRigidbody.velocity = Vector3.zero; // Reset velocity for consistent launch
                playerRigidbody.AddForce(randomDirection * launchForce, ForceMode.VelocityChange);
            }
        }
    }
}
