using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Abilities;
using Managers;
using UnityEngine;
using Zenject;

public class PlayerActor : BaseActor
{
    private MovementController _movementController;
    private InputController _inputController;
    private GridManager _gridManager;

    private List<ActorDirectionEnvironmentData> _directionEnvironmentData;
    
    [Inject]
    private void Construct(MovementController movementController, InputController inputController, GridManager gridManager)
    {
        _movementController = movementController;
        _inputController = inputController;
        _gridManager = gridManager;
        Debug.LogError("Player constructed!");
    }
    
    private void Update()
    {
        _inputController.ListenInput();
    }

    //It calculates environment objects, such as walkable, obstacle tiles.
    public void CalculateEnvironmentData()
    {
        _directionEnvironmentData = _gridManager.GetCalculatedActorEnvironmentData(this.transform);
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
