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
        private State _initializationState;
        private State _battleState;
        private State _resultState;
        private State _victoryState;
        private State _defeatState;

        private State _currentState;

        public BattleStateManager()
        {
            _initializationState = new InitializationState(ChangeState);
            _battleState = new BattleState(ChangeState);
            _resultState = new ResultState(ChangeState);
            _victoryState = new VictoryState(ChangeState);
            _defeatState = new DefeatState(ChangeState);

            //Give initial state for first state.
            _currentState = _initializationState;
            _currentState.Start();
        }

        private void Update()
        {
            if (_currentState != null)
                _currentState.Update();
        }

        private void ChangeState(BattleStateTypes _changedStateType)
        {
            switch (_changedStateType)
            {
                case BattleStateTypes.Initialization:
                    _currentState = _battleState;
                    break;
                case BattleStateTypes.Battle:
                    _currentState = _battleState;
                    break;
                case BattleStateTypes.Result:
                    _currentState = _resultState;
                    break;
                case BattleStateTypes.Victory:
                    _currentState = _victoryState;
                    break;
                case BattleStateTypes.Defeat:
                    _currentState = _defeatState;
                    break;
            }
            
            _currentState.Start();
        }
    }
}