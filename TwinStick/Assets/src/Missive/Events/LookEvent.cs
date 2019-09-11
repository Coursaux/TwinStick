using System.Collections;
using System.Collections.Generic;
using Missive_CSharp;
using UnityEngine;

public class LookEvent : Missive
{
    public Vector2 axis;

    LookEvent(Vector2 axis_values)
    {
        axis = axis_values;
    }

    public override string ToString()
    {
        return string.Format("Look vector: {0},{1}", axis.x, axis.y);
    }
}
