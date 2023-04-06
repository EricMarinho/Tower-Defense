using System.Collections;
using System.Collections.Generic;
using TowerDefense.Defenses;
using TowerDefense.ObjectPool;
using UnityEngine;

namespace TowerDefense.Defenses
{
    public class TripleCannonBehaviour : Defense
    {
        private GameObject[] spawnedProjectile = new GameObject[3];

        private void Start()
        {
            defenseAction = Shoot;
        }
        private void Shoot()
        {
            spawnedProjectile[0] = poolSpawner.SpawnFromPool("TripleCannonProjectile", shootPoint.position, shootPoint.rotation * Quaternion.Euler(0, 0, 45));
            spawnedProjectile[1] = poolSpawner.SpawnFromPool("TripleCannonProjectile", shootPoint.position, shootPoint.rotation);
            spawnedProjectile[2] = poolSpawner.SpawnFromPool("TripleCannonProjectile", shootPoint.position, shootPoint.rotation * Quaternion.Euler(0, 0, -45));
            foreach(GameObject projectile in spawnedProjectile)
            {
                projectile.GetComponent<ProjectileController>().SetDamageModifier(upgradeLevel);
                projectile.GetComponent<ProjectileController>().poolSpawner = poolSpawner;
            }
        }
    }
}
