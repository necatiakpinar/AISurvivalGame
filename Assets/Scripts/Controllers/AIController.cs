using System.Collections;
using System.Collections.Generic;
using Abilities;
using Managers;
using UnityEngine;
using Zenject;

public class AIController 
{
    private Transform _actorTransform;
    private GridManager _gridManager;
    private List<ActorDirectionEnvironmentData> _directionEnvironmentData;
    
    [Inject]
    private void Construct(GridManager gridManager)
    {
        _gridManager = gridManager;
    }

    public void Initialize(Transform actorTransform)
    {
        _actorTransform = actorTransform;
    }

    public void CalculateEnvironmentData()
    {
        _directionEnvironmentData = _gridManager.GetCalculatedActorEnvironmentData(_actorTransform);
    }

    public Vector3? GetWalkableTilePosition(Direction direction)
    {
        for (int i = 0; i < _directionEnvironmentData.Count; i++)
            if (_directionEnvironmentData[i].Direction == direction && _directionEnvironmentData[i].IsDirectionHasGivenTileType(TileType.Walkable))
                return _directionEnvironmentData[i].GetTileWithType(TileType.Walkable).TilePosition;
        
        //If there is no tile then return NULL
        return null;
    }
}
