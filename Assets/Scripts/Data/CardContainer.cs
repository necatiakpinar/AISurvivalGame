using Managers.CardBattleGame;
using UnityEngine;

namespace Managers.Data
{
    [CreateAssetMenu(fileName = "CardContainer", menuName = "DataContainer/CardContainer", order = 1)]
    public class CardContainer : DataContainer
    {
        [SerializeField] private CharacterCardObject _characterCardPF;
        [SerializeField] private ItemCardObject _itemCardPF;

        public CharacterCardObject CharacterCardObject
        {
            get { return _characterCardPF; }
            private set { }
        }

        public ItemCardObject ItemCardPF
        {
            get { return _itemCardPF; }
            private set { }
        }
    }
}