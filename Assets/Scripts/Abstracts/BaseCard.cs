using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers.CardBattleGame
{
    public abstract class BaseCard : ScriptableObject
    {
        [SerializeField] private Sprite _cardMainSprite;

        [SerializeField] private int _level;

        public Sprite CardMainSprite
        {
            get { return _cardMainSprite; }
            private set { }
        }

        public int Level
        {
            get { return _level; }
            private set { }
        }
    }
}