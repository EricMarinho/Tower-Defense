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

        [SerializeField] private PoolSpawner poolSpawner;
        private EnemyData lastEnemyHit;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                lastEnemyHit = other.gameObject.GetComponent<Enemy>().enemyData;
                poolSpawner.ReturnToPool(lastEnemyHit._tag, other.gameObject);
                OnEnemyHit?.Invoke(lastEnemyHit);
            }
        }
    }
}
