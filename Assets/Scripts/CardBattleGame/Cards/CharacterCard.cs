
using Managers.Misc;
using UnityEngine;

namespace Managers.CardBattleGame.Cards
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Card/CharacterCard", order = 1)]
    public class CharacterCard : BaseCard
    {
        public string test = "test";
        public override CardType CardType => CardType.Character;
    }
}