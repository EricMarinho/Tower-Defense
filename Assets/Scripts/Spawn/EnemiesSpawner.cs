using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ObjectPool;
using System;
using TowerDefense.Enemies;

namespace TowerDefense.Spawn
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject spawnPositions;
        [SerializeField] private Transform destinationTransform;
        public WaveData waveData;
        private Transform[] spawnPositionsArray;
        
        private PoolSpawner poolSpawner;
        private string randomEnemy;

        //Timer
        private float spawnTimer = 0f;
        private float spawnRate = 0f;

        #region Singleton
        public static EnemiesSpawner instance;
        private void Awake()
        {
            if (instance != null)
            {
                return;
            }
            instance = this;
        }
        #endregion

        private void Start()
        {
            poolSpawner = GetComponent<PoolSpawner>();
            spawnPositionsArray = spawnPositions.GetComponentsInChildren<Transform>();
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
            GameObject spawnedEnemy = poolSpawner.SpawnFromPool(GetRandomEnemyTag(), GetRandomSpawnPosition().transform.position, Quaternion.identity);
            spawnedEnemy.gameObject.GetComponent<Enemy>().SetTargetDestination(destinationTransform);
        }

        private string GetRandomEnemyTag()
        {
            int randomIndex = UnityEngine.Random.Range(0, waveData._enemyTags.Count);
            randomEnemy = waveData._enemyTags[randomIndex];
            return randomEnemy;
        }

        private float GetRandomTime()
        {
            float randomSpawnRate;
            randomSpawnRate = UnityEngine.Random.Range(waveData._spawnRateMin, waveData._spawnRateMax);
            return randomSpawnRate;
        }

        private Transform GetRandomSpawnPosition()
        {
            return spawnPositionsArray[UnityEngine.Random.Range(1, spawnPositionsArray.Length)];
        }

    }
}