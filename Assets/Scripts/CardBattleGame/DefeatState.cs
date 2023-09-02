using System;
using UnityEngine;

namespace Managers.CardBattleGame
{
    public class DefeatState : State
    {
        private Action<BattleStateTypes> _onChangeState;

        public DefeatState(Action<BattleStateTypes> onChangeState)
        {
            _onChangeState = onChangeState;
        }

        public override void Start()
        {
            Debug.LogError("Defeat started");
        }

        public override void Update()
        {
        }

        public override void End()
        {
            Debug.LogError("Defeat ended");
        }
    }
}