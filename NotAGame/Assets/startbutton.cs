using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class StartButton : MonoBehaviour
{
    public List<Button> allButtons = new List<Button>();

    void Start()
    {
        if (allButtons.Count == 0)
        {
            Debug.LogWarning("Hiç buton atanmadı!");
            return;
        }

        // Bütün butonlara aynı geçiş eventi ekleniyor
        foreach (Button button in allButtons)
        {
            button.onClick.AddListener(GoToFightScene);
        }
    }

    void GoToFightScene()
    {
        SceneManager.LoadScene("fight scene"); // Hangi butona basarsan sahne değişir
    }
}
