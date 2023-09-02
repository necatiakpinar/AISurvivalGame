using UnityEngine;

namespace Managers.CardBattleGame.Cards
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Card/ItemCard", order = 2)]
    public class ItemCard : BaseCard
    {
        [SerializeField] private string _itemName;

        public string ItemName
        {
            get { return _itemName; }
            private set { }
        }
    }
}