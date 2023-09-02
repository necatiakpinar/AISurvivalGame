using System;
using UnityEngine;

namespace Managers.CardBattleGame
{
    public class InitializationState : State
    {
        private Action<BattleStateTypes> _onChangeState;

        public InitializationState(Action<BattleStateTypes> onChangeState)
        {
            _onChangeState = onChangeState;
        }

        public override void Start()
        {
            Debug.LogError("Initialization started");
        }

        public override void Update()
        {
            End();
        }

        public override void End()
        {
            Debug.LogError("Initialization ended");
            _onChangeState?.Invoke(BattleStateTypes.Battle);
        }
    }
}