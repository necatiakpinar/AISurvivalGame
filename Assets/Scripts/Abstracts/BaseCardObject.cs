using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.CardBattleGame
{
    public enum CardType
    {
        None = 0,
        Character = 10,
        Item = 20
    }

    public enum CardElementType
    {
        None = 0,
        Necati = 1,
    }

    public abstract class BaseCardObject : MonoBehaviour
    {
        [SerializeField] private Image _cardImage;
        [SerializeField] private TMP_Text _levelLabel;

        public abstract CardType CardType { get; }

        public abstract void Init(BaseCard cardData);
    }
}