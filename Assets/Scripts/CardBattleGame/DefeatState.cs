using System;
using UnityEngine;

namespace Managers.CardBattleGame
{
    public class DefeatBaseState : BaseState
    {
        private Action<BattleStateTypes> _onChangeState;

        public DefeatBaseState(Action<BattleStateTypes> onChangeState)
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