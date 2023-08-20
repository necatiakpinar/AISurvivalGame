
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
        
        //private Dictionary<Direction, List<TileInfoData>> _directionTileInfos;
        
        private void Awake()
        {
            //Check tile container status at the beginning of the game.
            if (IsTileMapsEmpty())
                throw new Exception();
            
        }
        public string CalculateNeighbourTiles(Transform actorTransform)
        {
            Dictionary<Direction, List<TileInfoData>> _directionTileInfos = new Dictionary<Direction, List<TileInfoData>>();
            TileMapInfo tileMapInfo = new TileMapInfo();
            List<TileInfoData> tileInfos = new List<TileInfoData>();
            Vector3Int _neighbourPosition = Vector3Int.zero;
            
            for (int i = 0; i < _directions.Count; i++)
            {
                tileInfos = new List<TileInfoData>();
                
                for (int j = 0; j < _tileMapContainer.Count; j++)
                {
                    tileMapInfo = _tileMapContainer[j];
                    //Player position + neighbour direction 
                    _neighbourPosition = tileMapInfo.TileMap.WorldToCell(actorTransform.position) + _directions[i];

                    if (tileMapInfo.TileMap.HasTile(_neighbourPosition))
                    {
                        Debug.LogError(_directions[i].ToString() + tileMapInfo.TileType + _neighbourPosition.ToString());
                        TileInfoData tileInfoData = new TileInfoData(tileMapInfo.TileType, _neighbourPosition);
                        tileInfos.Add(tileInfoData);
                        
                    }

                }
                _directionTileInfos.Add((Direction)i, tileInfos);
            }
        
            string jsonData = JsonConvert.SerializeObject(_directionTileInfos);
            Debug.LogError(jsonData);
            return jsonData;
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

        public bool IsActorHasGivenTypeTileInDirection(string _directionTileInfoJson, Direction direction, TileType tileType)
        {
            Dictionary<Direction, List<TileInfoData>> directionTileInfo = JsonConvert.DeserializeObject<Dictionary<Direction, List<TileInfoData>>>(_directionTileInfoJson);
            if (directionTileInfo[direction].Count == 0)
                return false;
            
            return directionTileInfo[direction][0].TileType == tileType;
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
