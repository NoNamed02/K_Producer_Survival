using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Button retryButton; // Drag your Retry Button here in the Inspector
    public Button quitButton;  // Drag your Quit Button here in the Inspector

    private void Start()
    {
        Soundmanager.Instance.Sound.Stop();
        // Add listeners to buttons
        if (retryButton != null)
        {
            retryButton.onClick.AddListener(RestartGame);
        }
        else
        {
            Debug.LogError("Retry Button is not assigned.");
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }
        else
        {
            Debug.LogError("Quit Button is not assigned.");
        }
    }

    // Restart the game by reloading the current scene
    private void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Quit the game or return to the main menu
    private void QuitGame()
    {
        // For a standalone build, quit the application
        #if UNITY_STANDALONE
        Application.Quit();
        #elif UNITY_EDITOR
        // For editor, stop playing
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
