using System.Collections;
using System.Collections.Generic;
using TMPro;
using TowerDefense.Player;
using UnityEngine;

namespace TowerDefense.UI
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text lifeText;
        [SerializeField] private TMP_Text goldText;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text waveText;
        [SerializeField] private TMP_Text enemiesText;
        [SerializeField] private GameObject upgradeDefenseButton;
        [SerializeField] private GameObject openShopButton;

        #region Singleton
        public static UIHandler instance { get; private set; }
        private void Awake()
        {
            instance = this;
        }
        #endregion

        private void Start()
        {
            scoreText.SetText("Score: 0"); 
            waveText.SetText("Wave: 1");
            lifeText.SetText("Lifes: " + PlayerController.instance.playerData._maxHealth);
            goldText.SetText("Gold: " + PlayerController.instance.playerData._initialGold);
        }

        public void ChangeGoldUI(int gold)
        {
            goldText.SetText("Gold: " + gold.ToString());
        }

        public void UpdateScore(int score)
        {
            scoreText.SetText("Score: " + score.ToString());
        }
        public void ChangeLifeUI(int playerCurrentHealth)
        {
            lifeText.SetText("Lifes: " + playerCurrentHealth.ToString());
        }

        public void SetWave(int wave)
        {
            waveText.SetText("Wave: " + wave.ToString());
        }
        public void SetEnemiesRemaining(int enemies)
        {
            enemiesText.SetText("Enemies: " + enemies.ToString());
        }
        public void SetBetweenRounds()
        {
            waveText.SetText("Time for the");
        }
        public void SetTimeBetweenRounds(int time)
        {
            enemiesText.SetText("next wave: " + time);
        }

        public void HideBuyUpgradeButtons()
        {
            upgradeDefenseButton.SetActive(false);
            openShopButton.SetActive(false);
        }

        public void ShowBuyUpgradeButtons()
        {
            upgradeDefenseButton.SetActive(true);
            openShopButton.SetActive(true);
        }
    }
}