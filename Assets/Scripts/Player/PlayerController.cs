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
        [SerializeField]
        public PlayerLifeUIHandler playerLifeUIHandlerInstance;

        [Header("Data")]
        public PlayerData playerData;
        public Action OnGameOver;
        public int currentLifes { get; private set; }

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
            playerAreaController = GetComponent<PlayerAreaController>();
            playerDamageHandler = GetComponent<PlayerDamageHandler>();
            playerAreaController.OnEnemyHit += DecreaseLife;
        }

        public void DecreaseLife(EnemyData enemyData)
        {
            currentLifes -= enemyData._damage;
            playerLifeUIHandlerInstance.DecreaseLifeUI(currentLifes);
            playerDamageHandler.CheckForGameOver(currentLifes);
        }

    }
}