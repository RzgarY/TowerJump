using UnityEngine;

public class TriggerMoveUp : MonoBehaviour
{
    public float moveUpDistance = 2f; // Total distance to move up each trigger
    public float moveSpeed = 1f; // Speed of upward movement

    private bool shouldMove = false; // Whether the object should move

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Start moving upwards continuously
            shouldMove = true;
        }
    }

    private void Update()
    {
        // Continuously move the object upward if it should move
        if (shouldMove)
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }
}
