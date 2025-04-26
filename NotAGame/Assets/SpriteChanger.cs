using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteChanger : MonoBehaviour
{
    public Sprite[] newSprites; // Sprites to swap into
    public int pointsPerChange = 5; // How often to change
    public ScoreManager scoreManager; // Reference to your score system
    public SpriteRenderer spriteRenderer;

    private int currentIndex = 0;
    private int lastCheckedScore = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        int playerScore = scoreManager.currentScore; // get score from your ScoreManager

        if ((playerScore / pointsPerChange) > (lastCheckedScore / pointsPerChange))
        {
            ChangeSprite();
            lastCheckedScore = playerScore;
        }
    }

    private void ChangeSprite()
    {
        if (newSprites.Length == 0) return;

        spriteRenderer.sprite = newSprites[currentIndex];

        currentIndex++;
        if (currentIndex >= newSprites.Length)
        {
            currentIndex = newSprites.Length - 1; // Stay at the last sprite if we run out
        }
    }
}
