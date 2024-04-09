using System;
using UnityEngine;

[Serializable]
public struct RotationComponent
{
    public Rigidbody Rb;
    public float Speed;
    public Vector3 maxSpeed;
}
