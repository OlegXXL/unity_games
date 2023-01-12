using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject[] trash;
    [SerializeField] private int[] trashCount;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float repeatRate;
    void Start()
    {
        Vector3 position;
        GameObject tempForSpawn;
        
        for (int i = 0; i < trash.Length; i++) 
        {
            for (int j = 0; j < trashCount[i]; j++)
            {
                position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
                tempForSpawn = trash[i];
                Instantiate(tempForSpawn, position, Quaternion.identity);
                tempForSpawn.transform.SetParent(transform);
            } 
        }

        InvokeRepeating("SpawnEnemy", 0, repeatRate);
    }

    void SpawnEnemy()
    {
        if (ProgressBarController.progress >= 100) return;
        
        var position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        var tempEnemy = Instantiate(enemy, position, Quaternion.identity);
        tempEnemy.transform.SetParent(transform);
    }
}
