using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.UI;

namespace TowerDefense.Player
{
    public class PlayerDamageHandler : MonoBehaviour
    {
        public void CheckForGameOver(int currentHealth)
        {
            if(currentHealth <= 0)
            {
                GameOverHandler.instance.GameOver();
            }
        }
    }
}
