using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Defenses
{
    public class DetectCloseEnemy : MonoBehaviour
    {

        [SerializeField] private LookAtTarget followerObject;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Ghost")
            {
                followerObject.AddTarget(other.transform);
                followerObject.enabled = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Ghost")
            {
                followerObject.RemoveTarget(other.transform);
            }
        }
    }
}