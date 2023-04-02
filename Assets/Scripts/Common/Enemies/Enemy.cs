using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDefense.Enemies
{
    public class Enemy : MonoBehaviour
    {
        public EnemyData enemyData;

        private NavMeshAgent agent;

        private Transform destinationTransform;
        private Vector3 destinationPosition;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            agent.speed = enemyData._speed; 
            destinationPosition = new Vector3(destinationTransform.position.x, transform.position.y, transform.position.z);
        }

        private void Update()
        {
            agent.destination = destinationPosition;
        }

        public void EnmeyKilled()
        {
            //CallWaveManager
        }

        public void TakeDamage() { 
        }

        public void SetTargetDestination(Transform destination)
        {
            destinationTransform = destination;
        }


    }
}
