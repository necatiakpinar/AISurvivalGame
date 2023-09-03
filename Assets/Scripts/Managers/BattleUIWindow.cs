﻿using System;
using Managers.CardBattleGame;
using Managers.CardBattleGame.Cards;
using Managers.Data;
using UnityEngine;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Managers
{
    public class BattleUIWindow : MonoBehaviour
    {

        [SerializeField] private Transform _cardParent;

        private DataManager _dataManager;

        private void Awake()
        {
            _dataManager = DataManager.Instance;
        }

        private void Start()
        {
            //Test
            CharacterCardObject characterCardObject = (CharacterCardObject)CreateCard(CardType.Character);
            CharacterCard characterCardData = _dataManager.CharacterCardContainer.CharacterCards[0];
            characterCardObject.Init(characterCardData);
        }

        public BaseCardObject CreateCard(CardType cardType)
        {
            switch (cardType)
            {
                case CardType.Character:
                    return GameObject.Instantiate(_dataManager.CardContainer.CharacterCardObject, _cardParent);
                    break;
                case CardType.Item:
                    return GameObject.Instantiate(_dataManager.CardContainer.ItemCardPF, _cardParent);
                    break;
            }

            return null;
        }
    }
}