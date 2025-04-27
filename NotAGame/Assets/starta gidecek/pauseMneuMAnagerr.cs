using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Drag your Pause Menu Panel here
    private bool isPaused = false;

    void Start()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false); // Hide at start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        Time.timeScale = 0f; // Freeze the game
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        Time.timeScale = 1f; // Resume the game
        isPaused = false;
    }

    public void ReturnToStartMenu()
    {
        Time.timeScale = 1f; // Make sure game is not frozen
        SceneManager.LoadScene("yenistart"); // Replace "start" with your Start Menu scene name
    }

    public void RestartFightScene()
    {
        Time.timeScale = 1f; // Make sure game is not frozen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads current scene
    }
}

