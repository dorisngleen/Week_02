using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TMP_Text scoreText;
    private int score = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Debug.Log("ScoreManager Start, scoreText assigned: " + (scoreText != null));
        UpdateUI();
        Debug.Log("UpdateUI ran, text is now: " + scoreText.text);
    }

    public void AddScore(int amount = 1)
    {
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}