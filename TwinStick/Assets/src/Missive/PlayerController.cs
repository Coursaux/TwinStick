using System.Collections;
using System.Collections.Generic;
using Missive_CSharp;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour, IMissiveListener<SwordInputEvent>, IMissiveListener<GunInputEvent>
{
    void Start()
    {
        
        MissiveAggregator.instance.Register<SwordInputEvent>(this);
        MissiveAggregator.instance.Register<GunInputEvent>(this);
    }

    public void HandleMissive(SwordInputEvent missive)
    {
        gameObject.GetComponentSafely<SwordSkill>().Use(gameObject);
    }

    public void HandleMissive(GunInputEvent missive)
    {
        gameObject.GetComponentSafely<PistolSkill>().Use(gameObject);
    }
}
