using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject[] trash;
    [SerializeField] private int[] trashCount;
    [SerializeField] private GameObject[] enemies; // An array of enemies to spawn
    [SerializeField] private float[] spawnProbabilities; // The spawn probability for each enemy
    [SerializeField] private float repeatRate = 0.8f;
    [SerializeField] private GameObject boss;
    void Start()
    {
        // Ensure that the arrays are the same length
        if (enemies.Length != spawnProbabilities.Length)
        {
            Debug.LogWarning("The enemies and spawnProbabilities arrays are not the same length. Assigning equal probabilities to all enemies.");
            spawnProbabilities = new float[enemies.Length];
            for (int i = 0; i < spawnProbabilities.Length; i++)
            {
                spawnProbabilities[i] = 100f / enemies.Length;
            }
        }

        // Ensure that the probabilities add up to 100
        float totalProbability = 0f;
        foreach (float prob in spawnProbabilities)
        {
            totalProbability += prob;
        }

        if (totalProbability != 100f)
        {
            Debug.LogWarning("Spawn probabilities do not add up to 100. Assigning equal probabilities to all enemies.");
            for (int i = 0; i < spawnProbabilities.Length; i++)
            {
                spawnProbabilities[i] = 100f / enemies.Length;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            SpawnEnemy();
        }
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

        // Select a random enemy based on the spawn probabilities
        GameObject enemyToSpawn = SelectRandomEnemy();

        var position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        var tempEnemy = Instantiate(enemyToSpawn, position, Quaternion.identity);
        tempEnemy.transform.SetParent(transform);
        tempEnemy.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();
    }

    GameObject SelectRandomEnemy()
    {
        float total = 0;
        foreach (float probability in spawnProbabilities)
        {
            total += probability;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < enemies.Length; i++)
        {
            if (randomPoint < spawnProbabilities[i])
            {
                return enemies[i];
            }
            else
            {
                randomPoint -= spawnProbabilities[i];
            }
        }

        return enemies[enemies.Length - 1]; // If for some reason the selection fails, return the last enemy
    }
}
