using Managers.Misc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.CardBattleGame
{

    public abstract class BaseCardObject : MonoBehaviour
    {
        [SerializeField] private Image _cardImage;
        [SerializeField] private TMP_Text _levelLabel;

        public abstract CardType CardType { get; }

        public abstract void Init(BaseCard cardData);
    }
}