using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public int enemyCount = 0;


    private float spawnRangeX = 20;
    private float spawnZRange = 20;
    private float numberOfEasyEnemies = 3;
    private float numberOfMediumEnemies = 2;
    private float numberOfHardEnemies = 1;


    public void SpawnEnemies()
    {
        SpawnEasyEnemies();
        SpawnMediumEnemies();
        SpawnHardEnemies();

        ItemSpawner.Instance.SpawnRandomItem(GenerateRandomPosition());

    }

    public void RespawnEnemies()
    {
        enemyCount = 0;
        SpawnEnemies();

    }

    public Vector3 GenerateRandomPosition()
    {


        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(-spawnZRange, spawnZRange);
        Vector3 calculatedPositon = new Vector3(xPos, 1, zPos);

        return calculatedPositon;

    }

    public void SpawnEasyEnemies()
    {
        for (int i = 0; i < numberOfEasyEnemies; i++)
        {
            GameObject easyEnemies = ObjectPool.instance.GetEasyEnemyPooledObjects();

            if (easyEnemies != null)
            {
                Enemy currentEnemy = easyEnemies.GetComponent<Enemy>();

                currentEnemy.spawnManager = this;


                easyEnemies.transform.position = GenerateRandomPosition();
                easyEnemies.SetActive(true);
                currentEnemy.currentHealth = currentEnemy.maxHealth;
                enemyCount = 0;

            }
        }
    }


    public void SpawnMediumEnemies()
    {
        for (int i = 0; i < numberOfMediumEnemies; i++)
        {
            GameObject mediumEnemies = ObjectPool.instance.GetMediumEnemyPooledObjects();

            if (mediumEnemies != null)
            {
                Enemy currentEnemy = mediumEnemies.GetComponent<Enemy>();

                currentEnemy.spawnManager = this;


                mediumEnemies.transform.position = GenerateRandomPosition();
                mediumEnemies.SetActive(true);
                currentEnemy.currentHealth = currentEnemy.maxHealth;
                enemyCount = 0;

            }
        }
    }


    public void SpawnHardEnemies()
    {
        for (int i = 0; i < numberOfHardEnemies; i++)
        {
            GameObject hardEnemies = ObjectPool.instance.GetHardEnemyPooledObjects();

            if (hardEnemies != null)
            {
                Enemy currentEnemy = hardEnemies.GetComponent<Enemy>();

                currentEnemy.spawnManager = this;

                hardEnemies.transform.position = GenerateRandomPosition();
                hardEnemies.SetActive(true);
                currentEnemy.currentHealth = currentEnemy.maxHealth;
                enemyCount = 0;

            }
        }
    }



}
