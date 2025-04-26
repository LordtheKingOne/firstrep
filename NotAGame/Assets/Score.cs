using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{   public ScoreManager manager;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = manager.currentScore.ToString();
    }
}
