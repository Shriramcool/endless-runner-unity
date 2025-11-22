using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenSettings()
    {
        Debug.Log("Settings clicked");
    }

    public void ExitGame()
    {
        Debug.Log("Exit clicked");
        Application.Quit();
    }
}
