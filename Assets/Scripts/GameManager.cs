using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public int Coins; 

        private void Awake()
        {
            instance = this;
            Coins = 0;
        }
    }
}