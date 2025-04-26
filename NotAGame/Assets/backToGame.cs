using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneButton : MonoBehaviour
{
    public string targetSceneName = "start"; // Scene to load

    void Start()
    {
        Button btn = GetComponent<Button>();

        if (btn == null)
        {
            Debug.LogError("Button component not found on this GameObject!");
            return;
        }

        if (!Application.CanStreamedLevelBeLoaded(targetSceneName))
        {
            Debug.LogError("Scene '" + targetSceneName + "' is not added in Build Settings or name is wrong!");
            return;
        }

        btn.onClick.AddListener(GoToStartScene);
    }

    void GoToStartScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
