using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.ObjectPool;
using UnityEngine;
using UnityEngine.InputSystem;
using TowerDefense.UI;
using TowerDefense.Player;

namespace TowerDefense.Spawn
{
    public class SpawnDefenseManager : MonoBehaviour
    {
        [SerializeField] private PoolSpawner poolSpawner;
        [SerializeField] private ShoppingScreenManager shoppingScreenManager;
        private PlayerController playerControllerInstance;
        private int priceToPay;

        private Camera cam = null;

        private string defenseTag = null;
        private Vector3 offsetSpawnPos = new Vector3(0, 0.38f, 0);

        private void Start()
        {
            cam = Camera.main;
            playerControllerInstance = PlayerController.instance;
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
                    playerControllerInstance.DecreaseGold(priceToPay);
                    shoppingScreenManager.EnableShop();
                    gameObject.GetComponent<SpawnDefenseManager>().enabled = false;
                }
            }
        }

        public void SetDefenseToSpawn(string tag)
        {
            defenseTag = tag;
        }
        public void SetDefensePrice(int price)
        {
            priceToPay = price;
        }
    }
}