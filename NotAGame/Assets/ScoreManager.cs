using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Only needed if you want to show score on screen
using System.Collections;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public SpriteRenderer sprit;
    public Sprite newspriteee;

    public int currentScore = 0;
    public TextMeshProUGUI scoreText; // Optional: assign a UI Text to show score
    PlayerMovement2D PlayerMovement2D;
    private void Awake()
    {
        PlayerMovement2D = FindAnyObjectByType<PlayerMovement2D>();
        
    }

    public void Update()
    {
        if (PlayerMovement2D == null)
        {   
            sprit.sprite = newspriteee;
            StartCoroutine(MyCoroutine());
            SceneManager.LoadScene("fight");
        }
    }
   
    IEnumerator MyCoroutine(){
    
        yield return new WaitForSeconds(3); // wait for 3 seconds used with unity.collections
        
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

