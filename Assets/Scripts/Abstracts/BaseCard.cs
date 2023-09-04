using System;
using Managers.Misc;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers.CardBattleGame
{
    public abstract class BaseCard : ScriptableObject
    {
        [SerializeField] private Sprite _cardMainSprite;

        [SerializeField] private int _level;

        [SerializeField] private CardElementType _elementType;

        public abstract CardType CardType { get; }

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

        public CardElementType ElementType
        {
            get { return _elementType; }
            private set { }
        }
    }
}