using TMPro;
using UnityEngine;
using UnityEngine.UI; // Only needed if you want to show score on screen

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int currentScore = 0;
    public TextMeshProUGUI scoreText; // Optional: assign a UI Text to show score

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keep score across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoint()
    {
        currentScore++;

        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }
}

