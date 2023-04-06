using System.Collections;
using System.Collections.Generic;
using TowerDefense.Enemies;
using TowerDefense.ObjectPool;
using UnityEngine;

namespace TowerDefense.Defenses
{
    public class ProjectileController : MonoBehaviour
    {
        [SerializeField] private ProjectileData projectileData;
        public PoolSpawner poolSpawner;

        private int damageModifier = 1;

        private void Update()
        {
            transform.Translate(Vector3.up * projectileData._speed * Time.deltaTime);
        }

        public void SetDamageModifier(int modifier)
        {
            damageModifier = modifier;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                HitEnemy(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Ghost"))
            {
                if (!other.gameObject.GetComponent<BlueEnemyController>().isHittable) {
                    return;
                }
                HitEnemy(other.gameObject);
            }
            poolSpawner.ReturnToPool(projectileData._tag, gameObject);
        }

        private void HitEnemy(GameObject enemy)
        {
            enemy.GetComponent<Enemy>().TakeDamage(projectileData._damage * damageModifier);
        }

    }
}