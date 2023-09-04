using UnityEngine;

namespace Managers.CardBattleGame.Cards
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Card/CharacterCard", order = 1)]
    public class CharacterCard : BaseCard
    {
        [SerializeField] private string _characterName;
        public override CardType CardType => CardType.Character;

        public string CharacterName
        {
            get { return _characterName; }
            private set { }
        }
    }
}