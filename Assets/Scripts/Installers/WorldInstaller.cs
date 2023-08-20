using Abilities;
using Managers;
using UnityEngine;
using Zenject;

public class WorldInstaller : MonoInstaller<WorldInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<MovementController>().AsTransient();
        Container.Bind<InputController>().AsSingle(); //Only player can call it!
        Container.BindInterfacesAndSelfTo<ServerAIManager>().AsSingle();
    }
        
}