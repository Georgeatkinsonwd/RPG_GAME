using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public SpawnManager spawnManager;
    public ObjectPool objectPool;

    void Start()
    {
        objectPool.CreatePoolObjects();
        spawnManager.SpawnEnemies();

    }

    void Update()
    {
        if (spawnManager.enemyCount > 5)
        {
            spawnManager.enemyCount = 0;
            spawnManager.RespawnEnemies();
        }

    }
}
