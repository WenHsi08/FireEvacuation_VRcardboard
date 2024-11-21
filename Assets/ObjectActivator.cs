using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public GameObject itemSpawnerObject;  // 包含 ItemSpawner 腳本的物件
    public float activationDelay = 5f;  // 可以在外部修改的啟用延遲時間

    void Start()
    {
        // 確保物件初始為非啟用狀態
        if (itemSpawnerObject != null)
        {
            itemSpawnerObject.SetActive(false);
            StartCoroutine(ActivateObjectAfterDelay(activationDelay));
        }
        else
        {
            Debug.LogError("itemSpawnerObject is not assigned.");
        }
    }

    IEnumerator ActivateObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (itemSpawnerObject != null)
        {
            itemSpawnerObject.SetActive(true);  // 在延遲後啟用物件
            Debug.Log("ItemSpawner object activated.");
        }
    }
}

