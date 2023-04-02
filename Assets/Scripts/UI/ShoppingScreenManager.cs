using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TowerDefense.ObjectPool;
using TMPro;
using TowerDefense.Spawn;

namespace TowerDefense.UI
{
    public class ShoppingScreenManager : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Button openShopButton;
        [SerializeField] private Button closeShopButton;
        [SerializeField] private GameObject shopBackground;
        [SerializeField] private PoolSpawner poolSpawner;
        

        [Header("Data")]
        [SerializeField] private ShopData shopData;
        private List<GameObject> shopList;
        private int index;

        [SerializeField] private SpawnDefenseManager spawnDefenseManager;

        private void Start()
        {
            shopList = new List<GameObject>();
            openShopButton.onClick.AddListener(() => {
                OpenShop(shopList);
            });
            closeShopButton.onClick.AddListener(() => {
                CloseShop();
            });
        }

        private void OpenShop(List<GameObject> shopList)
        {
            shopBackground.SetActive(true);
            openShopButton.gameObject.SetActive(false);
            closeShopButton.gameObject.SetActive(true);
            foreach(DefensesData item in shopData._itemDataList)
            {
                shopList.Add(poolSpawner.SpawnFromPool("ShopItem", transform.position, Quaternion.identity));
                shopList[shopList.Count - 1].GetComponentsInChildren<TMP_Text>()[0].text = item._buyPrice.ToString() + " Gold";
                shopList[shopList.Count - 1].GetComponentsInChildren<TMP_Text>()[1].text = item._name;
                shopList[shopList.Count - 1].GetComponent<Button>().onClick.AddListener(() =>
                {
                    spawnDefenseManager.gameObject.SetActive(true);
                    spawnDefenseManager.SetObjectToSpawn(item._name);
                    CloseShop();
                });
            }
        }

        private void CloseShop()
        {
            openShopButton.gameObject.SetActive(true);
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
        }
    }
}
