using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TowerDefense.Player
{
    public class PlayerDamageHandler : MonoBehaviour
    {
        private PlayerController playerControllerInstance;
        [SerializeField] private TMP_Text lifeText;
        private int playerCurrentHealth;

        private void Start()
        {
            playerControllerInstance = PlayerController.instance;
            playerControllerInstance.playerAreaController.OnEnemyHit += DecreaseLifeUI;
            playerCurrentHealth = playerControllerInstance.playerData._maxHealth;
        }

        private void DecreaseLifeUI(EnemyData enemyData)
        {
            playerCurrentHealth = playerCurrentHealth - enemyData._damage;
            lifeText.SetText("Lifes: " + playerCurrentHealth.ToString());
        }
    }
}
