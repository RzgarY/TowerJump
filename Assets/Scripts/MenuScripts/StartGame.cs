using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private string levelToLoad = "GameScene"; // Replace with your target scene name

    private void Update()
    {
        if (Input.anyKeyDown) // Detects if any key is pressed
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("Game"); // Loads the specified level
    }
}
