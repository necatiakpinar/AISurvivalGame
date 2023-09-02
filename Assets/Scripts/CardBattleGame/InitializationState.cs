using System;
using UnityEngine;

namespace Managers.CardBattleGame
{
    public class InitializationBaseState : BaseState
    {
        private Action<BattleStateTypes> _onChangeState;

        public InitializationBaseState(Action<BattleStateTypes> onChangeState)
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