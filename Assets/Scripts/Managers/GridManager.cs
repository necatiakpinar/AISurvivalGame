
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

    public class GridManager : MonoBehaviour
    {
        private List<Vector3Int> _directions = new List<Vector3Int>()
        {
            new Vector3Int(0,0,0), // None
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
        
        private void Awake()
        {
            //Check tile container status at the beginning of the game.
            if (IsTileMapsEmpty())
                throw new Exception();
            
        }
        public string CalculateEnvironmentDataAsJSON(Transform actorTransform)
        {
            List<ActorDirectionEnvironmentData> _directionEnvironmentData = new List<ActorDirectionEnvironmentData>();
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
                        TileInfoData tileInfoData = new TileInfoData(tileMapInfo.TileType, _neighbourPosition);
                        tileInfos.Add(tileInfoData);
                        
                    }

                }
                _directionEnvironmentData.Add(new ActorDirectionEnvironmentData((Direction)i, tileInfos));
            }
        
            string jsonData = JsonConvert.SerializeObject(_directionEnvironmentData);
            Debug.LogError(jsonData);
            return jsonData;
        }
        
        public List<ActorDirectionEnvironmentData> GetCalculatedActorEnvironmentData(Transform actorTransform)
        {
            List<ActorDirectionEnvironmentData> _directionEnvironmentData = new List<ActorDirectionEnvironmentData>();
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
                        TileInfoData tileInfoData = new TileInfoData(tileMapInfo.TileType, _neighbourPosition);
                        tileInfos.Add(tileInfoData);
                        
                    }
                }
                _directionEnvironmentData.Add(new ActorDirectionEnvironmentData((Direction)i, tileInfos));
            }
        
            return _directionEnvironmentData;
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
