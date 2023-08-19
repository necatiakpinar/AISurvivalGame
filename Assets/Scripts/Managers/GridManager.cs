
using System;
using System.Collections.Generic;
using DG.Tweening;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Managers
{
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TileType
    {
        Empty,
        Walkable,
        Obstacle
    }

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

    [Serializable]
    public class TileInfo
    {
        [SerializeField] private TileType _tileType;
       // [SerializeField] private TileBase _tile;

        public TileType TileType
        {
            get { return _tileType;}
            private set {}
        }
        // public TileBase Tile
        // {
        //     get { return _tile; }
        //     private set {}
        // }
        public TileInfo(TileType tileType)
        {
            _tileType = tileType;
            //_tile = tile;
        }
    }
    
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
        [SerializeField] private List<TileMapInfo> _tileMapContainer;
        [SerializeField] private Tilemap _tileMap;
        
        private Dictionary<Direction, List<TileInfo>> _directionTileInfos;
        
        private void Awake()
        {
            //Check tile container status at the beginning of the game.
            if (IsTileMapsEmpty())
                throw new Exception();
            
        }
        public void CalculateNeighbourTiles(Transform actorTransform)
        {
            _directionTileInfos = new Dictionary<Direction, List<TileInfo>>();
            TileMapInfo tileMapInfo = new TileMapInfo();
            List<TileInfo> tileInfos = new List<TileInfo>();
            Vector3Int _neighbourPosition = Vector3Int.zero;
            
            for (int i = 0; i < _directions.Count; i++)
            {
                tileInfos.Clear();
                
                for (int j = 0; j < _tileMapContainer.Count; j++)
                {
                    tileMapInfo = _tileMapContainer[j];

                    //Player position + neighbour direction 
                    _neighbourPosition = tileMapInfo.TileMap.WorldToCell(actorTransform.position) + _directions[i];

                    if (IsTileHasGivenType(_neighbourPosition, tileMapInfo.TileType))
                    {
                        TileBase tile = tileMapInfo.TileMap.GetTile(_neighbourPosition);
                        TileInfo tileInfo = new TileInfo(tileMapInfo.TileType);
                        tileInfos.Add(tileInfo);
                    }
                }

                _directionTileInfos.Add((Direction)i, tileInfos);
            }
            
            Debug.LogError(_directionTileInfos[Direction.East].Count);

    
            // Register the custom converter when initializing JSON.NET
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = {new Vector3Converter() }
            };

            
            //string jsonData = JsonConvert.SerializeObject(_directionTileInfos, settings);
            string jsonData = JsonConvert.SerializeObject(_directionTileInfos);
            Debug.LogError(jsonData);
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

        private bool IsTileMapsEmpty()
        {
            if (_tileMapContainer == null)
                return true;
            
            foreach (var tileMap in _tileMapContainer)
                if (tileMap.TileMap == null)
                    return true;

            return false;
        }
        public bool IsTileHasGivenType(Vector3Int tileWorldPosition, TileType tileType)
        {
            for (int i = 0; i < _tileMapContainer.Count; i++)
                return _tileMapContainer[i].TileMap.HasTile(tileWorldPosition) && _tileMapContainer[i].TileType == tileType;

            return false;
        }
        
        public bool IsTileHasOnlyGivenType(Vector3Int tileWorldPosition, TileType tileType)
        {
            TileMapInfo tileMapInfo;
            
            for (int i = 0; i < _tileMapContainer.Count; i++)
            {
                tileMapInfo = _tileMapContainer[i];
                if (tileMapInfo.TileMap.HasTile(tileWorldPosition) && tileMapInfo.TileType != tileType)
                    return false;
            }

            return true;
        }

        public List<TileInfo> GetTileInDirection(Direction direction)
        {
            return _directionTileInfos[direction];
        }
    }
}

public class Vector3Converter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Vector3);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var vector = (Vector3)value;
        var jsonObject = new JObject
        {
            { "x", vector.x },
            { "y", vector.y },
            { "z", vector.z }
        };
        jsonObject.WriteTo(writer);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);
        float x = (float)jsonObject["x"];
        float y = (float)jsonObject["y"];
        float z = (float)jsonObject["z"];
        return new Vector3(x, y, z);
    }
}
