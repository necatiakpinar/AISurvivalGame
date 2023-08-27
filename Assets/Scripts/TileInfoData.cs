using System;
using UnityEngine;

namespace Managers
{
    [Serializable]
    public class TileInfoData
    {
        [SerializeField] private TileType _tileType;
        [SerializeField] private Vector3Int _tilePosition;

        public TileType TileType
        {
            get { return _tileType;}
            private set {}
        }
        public Vector3Int TilePosition
        {
            get { return _tilePosition; }
            private set {}
        }
        public TileInfoData(TileType tileType, Vector3Int tilePosition)
        {
            _tileType = tileType;
            _tilePosition = tilePosition;
        }
    }
}