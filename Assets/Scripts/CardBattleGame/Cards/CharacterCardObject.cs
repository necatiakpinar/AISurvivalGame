using Managers.CardBattleGame.Cards;
using Managers.Misc;
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
            base.Init(cardData);
            _characterCardData = (CharacterCard)cardData;

            _healthLabel.text = _characterCardData.ElementType.ToString();
            
            Debug.LogError(_characterCardData.test);
        }

        protected override void OnCardClicked()
        {
            base.OnCardClicked();
            Debug.LogError($"{CardType.ToString()} clicked ");
        }
    }
}