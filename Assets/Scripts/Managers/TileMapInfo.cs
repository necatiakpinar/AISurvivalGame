using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Managers
{
    [Serializable]
    public class TileMapInfo
    {
        [SerializeField] private TileType _tileType;
        [SerializeField] private Tilemap _tilemap;

        public TileType TileType
        {
            get { return _tileType;}
            private set {}
        }
        public Tilemap TileMap
        {
            get { return _tilemap;}
            private set {}
        }
    }
}