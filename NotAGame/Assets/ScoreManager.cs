using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Only needed if you want to show score on screen
using System.Collections;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    

    public int currentScore = 0;
    public int hscore;

    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI hscoreText;

    PlayerMovement2D PlayerMovement2D;
    private void Awake()
    {
        PlayerMovement2D = FindAnyObjectByType<PlayerMovement2D>();
        
    }
    private void Start()
    {
        hscore = PlayerPrefs.GetInt("Highscore");
    }
    public void Update()
    {
        hscoreText.text = hscore.ToString();
        if (currentScore > hscore)
        {
            PlayerPrefs.SetInt("Highscore", currentScore);
        }

        if (PlayerMovement2D == null)
        {     
            SceneManager.LoadScene("fight");
        }
    }
   
      
    
    public void AddPoint()
    {
        currentScore++;

        if (scoreText != null)
        {
            scoreText.text =  currentScore.ToString();
        }
    }
}

