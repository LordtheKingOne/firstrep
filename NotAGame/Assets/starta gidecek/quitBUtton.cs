using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    public Button quitButton; // Assign your button here

    void Start()
    {
        if (quitButton == null)
        {
            Debug.LogError("Quit Button is not assigned!");
            return;
        }

        quitButton.onClick.AddListener(QuitGame);
    }

    void QuitGame()
    {
        Debug.Log("Game is quitting...");

        // If you are running inside the Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If you are running a real build
        Application.Quit();
#endif
    }
}
