using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Managers;
using UnityEngine.Tilemaps;

public enum Direction
{
    North,
    NorthEast,
    East,
    SouthEast,
    South,
    SouthWest,
    West,
    NorthWest
}

namespace Abilities
{
    public class MovementController
    {
        private float _movementDuration = 0.5f;
        private List<Vector3Int> _walkableNeighbours = new List<Vector3Int>();

        private bool _isMoving = false;

        private Transform _actorTransform;
        private GridManager _gridManager;

        public bool IsMoving
        {
            get { return _isMoving;}
            private set {}
        }

        public MovementController(Transform actorTransform)
        {
            _actorTransform = actorTransform;
            _gridManager = EventManager.GetGridManager();
        }

        public void MoveToTargetPosition(Direction direction)
        {
            //Calculate current neighbours(8 direction)
            _gridManager.CalculateNeighbourTiles(_actorTransform, out _walkableNeighbours);

            // If direction does not have any walkable tile return
            Vector3 targetWorldPosition = _gridManager.GetTileWorldPosition(_actorTransform, direction, _walkableNeighbours);
            Debug.Log(targetWorldPosition);
            
            if (!_gridManager.IsDirectionExist(_actorTransform, direction, _walkableNeighbours))
            {
                Debug.LogError($"There is no WALKABLE tile in {direction}");
                return;
            }

            _isMoving = true;
            //Start moving the target position
            _actorTransform.DOMove(targetWorldPosition, _movementDuration).OnComplete(() =>
            {
                _isMoving = false;
            });
        }

    }
}