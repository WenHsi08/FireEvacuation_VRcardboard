using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // 確保這行在你的腳本中

public class QuestionObjectController : MonoBehaviour
{
    public Material InactiveMaterial;
    public Material GazedAtMaterial;
    public GameObject glowingObject; // 指向要發光的物件

    public GameObject questionPanel; // 文字框的 UI 面板
    public TMP_Text questionText; // 題目的文字框

    private Renderer _myRenderer;

    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
        questionPanel.SetActive(false); // 隱藏題目面板
        UpdateScoreText(); // 初始化顯示分數
    }

    public void OnPointerEnter()
    {
        SetMaterial(true);
        glowingObject.SetActive(true); // 顯示發光物件
        ShowQuestion(); // 顯示問題面板
    }

    public void OnPointerExit()
    {
        SetMaterial(false);
        glowingObject.SetActive(false); // 不顯示發光物件
        ClosePanel(); // 隱藏題目面板
    }

    public void OnPointerClick()
    {  
        // 扣除分數
        ScoreManager.Instance.SubtractScore(20);
        UpdateScoreText(); // 更新顯示分數

        // 隱藏物件
        gameObject.SetActive(false);
    }

    private void ShowQuestion()
    {
        questionPanel.SetActive(true); // 顯示題目面板
    }

    private void ClosePanel()
    {
        questionPanel.SetActive(false); // 隱藏題目面板
    }

    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }

    private void UpdateScoreText()
    {
        // 可以從 ScoreManager 中獲取分數，但由於分數會在其他地方更新，所以可以選擇不更新
    }
}