using Leopotam.Ecs;
using UnityEngine;

public sealed class MovementSystem : IEcsRunSystem
{
    private readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> movableFilter = null;

    public void Run()
    {
        foreach(var i in movableFilter)
        {
            Update(i);
        }
    }

    private void Update(int i)
    {
        ref var modelComponent = ref movableFilter.Get1(i);
        ref var movableComponent = ref movableFilter.Get2(i);
        ref var directionComponent = ref movableFilter.Get3(i);

        ref var direction = ref directionComponent.Direction;
        ref var transform = ref modelComponent.Transform;

        ref var rb = ref movableComponent.Rb;
        ref var speed = ref movableComponent.Speed;
        ref var maxForce = ref movableComponent.maxForce;


        if (transform == null)
            Debug.Log("Transform");
        if (direction == null)
            Debug.Log("Direction");
        Vector3 rawDirection = transform.forward * direction.z;
        Vector3 force = rawDirection * speed;

        force += rb.velocity;
        force.x = CheckAxis(force.x, maxForce.x);
        force.y = CheckAxis(force.y, maxForce.y);
        force.z = CheckAxis(force.z, maxForce.z);
        rb.velocity = force;
    }

    private float CheckAxis(float force, float maxForce)
    {
        if (force < 0)
        {
            if (force < -maxForce)
                return -maxForce;
        }
        else 
        {
            if (force > maxForce)
                return maxForce;
        }

        return force;
    }
}
