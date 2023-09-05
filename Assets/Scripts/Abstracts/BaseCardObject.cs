using System;
using Managers.Misc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.CardBattleGame
{
    public abstract class BaseCardObject : MonoBehaviour
    {
        [SerializeField] private Image _cardImage;
        [SerializeField] private TMP_Text _levelLabel;
        public abstract CardType CardType { get; }

        private Button _cardButton;
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            private set { }
        }

        private CardElementType _elementType;

        public CardElementType ElementType
        {
            get { return _elementType; }
            private set { }
        }

        public virtual void Init(BaseCard cardData)
        {
            _elementType = cardData.ElementType;
        }

        private void Awake()
        {
            _cardButton = GetComponent<Button>();
            _cardButton.onClick.AddListener(OnCardClicked);
        }

        protected virtual void OnCardClicked()
        {
            Debug.LogError("Card clicked!");
            ToggleCardSelection();
            SetSelectionVisual();
        }

        private void ToggleCardSelection()
        {
            if (_isSelected) _isSelected = false;
            else _isSelected = true;
        }

        private void SetSelectionVisual()
        {
            if (_isSelected)
            {
                _cardImage.color = Color.blue;
            }
            else
            {
                _cardImage.color = Color.white;
            }
        }
    }
}