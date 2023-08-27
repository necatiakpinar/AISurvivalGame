using Abilities;
using Managers;
using UnityEngine;
using Zenject;

public class WorldInstaller : MonoInstaller<WorldInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<AIController>().AsTransient();
        Container.Bind<InputController>().AsSingle(); //Only player can call it!
        Container.Bind<MovementController>().AsTransient();
        Container.BindInterfacesAndSelfTo<ServerAIManager>().AsSingle();
    }
        
}