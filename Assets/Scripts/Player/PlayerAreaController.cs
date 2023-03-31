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
        private PoolSpawner poolSpawner;
        public Action<EnemyData> OnEnemyHit;
        private EnemyData lastEnemyHit;
        

        private void Start()
        {
            poolSpawner = ObjectPooler.instance.poolSpawner;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                lastEnemyHit = other.gameObject.GetComponent<CommonEnemyController>().enemyData;
                poolSpawner.ReturnToPool(lastEnemyHit._tag, other.gameObject);
                OnEnemyHit?.Invoke(lastEnemyHit);
            }
        }
    }
}
