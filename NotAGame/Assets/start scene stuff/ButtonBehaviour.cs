using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonMover : MonoBehaviour
{
    public Button startButton;
    public RectTransform buttonRect;
    public string targetSceneName = "fight";
    public float moveInterval = 0.3f;

    private bool isMoving = false; // Baþta hareket yok
    private bool isFirstClick = true; // Ýlk týklamayý takip ediyoruz

    void Start()
    {
        if (startButton == null)
        {
            Debug.LogError("Start Button is not assigned!");
            return;
        }

        buttonRect = startButton.GetComponent<RectTransform>();

        // Týklamaya fonksiyon ekle
        startButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        if (isFirstClick)
        {
            // Ýlk týk: hareket baþlasýn
            isFirstClick = false;
            isMoving = true;
            StartCoroutine(MoveButton());
        }
        else
        {
            // Ýkinci týk: sahneye geç
            isMoving = false;
            SceneManager.LoadScene(targetSceneName);
        }
    }

    IEnumerator MoveButton()
    {
        while (isMoving)
        {
            Vector2 randomPosition = new Vector2(Random.Range(-600f, 600f), Random.Range(-350f, 350f));
            buttonRect.anchoredPosition = randomPosition;

            yield return new WaitForSeconds(moveInterval);
        }
    }
}


