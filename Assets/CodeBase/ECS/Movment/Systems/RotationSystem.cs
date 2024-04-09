using System.Runtime.InteropServices;
using Leopotam.Ecs;
using UnityEngine;

public sealed class RotationSystem : IEcsRunSystem
{
    private readonly EcsFilter<ModelComponent, DirectionComponent, RotationComponent> rotationFilter = null;

    public void Run()
    {
        foreach(int i in rotationFilter)
        {
            ref var modelComponent = ref rotationFilter.Get1(i);
            ref var directionComponent = ref rotationFilter.Get2(i);
            ref var rotationComponent = ref rotationFilter.Get3(i);

            ref var direction = ref directionComponent.Direction;
            ref var transform = ref modelComponent.Transform;

            ref var rb = ref rotationComponent.Rb;

            if (direction.x == 0)
                return;

            transform.Rotate(new Vector3(0, direction.x * rotationComponent.Speed * Time.deltaTime, 0));
        }
    }
}
