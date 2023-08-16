using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Abilities;
using Managers;
using UnityEngine;

public class PlayerActor : BaseActor
{
    private MovementController _movementController;
    private InputController _inputController;
    
    private void OnEnable()
    {
        EventManager.GetActivePlayer += (() => { return this; });
    }

    private void OnDisable()
    {
        EventManager.GetActivePlayer -= (() => { return this; });
    }

    private void Start()
    {
        _movementController = new MovementController(this.transform);
        _inputController = new InputController(_movementController);
    }

    private void Update()
    {
        _inputController.ListenInput();
    }
}
