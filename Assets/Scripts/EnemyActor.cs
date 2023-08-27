using System.Collections;
using System.Collections.Generic;
using Abilities;
using Managers;
using UnityEngine;
using Zenject;

public class EnemyActor : BaseActor
{
    private AIController _aiController;
    private MovementController _movementController;
    
    public AIController AIController
    {
        get { return _aiController;}
        private set {}
        
    }
    public MovementController MovementController
    {
        get { return _movementController;}
        private set {}
    }
    
    [Inject]
    private void Construct(MovementController movementController, AIController aiController)
    {
        _movementController = movementController;
        _aiController = aiController;
        
        //Initialize controllers
        _aiController.Initialize(this.transform);
        _movementController.Initialize(this.transform);
    }
}
