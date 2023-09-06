using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.CardBattleGame
{
    public class SelectedDeckUIController : MonoBehaviour
    {
        [SerializeField] private Transform _deckContainer;
        [SerializeField] private Button _selectButton;

        private CardDeckUIController _cardDeckUIController;
        private List<BaseCardObject> _selectedCards = new List<BaseCardObject>();
        private List<BaseCardObject> _returnedCards = new List<BaseCardObject>();

        public void Init(CardDeckUIController cardDeckUIController)
        {
            SetButtons();
            _cardDeckUIController = cardDeckUIController;
        }
        
        public void AddSelectedCardsToDeck(List<BaseCardObject> selectedCards)
        {
            for (int i = 0; i < selectedCards.Count; i++)
            {
                BaseCardObject cardObject = selectedCards[i];
                cardObject.transform.parent = _deckContainer;
                cardObject.transform.position = Vector3.zero;
                _selectedCards.Add(cardObject);
                EventManager.OnCardAddedToSelectedDeck.Invoke(cardObject);
            }
        }
        
        private void SetButtons()
        {
            _selectButton.onClick.AddListener(DeSelectCards);
        }

        private void DeSelectCards()
        {
            BaseCardObject cardObject;
            for (int i = 0; i < _selectedCards.Count; i++)
            {
                cardObject = _selectedCards[i];
                if (cardObject && cardObject.IsSelected)
                {
                    cardObject.DeSelect();
                    _returnedCards.Add(cardObject);
                    EventManager.OnCardRemovedFromSelectedDeck.Invoke(cardObject);
                }
            }

            RemoveCardsFromDeck();
            
            if (_returnedCards.Count > 0)
                _cardDeckUIController.AddSelectedCardsToDeck(_returnedCards);
            
            _returnedCards.Clear();
        }
        
        private void RemoveCardsFromDeck()
        {
            for (int i = 0; i < _selectedCards.Count; i++)
            {
                if (_selectedCards[i].IsSelected)
                {
                    Debug.LogError(_selectedCards[i].ElementType);
                    _selectedCards.Remove(_selectedCards[i]);
                    i--;
                }
            }
        }

        
        
    }
}