using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton 實例
    public TMP_Text scoreText; // 用於顯示分數的 UI 元件

    private int score = 80; // 初始分數

    private void Awake()
    {
        // 確保只有一個 ScoreManager 存在
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 使其在場景間持久
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void SubtractScore(int amount)
    {
        score -= amount;
        UpdateScoreText();
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "分數: " + score; // 更新分數顯示
        }
    }
}