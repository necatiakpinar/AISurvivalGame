
using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Managers
{
    public class GridManager : MonoBehaviour
    {
        private List<Vector3Int> _directions = new List<Vector3Int>()
        {
            new Vector3Int(0,1,0), // North
            new Vector3Int(1,1,0), // NorthEeast
            new Vector3Int(1,0,0), // East
            new Vector3Int(1,-1,0), // SouthEast
            new Vector3Int(0,-1,0), // South
            new Vector3Int(-1,-1,0), // SouthtWest
            new Vector3Int(-1,0,0), // West
            new Vector3Int(-1,1,0), //NorthWest
        };

        [Header("Tiles")]
        [SerializeField] private Tilemap _tileMap;


        private void OnEnable()
        {
            EventManager.GetGridManager += (() => { return this; });
            Grid grid;
        }

        private void OnDisable()
        {
            EventManager.GetGridManager -= (() => { return this; });
        }

        public void CalculateNeighbourTiles(Transform actorTransform, out List<Vector3Int> _walkableNeighbours)
        {
            _walkableNeighbours = new List<Vector3Int>();
            
            if (_tileMap == null)
                return;

            Vector3Int _neighbourPosition = Vector3Int.zero;
            //Clear Neighbours before calculating new ones
            _walkableNeighbours.Clear();

            for (int i = 0; i < _directions.Count; i++)
            {
                //Player position + neighbour direction 
                _neighbourPosition = _tileMap.WorldToCell(actorTransform.position) + _directions[i];
                
                if (_tileMap.HasTile(_neighbourPosition))
                {
                    _walkableNeighbours.Add(_neighbourPosition);
                }
            }
            
        }
        
        public bool IsDirectionExist(Transform actorTransform, Direction direction, List<Vector3Int> _walkableNeighbours)
        {
            if (_walkableNeighbours.Count == 0)
                return false;
            
            Vector3Int _neighbourPosition = Vector3Int.zero;
            
            for (int i = 0; i < _walkableNeighbours.Count; i++)
            {
                _neighbourPosition = _tileMap.WorldToCell(actorTransform.position) + _directions[(int)direction];
                if (_walkableNeighbours.Contains(_neighbourPosition))
                    return true;
            }
            
            return false;
        }

        public Vector3Int GetTileCellPosition(Transform actorTransform, Direction direction, List<Vector3Int> _walkableNeighbours)
        {
            Vector3Int _neighbourPosition = Vector3Int.zero;
            for (int i = 0; i < _walkableNeighbours.Count; i++)
            {
                _neighbourPosition = _tileMap.WorldToCell(actorTransform.position) + _directions[(int)direction];
                if (_walkableNeighbours.Contains(_neighbourPosition))
                    return _neighbourPosition;
            }

            return _neighbourPosition;
        }
        
        public Vector3 GetTileWorldPosition(Transform actorTransform, Direction direction, List<Vector3Int> _walkableNeighbours)
        {
            Vector3Int _neighbourPosition = Vector3Int.zero;
            
            for (int i = 0; i < _walkableNeighbours.Count; i++)
            {
                _neighbourPosition = _tileMap.WorldToCell(actorTransform.position) + _directions[(int)direction];
                if (_walkableNeighbours.Contains(_neighbourPosition))
                    return _tileMap.CellToWorld(_neighbourPosition);
            }
            
            Debug.LogError($"There is no tile at {_neighbourPosition}");
            return _neighbourPosition;
        }
    }
}