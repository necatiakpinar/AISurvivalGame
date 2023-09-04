using System.Collections.Generic;
using Managers.CardBattleGame;
using Managers.CardBattleGame.Cards;
using Managers.Misc;
using UnityEngine;

namespace Managers.Data
{
    [CreateAssetMenu(fileName = "CharacterCardContainer", menuName = "DataContainer/CharacterCardContainer", order = 1)]
    public class CharacterCardContainer : DataContainer, IContainer<CharacterCard>
    {
        [SerializeField] private List<CharacterCard> _characterCards;

        public CharacterCard GetCard(CardElementType elementType)
        {
            CharacterCard characterCard;
            for (int i = 0; i < _characterCards.Count; i++)
            {
                characterCard = _characterCards[i];
                if (elementType == characterCard.ElementType)
                    return characterCard;
            }

            return null;
        }
        
    }
}