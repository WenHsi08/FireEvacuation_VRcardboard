using UnityEngine;
using UnityEngine.UI; // 或使用 TMPro;
using System.Collections;
using TMPro;  // 確保這行在你的腳本中


public class TimerTrigger : MonoBehaviour
{
    private float entryTime;
    private float exitTime;
    private bool isInside = false;

    public TMP_Text timerResultText; // 顯示時間的文字框

    void Start()
    {
        // 檢查物件是否一開始就在範圍內
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                entryTime = Time.time; // 記錄進入時間
                isInside = true; // 標記為在範圍內
                break; // 找到後跳出迴圈
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInside)
        {
            entryTime = Time.time;
            isInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInside)
        {
            exitTime = Time.time;
            isInside = false;
            float duration = exitTime - entryTime;
            DisplayResult(duration); // 顯示結果
            UpdateScore(duration); // 更新分數
        }
    }

    private void DisplayResult(float duration)
    {
        int minutes = (int)(duration / 60);
        int seconds = (int)(duration % 60);
        timerResultText.text = $"逃生時間: {minutes}分 {seconds}秒"; 
    }

    private void UpdateScore(float duration)
    {
        int scoreToAdd = 0;

        if (duration < 30)
            scoreToAdd = 20;
        else if (duration < 60)
            scoreToAdd = 18;
        else if (duration < 90)
            scoreToAdd = 16;
        else if (duration < 120)
            scoreToAdd = 14;
        else if (duration < 150)
            scoreToAdd = 12;
        else if (duration < 180)
            scoreToAdd = 10;
        else if (duration < 210)
            scoreToAdd = 8;
        else if (duration < 240)
            scoreToAdd = 6;
        else if (duration < 270)
            scoreToAdd = 4;
        else if (duration < 300)
            scoreToAdd = 2;

        // 更新分數
        ScoreManager.Instance.AddScore(scoreToAdd);
    }
}