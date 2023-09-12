using System;
using System.Collections.Generic;
using Managers.CardBattleGame;
using Managers.CardBattleGame.Abstract;
using Managers.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class CardMonoManager : MonoBehaviour
    {
        [SerializeField] private List<BaseCardActorMono> _playerDeckCards = new List<BaseCardActorMono>();
        [SerializeField] private Transform _playerDeckParent;

        [Header("Grid placement")] [SerializeField]
        private int _gridWidth;

        [SerializeField] private int _gridHeight;
        [SerializeField] private float _yDistance;
        [SerializeField] private float _xDistance;

        private float _currentXDistance;
        private float _currentYDistance;

        private CardDeck _cardDeck;
        private CardActorMonoContainer _cardActorMonoContainer;

        private List<Vector2> _cardActorPositions = new List<Vector2>();

        private void Awake()
        {
            _cardDeck = Player.CardDeck;
            _cardActorMonoContainer = DataManager.Instance.CardActorMonoContainer;
        }

        private void Start()
        {
            CreatePlayerSelectedDeckCards();
            PlaceCardsToTheGame();
        }

        private void CreatePlayerSelectedDeckCards()
        {
            BaseCard _selectedCard;
            BaseCardActorMono _cardActorMonoPF;
            BaseCardActorMono _cardActorMono;
            for (int i = 0; i < _cardDeck.SelectedCards.Count; i++)
            {
                _selectedCard = _cardDeck.SelectedCards[i];
                _cardActorMonoPF = _cardActorMonoContainer.GetCardActorMono(_selectedCard.CardType);
                _cardActorMono = GameObject.Instantiate(_cardActorMonoPF, _playerDeckParent);
                _playerDeckCards.Add(_cardActorMono);
            }
        }

        private void PlaceCardsToTheGame()
        {
            Vector2 calculatedPosition = Vector2.zero;
            _currentXDistance = 0;
            _currentYDistance = 0;
            for (int y = 0; y < _gridHeight; y++)
            {
                for (int x = 0; x < _gridWidth; x++)
                {
                    calculatedPosition = new Vector2(_currentXDistance, _currentYDistance);
                    _currentXDistance += _xDistance;
                    _cardActorPositions.Add(calculatedPosition);
                }

                _currentXDistance = 0;
                _currentYDistance += _yDistance;
            }

            //Assign card's position from position  
            for (int i = 0; i < _playerDeckCards.Count; i++)
            {
                _playerDeckCards[i].transform.position = _cardActorPositions[i];
            }
        }
    }
}