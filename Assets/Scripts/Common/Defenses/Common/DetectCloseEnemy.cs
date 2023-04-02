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
            if(other.gameObject.tag == "Enemy")
            {
                followerObject.SetTarget(other.transform);
                followerObject.enabled = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.tag == "Enemy")
            {
                followerObject.enabled = false;
            }
        }
    }
}