using System.Collections;
using System.Collections.Generic;
using TowerDefense.ObjectPool;
using TowerDefense.Player;
using TowerDefense.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TowerDefense.Defenses
{
    public class UpgradeDefenseManager : MonoBehaviour
    {
        private Camera cam = null;
        private Defense currentDefense;
        [SerializeField] private UpgradeDefenseUIHandler upgradeDefenseUIHandler;
        private PlayerController playerControllerInstance;

        private void Start()
        {
            cam = Camera.main;
            playerControllerInstance = PlayerController.instance;
        }

        private void Update()
        {           
            UpgradeAtMousePos();
        }

        private void UpgradeAtMousePos()
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.value);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Defense"))
                {
                    currentDefense = hit.collider.gameObject.GetComponentInParent<Defense>();
                    upgradeDefenseUIHandler.SetCurrentDefenseUI(currentDefense);

                    if ((Mouse.current.leftButton.wasPressedThisFrame) && (CheckEnoughGold(currentDefense)) && (CheckEnoughGold(currentDefense)))
                    {
                        playerControllerInstance.DecreaseGold(currentDefense.defenseData._upgradePrice * currentDefense.upgradeLevel);
                        currentDefense.UpgradeDefense();
                        upgradeDefenseUIHandler.FinishUpgradeDefense();
                    }
                }
                else
                {
                    upgradeDefenseUIHandler.SetCurrentDefenseUI(null);
                }
            }
        }

        public bool CheckMaxLevel(Defense currentDefense)
        {
            return currentDefense.upgradeLevel > currentDefense.defenseData._maxUpgradeLevel;
        }
        public bool CheckEnoughGold(Defense currentDefense)
        {
            return playerControllerInstance.currentGold >= currentDefense.defenseData._upgradePrice * currentDefense.upgradeLevel;
        }
    }
}