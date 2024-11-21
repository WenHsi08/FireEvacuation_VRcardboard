using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;  // 要生成的物品
    public Vector3 spawnPosition = new Vector3(0, 0, 0);  // 生成物品的位置
    public float delayTime = 5f;  // 可以在外部修改的延遲時間

    void Start()
    {
        if (itemPrefab == null)
        {
            Debug.LogError("itemPrefab is not assigned in the Inspector.");
            return;
        }

        Debug.Log("Starting Coroutine with delay: " + delayTime);
        itemPrefab.SetActive(false);  // 在啟動時隱藏物品
        StartCoroutine(SpawnItemAfterDelay(delayTime));  // 使用可修改的延遲時間
    }

    IEnumerator SpawnItemAfterDelay(float delay)
    {
        Debug.Log("Entered Coroutine, waiting for: " + delay + " seconds.");
        yield return new WaitForSeconds(delay);

        Debug.Log("Waited for: " + delay + " seconds, now spawning item.");

        if (itemPrefab != null)
        {
            itemPrefab.SetActive(true);  // 延遲後顯示物品
            Debug.Log("Item spawned after delay.");
        }
        else
        {
            Debug.LogError("itemPrefab was destroyed or is missing.");
        }
    }
}


