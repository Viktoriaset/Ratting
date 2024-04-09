using System;
using UnityEngine;

public static class Vector3Extends
{
    public static void ChangeEveryAxis(this Vector3 v, Func<float, float> callback)
    {
        v.x = callback.Invoke(v.x);
        v.y = callback.Invoke(v.y);
        v.z = callback.Invoke(v.z);
    }
}