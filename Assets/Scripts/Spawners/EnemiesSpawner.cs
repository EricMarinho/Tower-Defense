using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ObjectPool;
using System;

namespace TowerDefense.Spawn
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnerData spawnerData;
        private float spawnTimer = 0f;
        private float spawnRate = 0f;
        private string randomEnemy;
        private PoolSpawner poolSpawner;

        private void Start()
        {
            poolSpawner = ObjectPooler.instance.poolSpawner;
        }

        private void Update()
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnRate)
            {
                spawnRate = GetRandomTime();
                SpawnEnemy();
                spawnTimer = 0;
            }
        }

        private void SpawnEnemy()
        {
            GameObject spawnedEnemy = poolSpawner.SpawnFromPool(GetRandomEnemyTag(), transform.position, Quaternion.identity);
            spawnedEnemy.transform.parent = transform;
        }

        private string GetRandomEnemyTag()
        {
            
            randomEnemy = spawnerData._enemyTags[UnityEngine.Random.Range(0, spawnerData._enemyTags.Count)];
            return randomEnemy;
        }

        private float GetRandomTime()
        {
            float randomSpawnRate;
            randomSpawnRate = UnityEngine.Random.Range(spawnerData._spawnRateMin, spawnerData._spawnRateMax);
            return randomSpawnRate;
        }     

    }
}