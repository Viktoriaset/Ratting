using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public sealed class ECSGameStartup : MonoBehaviour
{
    private EcsWorld world;
    private EcsSystems systems;

    public void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);

        systems.ConvertScene();

        AddInjections();
        AddSystems();
        AddOneFrames();

        systems.Init();
    }

    private void AddInjections()
    {
        
    }

    private void AddSystems()
    {
        systems
        .Add(new PlayerInputSystem())
        .Add(new MovementSystem())
        .Add(new RotationSystem())
        .Add(new FollowSystem())
        ;
    }

    private void AddOneFrames()
    {

    }

    private void Update() 
    {
        systems.Run();    
    }

    private void OnDestroy() 
    {
        if (systems == null) return;

        systems.Destroy();
        systems = null;
        world.Destroy();
        world = null;   
    }


}
