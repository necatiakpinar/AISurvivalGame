﻿using UnityEngine;

namespace Managers.CardBattleGame.Cards
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Card/CharacterCard", order = 1)]
    public class CharacterCards : BaseCard
    {
        [SerializeField] private string _characterName;

        public string CharacterName
        {
            get { return _characterName; }
            private set { }
        }
    }
}