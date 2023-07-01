using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject[] enemiesPrefab;
    [SerializeField] GameObject[] bariers;
    [SerializeField] float timeToSpawn = 5f;
    [SerializeField] float timeBetweenSpawning;

    float timeSinceLastSpawn = Mathf.Infinity;

    private void Awake()
    {
        timeBetweenSpawning = timeToSpawn;
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn > timeBetweenSpawning)
        {
            int rndS = Random.Range(0, spawnPoints.Length);
            int rndE = Random.Range(0, enemiesPrefab.Length);
            var enemy = Instantiate(enemiesPrefab[rndE], spawnPoints[rndS].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyBehaviour>().Initialize(bariers[rndS]);

            timeToSpawn -= 0.05f;
            timeBetweenSpawning = timeToSpawn;
            timeSinceLastSpawn = 0f;
        }
    }
}
