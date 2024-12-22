using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public Button resumeButton;
    public Button restartButton;
    public Button quitButton;

    private bool isPaused = false;

    void Start()
    {
        // Ensure the pause menu is hidden initially
        pauseMenuUI.SetActive(false);

        // Add listeners for the buttons
        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        // Toggle pause menu with P or Escape key
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f; // Resume game
        isPaused = false;
    }

    public void PauseGame()
    {

        pauseMenuUI.SetActive(true);
        
        Time.timeScale = 0f; // Pause game
        isPaused = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Ensure the game runs normally
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Ensure the game runs normally before quitting
        Application.Quit();
        Debug.Log("Game Quit"); // Debug message for testing in the editor
    }
}
