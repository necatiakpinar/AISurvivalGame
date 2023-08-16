using UnityEngine;
using Zenject;

public class WorldInstaller : MonoInstaller<WorldInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<string>().FromInstance("Hello World!");
        Container.Bind<int>().FromInstance(1);
        Container.Bind<Greeter>().AsSingle().NonLazy();
        Container.Bind<Greeter2>().AsSingle().NonLazy();
        
    }
        

    public class Greeter
    {
        public Greeter(string message, int test)
        {
            Debug.Log(message + test.ToString());
        }
    }
    
    public class Greeter2
    {
        public Greeter2(string message, int test)
        {
            Debug.Log(message + test.ToString());
        }
    }

    // public class Greeter
    // {
    //     readonly int _test;
    //     
    //     public Greeter(PlayerActor playerActor, int test)
    //     {
    //         if (playerActor != null)
    //             playerActor.Yell();
    //
    //         _test = test;
    //     }
    // }
}