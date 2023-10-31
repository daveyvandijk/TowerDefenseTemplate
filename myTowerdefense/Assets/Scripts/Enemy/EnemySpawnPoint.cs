using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class EnemySpawnPoint : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemysPrefab;

    [Header("Attributes")]
    [SerializeField] private int BaseEnemies = 8;
    [SerializeField] private float enemiesPerSeconds = 0.5f;
    [SerializeField] private float timeBetweenWave = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;

    

    [SerializeField] private int currentWave = 1;
    [SerializeField] private float timeSincsLastSpawn;
    [SerializeField] private int enemiesAlive;
    [SerializeField] private int enemiesLeftToSpawn;
    [SerializeField] private bool isSpawning = false;

    public void Awake()
    {
        newEnemyHealth.AddonEnemyDestroyTriggerListener(EnemyDestroyed);
        WaypointFollower.AddOnWaypointEndTriggerListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    void Update()
    {
        if (!isSpawning) return;

        timeSincsLastSpawn += Time.deltaTime;

        if (timeSincsLastSpawn >= (1f / enemiesPerSeconds) && enemiesLeftToSpawn > 0 )
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSincsLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
       
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWave);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSincsLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }

    private void SpawnEnemy()
    {
        GameObject preFabToSpawn;

        if(currentWave > 6 )
        {
            preFabToSpawn = enemysPrefab[1];
        }
        else
        {
            preFabToSpawn = enemysPrefab[0];
        }

        Instantiate(preFabToSpawn);
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(BaseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}
