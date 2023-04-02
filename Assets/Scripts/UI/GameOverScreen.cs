using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TowerDefense.Scene;

public class GameOverScreen : MonoBehaviour
{

    [SerializeField] private Button restartButton;

    private void Start()
    {
        Time.timeScale = 0;
        restartButton.onClick.AddListener(() => {
            Time.timeScale = 1;
            GameSceneManager.instance.RestartGame();
            });
    }
}
