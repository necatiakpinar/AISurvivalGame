    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abilities;
    using Managers;
    using UnityEngine;
    using Zenject;

    public class InputController
    {
        private List<Direction> _directions;
        private MovementController _movementController;
        private PlayerActor _playerActor;
        private ServerAIManager _aiManager;
        [Inject]
        public InputController(PlayerActor playerActor, ServerAIManager aiManager, MovementController movementController)
        {
            _playerActor = playerActor;
            _aiManager = aiManager;
            _movementController = movementController;
            _directions = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();
        }

        public async void ListenInput()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !_movementController.IsMoving)
            {
                int randomDirectionIndex = UnityEngine.Random.Range(0, _directions.Count);
                Direction randomDirection = _directions[randomDirectionIndex];
               
             //   AIResponse aiResponse = await _aiManager.SendCommand();
              //  Direction aiDirection = aiResponse.action.direction;
                _movementController.MoveToTargetPosition(_playerActor.transform, randomDirection);
            }
        }
    }
