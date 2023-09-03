using System.Collections.Generic;
using Managers.CardBattleGame.Cards;
using UnityEngine;

namespace Managers.Data
{
    [CreateAssetMenu(fileName = "ItemCardContainer", menuName = "DataContainer/ItemCardContainer", order = 1)]
    public class ItemCardContainer : DataContainer
    {
        [SerializeField] private List<ItemCard> _itemCards;

        public List<ItemCard> ItemCards
        {
            get { return _itemCards; }
            private set { }
        }
    }
}