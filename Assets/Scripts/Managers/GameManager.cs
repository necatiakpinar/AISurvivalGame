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
    }
}