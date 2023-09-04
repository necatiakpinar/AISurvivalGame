using System.Collections.Generic;
using Managers.CardBattleGame;
using Managers.CardBattleGame.Cards;
using Managers.Misc;
using UnityEngine;

namespace Managers.Data
{
    [CreateAssetMenu(fileName = "ItemCardContainer", menuName = "DataContainer/ItemCardContainer", order = 1)]
    public class ItemCardContainer : DataContainer, IContainer<ItemCard>
    {
        [SerializeField] private List<ItemCard> _itemCards;

        public ItemCard GetCard(CardElementType elementType)
        {
            ItemCard itemCard;
            for (int i = 0; i < _itemCards.Count; i++)
            {
                itemCard = _itemCards[i];
                if (elementType == itemCard.ElementType)
                    return itemCard;
            }

            return null;
        }
    }
}