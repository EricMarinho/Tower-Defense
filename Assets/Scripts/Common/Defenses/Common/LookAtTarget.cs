using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Defenses
{
    public class LookAtTarget : MonoBehaviour
    {
        private Transform target;
        private Transform initialPos;

        private void Start()
        {
            initialPos = transform;
        }

        private void Update()
        {
            transform.LookAt(target);
        }
        
        public void SetTarget(Transform transform)
        {
            target = transform;
        }
    }

}
