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
    None,
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
        private Transform _actorTransform;
        private GridManager _gridManager;
        
        private float _movementDuration = 0.5f;
        private bool _isMoving = false;
        
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

        public void Initialize(Transform actorTransform)
        {
            _actorTransform = actorTransform;
        }

        public void MoveToTargetPosition(Vector3 movePosition)
        {
            _isMoving = true;
             //Start moving the target position
             _actorTransform.DOMove(movePosition, _movementDuration).OnComplete(() =>
             {
                 _isMoving = false;
             });
            }
    }
}