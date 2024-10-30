using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanelController : MonoBehaviour
{
    public GameObject pausePanel;
    public Button pauseButton;
    public Button resumeButton;
    public Button mainMenuButton;
    public Button restartButton;

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);


        pauseButton.onClick.AddListener(TogglePause);
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        restartButton.onClick.AddListener(RestartGame);
    }

    // This method is called when the Pause Button is clicked
    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {

            pausePanel.SetActive(true); // Show the pause panel, hide the pause button, and pause the game
            pauseButton.gameObject.SetActive(false); // Hide the pause button
            Time.timeScale = 0f;  // Pauses the game
        }
        else
        {
            ResumeGame();  // Resume game if already paused
        }
    }

    // resume the game 
    void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false); // Hide the pause panel
        pauseButton.gameObject.SetActive(true); // Show the pause button again
        Time.timeScale = 1f;         // Resumes the game
    }

    // This method goes back to the main menu
    void GoToMainMenu()
    {
        Time.timeScale = 1f;// running at normal speed
        SceneManager.LoadScene("MainMenu");
    }

    // This method restarts the current level
    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the current scene
    }
}
