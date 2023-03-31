using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.ObjectPool;
using UnityEngine;

namespace TowerDefense.Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerAreaController playerAreaController;
        public PlayerData playerData;

        public static PlayerController instance { get; private set; }
        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            playerAreaController = GetComponent<PlayerAreaController>();
        }



    }
}