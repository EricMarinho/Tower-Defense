using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TowerDefense.ObjectPool;
using TMPro;
using TowerDefense.Spawn;
using TowerDefense.Player;
using System;

namespace TowerDefense.UI
{
    public class ShoppingScreenManager : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Button openShopButton;
        [SerializeField] private Button closeShopButton;
        [SerializeField] private Button cancelShopButton;
        [SerializeField] private GameObject shopBackground;
        [SerializeField] private GameObject notEnoughMoneyPrompt;
        [SerializeField] private GameObject placeTheDefensePrompt;

        [Header("Data")]
        [SerializeField] private ShopData shopData;
        private List<GameObject> shopList;
        private int index;

        [Header("Spawn")]
        [SerializeField] private PoolSpawner poolSpawner;
        [SerializeField] private SpawnDefenseManager spawnDefenseManager;

        private PlayerController playerControllerInstance;

        private void Start()
        {
            playerControllerInstance = PlayerController.instance;
            shopList = new List<GameObject>();
            openShopButton.onClick.AddListener(() => {
                OpenShop(shopList);
            });
            closeShopButton.onClick.AddListener(() => {
                CloseShop();
            });
            cancelShopButton.onClick.AddListener(() =>
            {
                spawnDefenseManager.enabled= false;
                OpenShop(shopList);
                HidePrompt();
                cancelShopButton.gameObject.SetActive(false);
            });
        }

        private void OpenShop(List<GameObject> shopList)
        {
            shopBackground.SetActive(true);
            UIHandler.instance.HideBuyUpgradeButtons();
            closeShopButton.gameObject.SetActive(true);
            foreach(DefenseData item in shopData._itemDataList)
            {
                shopList.Add(poolSpawner.SpawnFromPool("ShopItem", transform.position, Quaternion.identity));
                TMP_Text[] textComponents = shopList[shopList.Count - 1].GetComponentsInChildren<TMP_Text>();
                textComponents[0].SetText(item._buyPrice.ToString() + " Gold");
                textComponents[1].SetText(item._name);
                shopList[shopList.Count - 1].GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (playerControllerInstance.currentGold < item._buyPrice)
                    {
                        StartCoroutine(ShowNotEnoughMoney());
                    }
                    else
                    {
                        spawnDefenseManager.enabled = true;
                        placeTheDefensePrompt.gameObject.SetActive(true);
                        spawnDefenseManager.SetDefenseToSpawn(item._name);
                        spawnDefenseManager.SetDefensePrice(item._buyPrice);
                        CloseShop(false);
                    }
                    
                });
            }
        }

        private void CloseShop(bool isCloseShop = true)
        {
            closeShopButton.gameObject.SetActive(false);
            shopBackground.SetActive(false);
            //Maybe it would be better to use Queue
            index = 0;
            foreach(GameObject item in shopList)
            {
                poolSpawner.ReturnToPool("ShopItem", shopList[index]);
                index++;
            }
            shopList.Clear();
            if (isCloseShop)
            {
                UIHandler.instance.ShowBuyUpgradeButtons();
                return;
            }
            cancelShopButton.gameObject.SetActive(true);
        }

        public void HidePrompt()
        {
            placeTheDefensePrompt.gameObject.SetActive(false);
        }

        public void EnableShop()
        {
            cancelShopButton.gameObject.SetActive(false);
            HidePrompt();
            UIHandler.instance.ShowBuyUpgradeButtons();
        }

        private IEnumerator ShowNotEnoughMoney()
        {
            notEnoughMoneyPrompt.SetActive(true);
            yield return new WaitForSeconds(2f);
            notEnoughMoneyPrompt.SetActive(false);
        }
    }
}
