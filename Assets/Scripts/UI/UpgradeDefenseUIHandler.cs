using System.Collections;
using System.Collections.Generic;
using TowerDefense.Defenses;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TowerDefense.Player;

namespace TowerDefense.UI
{
    public class UpgradeDefenseUIHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text currentDefensePromptText;
        [SerializeField] private Button upgradeDefenseButton;
        [SerializeField] private Button cancelUpgradeDefenseButton;
        [SerializeField] private GameObject currentDefensePrompt;
        [SerializeField] private UpgradeDefenseManager upgradeDefenseManager;

        private void Start()
        {
            upgradeDefenseButton.onClick.AddListener(() =>
            {
                StartUpgradeDefense();
            });
            cancelUpgradeDefenseButton.onClick.AddListener(() =>
            {
                FinishUpgradeDefense();
            });
        }

        public void SetCurrentDefenseUI(Defense currentDefense)
        {
            if(currentDefense == null)
            {
                currentDefensePromptText.SetText($"No target selected.\nChose a defense to upgrade or cancel.");
                return;
            }
            if (!upgradeDefenseManager.CheckMaxLevel(currentDefense))
            {
                currentDefensePromptText.SetText(
                    $"Upgrade Level: {currentDefense.upgradeLevel - 1}\n{currentDefense.defenseData._name}: " +
                    $"{currentDefense.defenseData._upgradePrice * currentDefense.upgradeLevel} gold to upgade");
                return;

            }
            currentDefensePromptText.SetText($"Upgrade Level: Max Level\n{currentDefense.defenseData._name}: unable to upgrade anymore");
            
            
        }

        public void StartUpgradeDefense()
        {
            UIHandler.instance.HideBuyUpgradeButtons();
            cancelUpgradeDefenseButton.gameObject.SetActive(true);
            currentDefensePrompt.SetActive(true);
            upgradeDefenseManager.enabled = true;
        }

        public void FinishUpgradeDefense()
        {
            UIHandler.instance.ShowBuyUpgradeButtons();
            cancelUpgradeDefenseButton.gameObject.SetActive(false);
            currentDefensePrompt.SetActive(false);
            upgradeDefenseManager.enabled=false;
        }
        
    }
}