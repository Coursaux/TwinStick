using System.Collections;
using System.Collections.Generic;
using Missive_CSharp;
using UnityEngine;

public class PistolSkill : PlayerSkill
{
    [SerializeField]
    private GameObject pistolObject;
    Timer _timer = new Timer(2f);
    
    public override Timer Cooldown
    {
        get => _timer;
        set => _timer = value;
    }

    protected override void Behave(GameObject User)
    {
        MissiveAggregator.instance.Publish(new GunUsedEvent(transform.position));
        Instantiate(pistolObject, transform.position + gameObject.transform.forward*1.4f, transform.rotation, transform);
    }
}
