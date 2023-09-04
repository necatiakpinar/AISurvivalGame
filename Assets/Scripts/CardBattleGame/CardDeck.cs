using System;
using System.Collections.Generic;

namespace Managers.CardBattleGame
{
    public class CardDeck
    {
        private List<BaseCard> _cards;

        public Action<BaseCard> OnCardAdded;

        public CardDeck()
        {
            _cards = new List<BaseCard>();
        }

        public void AddCard(BaseCard addedCard)
        {
            //If card exist in the deck, just return
            if (_cards.Contains(addedCard))
                return;

            _cards.Add(addedCard);
        }

        public void RemoveCard(BaseCard addedCard)
        {
            //If card does not exist in the deck, just return
            if (!_cards.Contains(addedCard))
                return;

            _cards.Remove(addedCard);
        }

        public void GetCard(BaseCard addedCard)
        {
            //If card exist in the deck, just return
            if (_cards.Contains(addedCard))
                return;

            _cards.Add(addedCard);
        }

    }
}