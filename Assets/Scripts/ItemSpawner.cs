using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<ItemData> availableItems;
    public ItemDisplayer itemPrefab;
    public static ItemSpawner Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    public void SpawnRandomItem(Vector3 position)
    {
        ItemData selectData = availableItems[UnityEngine.Random.Range(0, availableItems.Count)];
        ItemDisplayer spawnedObject = Instantiate(itemPrefab);
        spawnedObject.transform.position = position;

        spawnedObject.Display(selectData);
    }
}
