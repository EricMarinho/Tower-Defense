using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Enemies
{
    public class CommonEnemyController : MonoBehaviour
    {
        public EnemyData enemyData;
        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rb.transform.Translate(Vector3.right * Time.deltaTime * enemyData._speed);
        }

        

    }
}