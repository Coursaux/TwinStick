using System.Collections;
using System.Collections.Generic;
using Missive_CSharp;
using UnityEngine;

public class EnemyAttackEvent : Missive
{public Vector3 position;

    public EnemyAttackEvent(Vector3 position)
     {
         this.position = position;
     }
    
    public override string ToString()
    {
        throw new System.NotImplementedException();
    }
}
