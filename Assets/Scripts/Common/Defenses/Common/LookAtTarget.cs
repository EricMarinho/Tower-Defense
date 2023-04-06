using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Defenses
{
    public class LookAtTarget : MonoBehaviour
    {
        private Transform currentTarget;
        private Vector3 lookPosition;
        private List<Transform> targetList = new List<Transform>();

        private void Update()
        {
            if (currentTarget == null) return;
            lookPosition = new Vector3(currentTarget.position.x, transform.position.y, currentTarget.transform.position.z);
            transform.LookAt(lookPosition);
            if (currentTarget.position.y <= 10f)
            {
                targetList.Remove(currentTarget);
            }
        }

        public void AddTarget(Transform transform)
        {
            if(targetList.Count <= 0)
            {
                currentTarget = transform;
            }
            targetList.Add(transform);
        }

        public void RemoveTarget(Transform transform)
        {
            targetList.Remove(transform);
            if(targetList.Count <= 0)
            {
                currentTarget = null;
                return;
            }
            else
            {
                currentTarget = targetList[targetList.Count - 1];
            }
        }

    }

}
