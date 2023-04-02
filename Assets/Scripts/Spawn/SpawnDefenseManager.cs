using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.ObjectPool;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TowerDefense.Spawn
{
    public class SpawnDefenseManager : MonoBehaviour
    {

        [SerializeField] private PoolSpawner poolSpawner;
     
        private Camera cam = null;

        private string defenseTag = null;
        private Vector3 offsetSpawnPos = new Vector3(0, 0.45f, 0);

        private void Start()
        {
            cam = Camera.main;
        }

        private void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                SpawnAtMousePos();
            }
        }

        private void SpawnAtMousePos()
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.value);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Floor"))
                {
                    GameObject spawn = poolSpawner.SpawnFromPool(defenseTag, hit.point + offsetSpawnPos, Quaternion.identity);
                    gameObject.SetActive(false);
                }
            }
        }

        public void SetObjectToSpawn(string tag)
        {
            defenseTag = tag;
        }
    }
}