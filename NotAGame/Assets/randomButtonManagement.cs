using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class randomButtonManagement : MonoBehaviour
{
    public List<Button> allButtons = new List<Button>(); // Inspector'dan butonlarý atacaksýn
    private Button selectedButton;

    // Start is called before the first frame update
    void Start()
    {
        if (allButtons.Count == 0)
        {
            Debug.LogError("Buton listesi boþ!");
            return;
        }

        // 1 tane random buton seç
        selectedButton = allButtons[Random.Range(0, allButtons.Count)];

        // Seçilen butona sahne deðiþtirme eventini ekle
        selectedButton.onClick.AddListener(GoToFightScene);
    }

    void GoToFightScene()
    {
        SceneManager.LoadScene("Fight");
    }

    // Update is called once per frame
    void Update()
    {
        // Þu an Update içinde bir þey yapmýyorsun, boþ kalabilir
    }
}

