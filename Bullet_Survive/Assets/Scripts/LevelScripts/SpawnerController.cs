using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject[] trash;
    [SerializeField] private int[] trashCount;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float repeatRate;
    [SerializeField] private GameObject boss;
    void Start()
    {
        Vector3 position;
        GameObject trashForSpawn;
        
        for (int i = 0; i < trash.Length; i++) 
        {
            for (int j = 0; j < trashCount[i]; j++)
            {
                position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
                trashForSpawn = trash[i];
                var tempTrash = Instantiate(trashForSpawn, position, Quaternion.identity);
                tempTrash.transform.SetParent(transform);
            } 
        }

        InvokeRepeating("SpawnEnemy", 0, repeatRate);
    }

    bool isBossSpawned = false;
    void Update()
    {
        if (ProgressBarController.progress >= 100  && !isBossSpawned)
        {
            SpawnBoss();
            isBossSpawned = true;
        }
    }

    void SpawnBoss()
    {
        var position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        var tempBoss = Instantiate(boss, position, Quaternion.identity);
        tempBoss.transform.SetParent(transform); 
    }
    void SpawnEnemy()
    {
        if (ProgressBarController.progress >= 100) return;
        
        var position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        var tempEnemy = Instantiate(enemy, position, Quaternion.identity);
        tempEnemy.transform.SetParent(transform);
    }
}
