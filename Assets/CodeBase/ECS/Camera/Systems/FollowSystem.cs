using Leopotam.Ecs;
using UnityEngine;

public class FollowSystem : IEcsRunSystem, IEcsInitSystem
{
    private readonly EcsFilter<ModelComponent, FollowComponent> followFilter;
    private readonly EcsFilter<PlayerTag> playerFilter;

    private Transform transformTarget;

    public void Init()
    {
        foreach(int i in playerFilter)
        {
            SetTransformTarget(i);
        }
    }

    private void SetTransformTarget(int i)
    {
        ref var entity = ref playerFilter.GetEntity(i);
        ref var model = ref entity.Get<ModelComponent>();

        transformTarget = model.Transform;
    }

    public void Run()
    {
        foreach (int i in followFilter)
        {
            Update(i);
        }
    }

    private void Update(int i)
    {
        ref var modelComponent = ref followFilter.Get1(i);
        ref var followComponent = ref followFilter.Get2(i);

        ref var transform = ref modelComponent.Transform;
        ref var distance = ref followComponent.distance;

        transform.position = transformTarget.position + distance;
    }
}