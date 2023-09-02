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
    private AIController _aiController;
    private InputController _inputController;

    private MovementController _movementController;

    public AIController AIController
    {
        get { return _aiController; }
        private set { }
    }

    public MovementController MovementController
    {
        get { return _movementController; }
        private set { }
    }

    [Inject]
    private void Construct(MovementController movementController, AIController aiController, InputController inputController)
    {
        _movementController = movementController;
        _aiController = aiController;
        _inputController = inputController;

        //Initialize controllers
        _aiController.Initialize(this.transform);
        _movementController.Initialize(this.transform);
    }

    private void Update()
    {
        _inputController.ListenInput();
    }
}