using System.Collections;
using System.Collections.Generic;
using TMPro;
using TowerDefense.ObjectPool;
using TowerDefense.Player;
using UnityEngine;

namespace TowerDefense.UI
{
    public class LeaderboardUIHandler : MonoBehaviour
    {
        private List<int> scores;
        private PlayerController playerControllerInstance;
        [SerializeField] private PoolSpawner poolSpawner;

        private void Start()
        {
            playerControllerInstance = PlayerController.instance;
            if (playerControllerInstance.currentScore <= 0)
                return;

            scores = new List<int>();
            for (int i = 0; i < PlayerPrefs.GetInt("PlayerScoreCount"); i++){
                scores.Add(PlayerPrefs.GetInt($"PlayerScore{i}"));
            }

            if (scores.Count >= 10)
            {
                scores.RemoveAt(scores.Count - 1);
            }

            scores.Add(playerControllerInstance.currentScore);

            scores.Sort((s1, s2) => s2.CompareTo(s1));

            for (int i = 0; i < scores.Count; i++)
            {
                GameObject currentScore = poolSpawner.SpawnFromPool("LeaderboardItem", transform.position, Quaternion.identity);
                currentScore.GetComponentsInChildren<TMP_Text>()[0].SetText((i+1).ToString());
                currentScore.GetComponentsInChildren<TMP_Text>()[1].SetText(scores[i].ToString());
                PlayerPrefs.SetInt($"PlayerScore{i}", scores[i]);
            }
            PlayerPrefs.SetInt("PlayerScoreCount", scores.Count);
        }
    }
}