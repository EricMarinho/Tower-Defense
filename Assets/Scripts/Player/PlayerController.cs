using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.ObjectPool;
using TowerDefense.UI;
using UnityEngine;

namespace TowerDefense.Player
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector]
        public PlayerAreaController playerAreaController;
        [HideInInspector]
        public PlayerDamageHandler playerDamageHandler;

        [Header("UI")]
        [SerializeField] private UIHandler UIHandler;

        [Header("Data")]
        public PlayerData playerData;
        public Action OnGameOver;
        public int currentLifes { get; private set; }
        public int currentGold { get; private set; }
        public int currentScore { get; private set; }

        #region Singleton
        public static PlayerController instance { get; private set; }
        private void Awake()
        {
            instance = this;
        }
        #endregion

        private void Start()
        {
            currentLifes = playerData._maxHealth;
            currentGold = playerData._initialGold;
            playerAreaController = GetComponent<PlayerAreaController>();
            playerDamageHandler = GetComponent<PlayerDamageHandler>();
            playerAreaController.OnEnemyHit += DecreaseLife;
        }

        #region Life
        public void DecreaseLife(EnemyData enemyData)
        {
            currentLifes -= enemyData._damage;
            UIHandler.ChangeLifeUI(currentLifes);
            playerDamageHandler.CheckForGameOver(currentLifes);
        }
        #endregion

        #region Gold
        public void IncreaseGold(int gold)
        {
            currentGold += gold;
            UIHandler.ChangeGoldUI(currentGold);
        }

        public void DecreaseGold(int gold)
        {
            currentGold -= gold;
            UIHandler.ChangeGoldUI(currentGold);
        }
        #endregion

        #region Score
        public void IncreaseScore(int score)
        {
            currentScore += score;
            UIHandler.UpdateScore(currentScore);
        }
        #endregion
    }
}