using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<GameObject> easyEnemyPooledObjects = new List<GameObject>();
    public List<GameObject> mediumEnemyPooledObjects = new List<GameObject>();
    public List<GameObject> hardEnemyPooledObjects = new List<GameObject>();
    public int enemiesToPool = 9;

    [SerializeField] private GameObject easyEnemyPrefab;
    [SerializeField] private GameObject mediumEnemyPrefab;
    [SerializeField] private GameObject hardEnemyPrefab;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    public GameObject GetEasyEnemyPooledObjects()
    {
        for (int i = 0; i < easyEnemyPooledObjects.Count; i++)
        {
            if (!easyEnemyPooledObjects[i].activeInHierarchy)
            {
                return easyEnemyPooledObjects[i];
            }
        }
        return null;
    }


    public GameObject GetMediumEnemyPooledObjects()
    {
        for (int i = 0; i < mediumEnemyPooledObjects.Count; i++)
        {
            if (!mediumEnemyPooledObjects[i].activeInHierarchy)
            {
                return mediumEnemyPooledObjects[i];
            }
        }
        return null;
    }

    public GameObject GetHardEnemyPooledObjects()
    {
        for (int i = 0; i < hardEnemyPooledObjects.Count; i++)
        {
            if (!hardEnemyPooledObjects[i].activeInHierarchy)
            {
                return hardEnemyPooledObjects[i];
            }
        }
        return null;
    }

    public void CreatePoolObjects()
    {

        for (int i = 0; i < enemiesToPool; i++)
        {
            GameObject easyEnemy = Instantiate(easyEnemyPrefab);
            GameObject mediumEnemy = Instantiate(mediumEnemyPrefab);
            GameObject hardEnemy = Instantiate(hardEnemyPrefab);
            easyEnemy.SetActive(false);
            mediumEnemy.SetActive(false);
            hardEnemy.SetActive(false);
            easyEnemyPooledObjects.Add(easyEnemy);
            mediumEnemyPooledObjects.Add(mediumEnemy);
            hardEnemyPooledObjects.Add(hardEnemy);
        }
    }
}
