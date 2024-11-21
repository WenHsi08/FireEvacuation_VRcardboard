using UnityEngine;

public class VoiceTrigger : MonoBehaviour
{
    public AudioClip voiceClip; // 拖入語音剪輯
    private AudioSource audioSource;
    private bool hasPlayed = false; // 標誌變量

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = voiceClip;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed) // 確保角色有"Player"標籤且未播放
        {
            audioSource.Play(); // 播放語音
            hasPlayed = true; // 設置標誌為已播放
        }
    }

    // 如果你希望重新觸發，可以在此處添加重置邏輯
    public void ResetTrigger()
    {
        hasPlayed = false; // 重置標誌
    }
}