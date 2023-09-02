using System;
using UnityEngine;

namespace Managers.CardBattleGame
{
    public class VictoryBaseState : BaseState
    {
        private Action<BattleStateTypes> _onChangeState;

        public VictoryBaseState(Action<BattleStateTypes> onChangeState)
        {
            _onChangeState = onChangeState;
        }

        public override void Start()
        {
            Debug.LogError("Victory started");
        }

        public override void Update()
        {
        }

        public override void End()
        {
            Debug.LogError("Victory ended");
        }
    }
}