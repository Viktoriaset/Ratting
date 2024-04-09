using System;
using UnityEngine;

[Serializable]
public struct MovableComponent
{
    public Rigidbody Rb;
    public float Speed;
    public Vector3 maxForce;
}
