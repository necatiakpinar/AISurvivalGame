using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.CardBattleGame
{
    public class BaseCardObject : MonoBehaviour
    {
        [SerializeField] private Image _cardImage;
        [SerializeField] private  TMP_Text _levelLabel;
    }
}