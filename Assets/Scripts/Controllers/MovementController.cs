using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using DG.Tweening;
using Managers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine.Tilemaps;
using Zenject;

[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
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

        private GridManager _gridManager;

        public bool IsMoving
        {
            get { return _isMoving;}
            private set {}
        }

        [Inject]
        public MovementController(GridManager gridManager)
        {
            _gridManager = gridManager;
        }

        public void MoveToTargetPosition(Transform actorTransform, Direction direction)
        {
            //Calculate current neighbours(8 direction)
            _gridManager.CalculateNeighbourTiles(actorTransform);
            
            // If direction does not have any walkable tile return
        //     Vector3 targetWorldPosition = _gridManager.GetTileWorldPosition(actorTransform, direction, _walkableNeighbours);
        //     Debug.Log(targetWorldPosition);
        //     
        //     if (!_gridManager.IsDirectionExist(actorTransform, direction, _walkableNeighbours))
        //     {
        //         Debug.LogError($"There is no WALKABLE tile in {direction}");
        //         return;
        //     }
        //     
        //     _isMoving = true;
        //     //Start moving the target position
        //     actorTransform.DOMove(targetWorldPosition, _movementDuration).OnComplete(() =>
        //     {
        //         _isMoving = false;
        //     });
        }

    }
}