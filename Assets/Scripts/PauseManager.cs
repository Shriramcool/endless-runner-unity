using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("UI Buttons")]
    public GameObject pauseButton;
    public GameObject resumeButton;

    private bool isPaused = false;

    public void PauseGame()
    {
        if (isPaused) return;

        isPaused = true;
        Time.timeScale = 0f;

        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
    }

    public void ResumeGame()
    {
        if (!isPaused) return;

        isPaused = false;
        Time.timeScale = 1f;

        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
    }
}
