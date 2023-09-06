using System;
using Managers.Data;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public void Awake()
        {
            Player.InitGameData();
        }

        private void OnApplicationQuit()
        {
            Debug.LogError("Player cleaned up");
            Player.CleanUp();
        }
    }
}