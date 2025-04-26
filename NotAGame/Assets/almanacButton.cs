using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class almanacButton : MonoBehaviour
{
    public Button almanac; // Drag your button here
    public string targetSceneName = "almanac"; // Scene name to load

    void Start()
    {
        if (almanac == null)
        {
            Debug.LogError("Almanac Button is not assigned!");
            return;
        }

        // When button is clicked, call the GoToAlmanacScene function
        almanac.onClick.AddListener(GoToAlmanacScene);
    }

    void GoToAlmanacScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
