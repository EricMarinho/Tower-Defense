using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TowerDefense.Player;

namespace TowerDefense.UI
{
    public class PlayerLifeUIHandler : MonoBehaviour
    {

        [SerializeField] private TMP_Text lifeText;

        #region Singleton
        public static PlayerLifeUIHandler instance;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion

        private void Start()
        {
            lifeText.SetText("Lifes: " + PlayerController.instance.playerData._maxHealth);
        }

        public void DecreaseLifeUI(int playerCurrentHealth)
        {
            lifeText.SetText("Lifes: " + playerCurrentHealth.ToString());
        }

    }
}