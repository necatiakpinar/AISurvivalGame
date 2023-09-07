using System.Collections.Generic;
using Managers.Data;
using Managers.Misc;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.CardBattleGame
{
    public class CardDeckUIController : MonoBehaviour
    {
        [SerializeField] private Transform _deckContainer;
        [SerializeField] private Button _selectButton;

        private List<BaseCardObject> _playerDeckCards = new List<BaseCardObject>();
        private List<BaseCardObject> _selectedCards = new List<BaseCardObject>();

        private CardDeck _playerCardDeck;
        private DataManager _dataManager;
        private SelectedDeckUIController _selectedDeckController;

        public void Init(SelectedDeckUIController selectedDeckController)
        {
            if (_deckContainer == null)
                return;

            _playerCardDeck = Player.CardDeck;
            _dataManager = DataManager.Instance;
            _selectedDeckController = selectedDeckController;

            SetButtons();
            CreateDeck();

            int childCount = _deckContainer.childCount;
            BaseCardObject baseCardObject;
            for (int i = 0; i < childCount; i++)
            {
                Transform child = _deckContainer.GetChild(i);
                baseCardObject = child.GetComponent<BaseCardObject>();
                _playerDeckCards.Add(baseCardObject);
            }

            Debug.LogError(_playerDeckCards.Count);
        }

        private void SetButtons()
        {
            _selectButton.onClick.AddListener(SelectCards);
        }

        private void CreateDeck()
        {
            if (_playerCardDeck.Cards.Count == 0)
                return;

            BaseCard baseCard;
            for (int i = 0; i < _playerCardDeck.Cards.Count; i++)
            {
                baseCard = _playerCardDeck.Cards[i];

                //Create card UI
                CharacterCardObject characterCardObject = _dataManager.CreateCard<CharacterCardObject>(CardType.Character, _deckContainer);
                characterCardObject.Init(baseCard);
            }
        }

        private void SelectCards()
        {
            BaseCardObject cardObject;

            for (int i = 0; i < _playerDeckCards.Count; i++)
            {
                cardObject = _playerDeckCards[i];
                if (cardObject && cardObject.IsSelected)
                {
                    _selectedCards.Add(cardObject);
                }
            }

            RemoveCardsFromDeck();

            if (_selectedCards.Count > 0)
                _selectedDeckController.AddSelectedCardsToDeck(_selectedCards);

            _selectedCards.Clear();
        }

        public void AddSelectedCardsToDeck(List<BaseCardObject> selectedCards)
        {
            for (int i = 0; i < selectedCards.Count; i++)
            {
                BaseCardObject cardObject = selectedCards[i];
                cardObject.transform.parent = _deckContainer;
                cardObject.transform.position = Vector3.zero;
                _playerDeckCards.Add(cardObject);
                EventManager.OnCardRemovedFromSelectedDeck.Invoke(cardObject);
            }
        }

        private void RemoveCardsFromDeck()
        {
            BaseCardObject cardObject;
            for (int i = 0; i < _selectedCards.Count; i++)
            {
                cardObject = _selectedCards[i];
                if (cardObject.IsSelected)
                {
                    cardObject.DeSelect();
                    _playerDeckCards.Remove(cardObject);
                }
            }
        }
    }
}