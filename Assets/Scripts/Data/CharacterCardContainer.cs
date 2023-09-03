using System.Collections.Generic;
using Managers.CardBattleGame.Cards;
using UnityEngine;

namespace Managers.Data
{
    [CreateAssetMenu(fileName = "CharacterCardContainer", menuName = "DataContainer/CharacterCardContainer", order = 1)]
    public class CharacterCardContainer : DataContainer
    {
        [SerializeField] private List<CharacterCard> _characterCards;

        public List<CharacterCard> CharacterCards
        {
            get { return _characterCards; }
            private set { }
        }
    }
}