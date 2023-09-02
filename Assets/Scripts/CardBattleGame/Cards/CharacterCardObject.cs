using TMPro;
using UnityEngine;

namespace Managers.CardBattleGame
{
    public class CharacterCardObject : BaseCardObject
    {
        [SerializeField] private  TMP_Text _healthLabel;
        [SerializeField] private  TMP_Text _manaLabel;       
    }
}