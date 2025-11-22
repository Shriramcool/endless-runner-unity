using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;   // Singleton

    [Header("UI Panels")]
    public GameObject gameOverPanel;
    public GameObject pausePanel;

    public bool isGamePaused = false;

    private void Awake()
    {
        // Create singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // ensure UI panels are hidden
        Time.timeScale = 1f;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

  
    // GAME OVER
   
    public void GameOver()
    {
        Time.timeScale = 0f;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        else
            Debug.LogWarning("GameOver Panel not assigned!");

        Debug.Log("GAME OVER");
    }

    
    // PAUSE
    
    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;

        if (pausePanel != null)
            pausePanel.SetActive(true);
    }

    
    // RESUME
   
    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    
    // RESTART
    
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
