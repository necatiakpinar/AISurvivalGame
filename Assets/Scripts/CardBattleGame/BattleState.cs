using System;
using UnityEngine;

namespace Managers.CardBattleGame
{
    public class BattleState : State
    {
        private Action<BattleStateTypes> _onChangeState;

        public BattleState(Action<BattleStateTypes> onChangeState)
        {
            _onChangeState = onChangeState;
        }

        public override void Start()
        {
            Debug.LogError("Battle started");
        }

        public override void Update()
        {
        }

        public override void End()
        {
            Debug.LogError("Battle ended");
        }
    }
}