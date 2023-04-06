using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ObjectPool;
using TowerDefense.Enemies;
using System;

namespace TowerDefense.Player
{
    public class PlayerAreaController : MonoBehaviour
    {
        public Action<EnemyData> OnEnemyHit;
        private WaveManager waveManagerIntance;
        [SerializeField] private PoolSpawner poolSpawner;
        private EnemyData lastEnemyHit;

        private void Start()
        {
            waveManagerIntance = WaveManager.instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Ghost"))
            {
                lastEnemyHit = other.gameObject.GetComponent<Enemy>().enemyData;
                poolSpawner.ReturnToPool(lastEnemyHit._tag, other.gameObject);
                OnEnemyHit?.Invoke(lastEnemyHit);
                waveManagerIntance.DecreaseEnemiesRemaining();
            }
        }
    }
}
