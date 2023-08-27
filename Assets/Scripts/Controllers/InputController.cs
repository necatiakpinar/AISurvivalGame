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
        private GridManager _gridManager;
        
        private string _directionTileInfosJson;
        private Vector3? _movePosition;

        private List<ActorDirectionEnvironmentData> _directionEnvironmentData = new List<ActorDirectionEnvironmentData>();

        [Inject]
        public InputController(PlayerActor playerActor, ServerAIManager aiManager, MovementController movementController, GridManager gridManager)
        {
            _playerActor = playerActor;
            _aiManager = aiManager;
            _movementController = movementController;
            _gridManager = gridManager;
            _directions = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();
        }

        public async void ListenInput()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !_movementController.IsMoving)
            {
                int randomDirectionIndex = UnityEngine.Random.Range(0, _directions.Count);
                Direction randomDirection = _directions[randomDirectionIndex];

                // //Calculate current neighbours(8 direction)
                _directionTileInfosJson = _gridManager.CalculateEnvironmentDataAsJSON(_playerActor.transform);
                
                // AIResponse aiResponse = await _aiManager.SendCommand(_playerActor.transform.position, _directionTileInfosJson);
                // Direction aiDirection = aiResponse.action.direction;
                // Debug.LogError(aiDirection);
                // _playerActor.CalculateEnvironmentData();
                // _movePosition = _playerActor.GetWalkableTilePosition(aiDirection);
                // _movementController.MoveToTargetPosition(_playerActor.transform, (Vector3)_movePosition);
                
                // //Calculate current neighbours(8 direction)
                 _playerActor.CalculateEnvironmentData();
                 _movePosition = _playerActor.GetWalkableTilePosition(Direction.East);
                
                //Check given direction has walkable tile, than send move trigger to movement controller.
                 if (_movePosition != null)
                 {
                     _movementController.MoveToTargetPosition(_playerActor.transform, (Vector3)_movePosition);    
                 }
            }
        }
        
    }
