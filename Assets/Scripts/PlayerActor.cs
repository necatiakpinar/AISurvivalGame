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
    
    [Inject]
    private void Construct(MovementController movementController, InputController inputController)
    {
        _movementController = movementController;
        _inputController = inputController;
        Debug.LogError("Player constructed!");
    }
    
    private void Update()
    {
        _inputController.ListenInput();
    }
    
}
