using System.Collections;
using System.Collections.Generic;
using Missive_CSharp;
using UnityEngine;

public class SwordUsedEvent : Missive
{
    public Vector3 position;
    public SwordUsedEvent(Vector3 position)
    {
        this.position = position;
    }
    
    public override string ToString()
    {
        throw new System.NotImplementedException();
    }
}
