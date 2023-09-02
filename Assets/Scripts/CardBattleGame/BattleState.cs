using System;
using UnityEngine;

namespace Managers.CardBattleGame
{
    public class BattleBaseState : BaseState
    {
        private Action<BattleStateTypes> _onChangeState;

        public BattleBaseState(Action<BattleStateTypes> onChangeState)
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