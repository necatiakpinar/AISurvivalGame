    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abilities;
    using Managers;
    using UnityEngine;

    public class InputController
    {
        private List<Direction> _directions;
        private MovementController _movementController;

        public InputController(MovementController movementController)
        {
            _movementController = movementController;
            _directions = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();
        }

        public async void ListenInput()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !_movementController.IsMoving)
            {
                int randomDirectionIndex = UnityEngine.Random.Range(0, _directions.Count);
                Direction randomDirection = _directions[randomDirectionIndex];
               
                AIResponse aiResponse = await EventManager.SendCommand();
                Direction aiDirection = aiResponse.action.direction;
                _movementController.MoveToTargetPosition(aiDirection);
            }
        }
    }
