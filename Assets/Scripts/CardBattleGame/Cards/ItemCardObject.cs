using Managers.CardBattleGame.Cards;
using TMPro;
using UnityEngine;

namespace Managers.CardBattleGame
{
    public class ItemCardObject : BaseCardObject
    {
        [SerializeField] private TMP_Text _itemLabel;

        public override CardType CardType => CardType.Item;

        private ItemCard _itemCardData;

        public override void Init(BaseCard cardData)
        {
            _itemCardData = (ItemCard)cardData;
        }
    }
}