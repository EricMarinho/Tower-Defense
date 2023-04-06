using System.Collections;
using System.Collections.Generic;
using TowerDefense.ObjectPool;
using UnityEngine;

namespace TowerDefense.Defenses
{
    public class TurretBehaviour : Defense
    {
        private GameObject spawnedProjectile;

        private void Start()
        {
            defenseAction = Shoot;
        }
        private void Shoot()
        {
            spawnedProjectile = poolSpawner.SpawnFromPool("TurretProjectile", shootPoint.position, shootPoint.rotation);
            spawnedProjectile.GetComponent<ProjectileController>().SetDamageModifier(upgradeLevel);
            spawnedProjectile.GetComponent<ProjectileController>().poolSpawner = poolSpawner;
        }
    }
}
