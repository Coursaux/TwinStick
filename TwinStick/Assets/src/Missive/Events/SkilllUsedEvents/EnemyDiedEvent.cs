﻿using System.Collections;
using System.Collections.Generic;
using Missive_CSharp;
using UnityEngine;

public class EnemyDiedEvent : Missive
{
    public Vector3 position;

    public EnemyDiedEvent(Vector3 position)
    {
        this.position = position;
    }

    public override string ToString()
    {
        throw new System.NotImplementedException();
    }
}