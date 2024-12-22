using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    public GameObject gameOverScreen; // Assign your Game Over screen UI element in the Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object that collided is the player
        {
            // Stop the game by pausing the game time
            Time.timeScale = 0f;

            // Enable the Game Over screen UI
            gameOverScreen.SetActive(true);

            // Optional: Reload the scene or go to a different scene after a delay (uncomment to use)
            // Invoke("RestartGame", 2f); // Example of restarting the game after 2 seconds
        }
    }
}
