using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.UI;

namespace TowerDefense.Player
{
    public class GameOverHandler : MonoBehaviour
    {

        #region Singleton
        public static GameOverHandler instance;
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

        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private GameObject leaderboardScreen;
        [SerializeField] private GameObject lifesContainer;
        [SerializeField] private GameObject waveContainer;
        

        public void GameOver()
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
            leaderboardScreen.SetActive(true);
            lifesContainer.SetActive(false);
            waveContainer.SetActive(false);
            UIHandler.instance.HideBuyUpgradeButtons();
        }
    }
}
