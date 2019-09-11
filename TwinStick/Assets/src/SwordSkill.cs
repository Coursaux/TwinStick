using System.Collections;
using System.Collections.Generic;
using Missive_CSharp;
using UnityEngine;
using UnityEngine.Serialization;

public class SwordSkill : PlayerSkill
{
    [FormerlySerializedAs("SwordObject")] [SerializeField]
    private GameObject swordObject;

    [SerializeField] private float distance;

    private Timer _cooldown = new Timer(.2f);
    public override Timer Cooldown
    {
        get => _cooldown;
        set => _cooldown = value;
    }

    protected override void Behave(GameObject user)
    {
        MissiveAggregator.instance.Publish(new SwordUsedEvent(transform.position));
        Instantiate(swordObject, transform.position +  distance * gameObject.transform.forward, transform.rotation, transform);
    }
    
}
