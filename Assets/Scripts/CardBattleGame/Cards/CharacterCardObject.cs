using Managers.CardBattleGame.Cards;
using TMPro;
using UnityEngine;

namespace Managers.CardBattleGame
{
    public class CharacterCardObject : BaseCardObject
    {
        [SerializeField] private TMP_Text _healthLabel;
        [SerializeField] private TMP_Text _manaLabel;
        [SerializeField] private TMP_Text _attackLabel;

        public override CardType CardType => CardType.Character;

        private CharacterCard _characterCardData;

        public override void Init(BaseCard cardData)
        {
            _characterCardData = (CharacterCard)cardData;

            _healthLabel.text = _characterCardData.CharacterName;
        }
    }
}