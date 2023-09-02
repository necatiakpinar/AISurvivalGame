using System;
using UnityEngine;

namespace Managers.CardBattleGame
{
    [Serializable]
    public enum BattleStateTypes
    {
        Initialization,
        Battle,
        Result,
        Victory,
        Defeat
    }

    public class BattleStateManager : MonoBehaviour
    {
        private BaseState _initializationBaseState;
        private BaseState _battleBaseState;
        private BaseState _resultBaseState;
        private BaseState _victoryBaseState;
        private BaseState _defeatBaseState;

        private BaseState _currentBaseState;

        public BattleStateManager()
        {
            _initializationBaseState = new InitializationBaseState(ChangeState);
            _battleBaseState = new BattleBaseState(ChangeState);
            _resultBaseState = new ResultBaseState(ChangeState);
            _victoryBaseState = new VictoryBaseState(ChangeState);
            _defeatBaseState = new DefeatBaseState(ChangeState);

            //Give initial state for first state.
            _currentBaseState = _initializationBaseState;
            _currentBaseState.Start();
        }

        private void Update()
        {
            if (_currentBaseState != null)
                _currentBaseState.Update();
        }

        private void ChangeState(BattleStateTypes _changedStateType)
        {
            switch (_changedStateType)
            {
                case BattleStateTypes.Initialization:
                    _currentBaseState = _battleBaseState;
                    break;
                case BattleStateTypes.Battle:
                    _currentBaseState = _battleBaseState;
                    break;
                case BattleStateTypes.Result:
                    _currentBaseState = _resultBaseState;
                    break;
                case BattleStateTypes.Victory:
                    _currentBaseState = _victoryBaseState;
                    break;
                case BattleStateTypes.Defeat:
                    _currentBaseState = _defeatBaseState;
                    break;
            }
            
            _currentBaseState.Start();
        }
    }
}