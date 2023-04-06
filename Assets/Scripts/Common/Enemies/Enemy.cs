using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TowerDefense.ObjectPool;
using TowerDefense.Player;

namespace TowerDefense.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private NavMeshAgent agent;
        private PoolSpawner poolSpawner;
        private WaveManager waveManagerIntance;
        private PlayerController playerControllerInstance;

        public EnemyData enemyData;
        private Transform destinationTransform;
        private Vector3 destinationPosition;
        private int currentHealth;
        private float spawnedPosition;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            spawnedPosition= transform.position.x;
            waveManagerIntance = WaveManager.instance; 
            playerControllerInstance = PlayerController.instance;
            agent.speed = enemyData._speed; 
            currentHealth = enemyData._health;
            destinationPosition = new Vector3(destinationTransform.position.x, transform.position.y, transform.position.z);
        }

        private void Update()
        {
            agent.destination = destinationPosition;
        }

        public void EnmeyKilled()
        {
            transform.position = new Vector3(spawnedPosition,transform.position.y, transform.position.z);
            playerControllerInstance.IncreaseGold(enemyData._goldReward);
            playerControllerInstance.IncreaseScore(enemyData._scoreReward);
            waveManagerIntance.DecreaseEnemiesRemaining();
            poolSpawner.ReturnToPool(enemyData._tag, gameObject);
        }

        public void TakeDamage(int damage) {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                EnmeyKilled();
            }
        }

        public void SetTargetDestination(Transform destination)
        {
            destinationTransform = destination;
        }

        public void SetPoolSpawner(PoolSpawner poolSpawner)
        {
            this.poolSpawner = poolSpawner;
        }

    }
}
