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

        private BaseCard _cardData;
        private Button _cardButton;
        private bool _isSelected;
        private CardElementType _elementType;

        public BaseCard CardData
        {
            get { return _cardData; }
            private set { }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            private set { }
        }

        public CardElementType ElementType
        {
            get { return _elementType; }
            private set { }
        }

        public virtual void Init(BaseCard cardData)
        {
            _cardData = cardData;
            _elementType = cardData.ElementType;
        }

        private void Awake()
        {
            _cardButton = GetComponent<Button>();
            _cardButton.onClick.AddListener(OnCardClicked);
        }

        protected virtual void OnCardClicked()
        {
            ToggleCardSelection();
            SetSelectionVisual();
        }

        public void ToggleCardSelection()
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

        public void DeSelect()
        {
            _isSelected = false;
            SetSelectionVisual();
        }
    }
}