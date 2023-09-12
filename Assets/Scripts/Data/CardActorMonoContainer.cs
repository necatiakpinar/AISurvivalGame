using System;
using System.Collections.Generic;
using Managers.CardBattleGame.Abstract;
using Managers.Misc;
using UnityEngine;

namespace Managers.Data
{
    [Serializable]
    public class CardActorMonoData
    {
        [SerializeField] private CardType _cardType;
        [SerializeField] private BaseCardActorMono _cardActorMono;

        public CardType CardType => _cardType;
        public BaseCardActorMono CardActorMono => _cardActorMono;
    }

    [CreateAssetMenu(fileName = "CardActorMonoController", menuName = "DataContainer/CardActorMonoContainer", order = 2)]
    public class CardActorMonoContainer : DataContainer
    {
        [SerializeField] private List<CardActorMonoData> _cardActorMonoDatas;

        public BaseCardActorMono GetCardActorMono(CardType cardType)
        {
            for (int i = 0; i < _cardActorMonoDatas.Count; i++)
                if (_cardActorMonoDatas[i].CardType == cardType)
                    return _cardActorMonoDatas[i].CardActorMono;

            return null;
        }
    }
}