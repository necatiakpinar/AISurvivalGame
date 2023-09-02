using System;
using UnityEngine;

namespace Managers.CardBattleGame
{
    public class ResultBaseState : BaseState
    {
        private Action<BattleStateTypes> _onChangeState;

        public ResultBaseState(Action<BattleStateTypes> onChangeState)
        {
            _onChangeState = onChangeState;
        }

        public override void Start()
        {
            Debug.LogError("Result started");
        }

        public override void Update()
        {
        }

        public override void End()
        {
            Debug.LogError("Result ended");
        }
    }
}