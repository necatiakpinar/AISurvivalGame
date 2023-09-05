using System;
using System.Collections.Generic;
using Managers.Misc;
using UnityEngine;

namespace Managers.CardBattleGame
{
    public class CardDeck
    {
        private List<BaseCard> _cards;

        public List<BaseCard> Cards
        {
            get { return _cards; }
            private set { }
        }

        public CardDeck()
        {
            _cards = new List<BaseCard>();
        }

        public void AddCard(BaseCard addedCard)
        {
            //If card exist in the deck, just return
            for (int i = 0; i < _cards.Count; i++)
                if (addedCard.ElementType == _cards[i].ElementType)
                    return;

            _cards.Add(addedCard);
        }

        public void RemoveCard(BaseCard removedCard)
        {
            for (int i = 0; i < _cards.Count; i++)
                if (removedCard.ElementType == _cards[i].ElementType)
                    _cards.Remove(removedCard);
        }

        public BaseCard GetCard(CardElementType elementType)
        {
            for (int i = 0; i < _cards.Count; i++)
                if (_cards[i].ElementType == elementType)
                    return _cards[i];

            Debug.LogError($"{elementType} Card does not exist in the deck!");
            return null;
        }
    }
}