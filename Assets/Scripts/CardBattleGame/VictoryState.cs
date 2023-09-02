using System;
using UnityEngine;

namespace Managers.CardBattleGame
{
    public class VictoryState : State
    {
        private Action<BattleStateTypes> _onChangeState;

        public VictoryState(Action<BattleStateTypes> onChangeState)
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