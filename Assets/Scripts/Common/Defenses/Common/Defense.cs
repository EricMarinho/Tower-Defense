using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ObjectPool;
using System;

namespace TowerDefense.Defenses
{
    public class Defense : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] protected ProjectileData projectileData;
        public DefenseData defenseData;
        
        [SerializeField] protected PoolSpawner poolSpawner;
        [SerializeField] protected Transform shootPoint;

        protected Action defenseAction;

        public int upgradeLevel { get; private set; } = 1;
        private float shootTimer = 0f;

        private void Start()
        {
            shootTimer = defenseData._fireRate -1f;
        }

        private void Update()
        {
            shootTimer += Time.deltaTime;
            if(shootTimer >= defenseData._fireRate)
            {
                defenseAction();
                shootTimer = 0f;
            }
        }

        public void UpgradeDefense()
        {
            upgradeLevel++;
        }
    }
}