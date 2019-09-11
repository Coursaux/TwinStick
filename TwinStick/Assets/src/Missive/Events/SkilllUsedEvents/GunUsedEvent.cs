using System.Collections;
using System.Collections.Generic;
using Missive_CSharp;
using UnityEngine;

public class GunUsedEvent : Missive
{
    public Vector3 position;

    public GunUsedEvent(Vector3 position)
    {
        this.position = position;
    }

    public override string ToString()
    {
        throw new System.NotImplementedException();
    }
}
