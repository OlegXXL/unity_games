using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject[] trash;
    [SerializeField] private int[] trashCount;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float repeatRate = 1.6f;
    [SerializeField] private GameObject boss;
    void Start()
    {
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
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

        AstarPath.active.Scan();

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
        tempBoss.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();

        // Find the BossIndicator script and call FindBoss
        BossIndicator bossIndicator = FindObjectOfType<BossIndicator>();
        if (bossIndicator != null)
        {
            bossIndicator.FindBoss();
        }
    }
    void SpawnEnemy()
    {
        if (ProgressBarController.progress >= 100) return;
        
        var position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        var tempEnemy = Instantiate(enemy, position, Quaternion.identity);
        tempEnemy.transform.SetParent(transform);
        tempEnemy.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();
    }
}
