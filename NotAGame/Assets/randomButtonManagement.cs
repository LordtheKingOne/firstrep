using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class randomButtonManagement : MonoBehaviour
{
    public List<Button> allButtons = new List<Button>(); // Inspector'dan butonlar� atacaks�n
    private Button selectedButton;

    // Start is called before the first frame update
    void Start()
    {
        if (allButtons.Count == 0)
        {
            Debug.LogError("Buton listesi bo�!");
            return;
        }

        // 1 tane random buton se�
        selectedButton = allButtons[Random.Range(0, allButtons.Count)];

        // Se�ilen butona sahne de�i�tirme eventini ekle
        selectedButton.onClick.AddListener(GoToFightScene);
    }

    void GoToFightScene()
    {
        SceneManager.LoadScene("Fight");
    }

    // Update is called once per frame
    void Update()
    {
        // �u an Update i�inde bir �ey yapm�yorsun, bo� kalabilir
    }
}

