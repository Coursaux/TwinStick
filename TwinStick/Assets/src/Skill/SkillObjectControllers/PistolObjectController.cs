using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolObjectController : MonoBehaviour
{
    Timer timeToLive = new Timer(0.8f);
    [SerializeField]
    private int PistolDamage;
    [SerializeField]
    private float knockbackForce;

    private LayerMask allMask = ~0;
    void Start()
    {
        timeToLive.RegisterTimerCallback(()=>Destroy(this.gameObject));
        
        var colliders = Physics.OverlapBox(transform.GetChild(0).position, transform.GetChild(0).localScale / 2, 
            gameObject.transform.GetChild(0).rotation, allMask );
        foreach (var col in (colliders))
        {
            var kb = col.GetComponent<KnockbackController>();
            if(kb != null)
            {
                kb.Knockback(transform.forward*knockbackForce, 0.2f);
            }
            var health = col.GetComponent<EnemyHealthManager>();
            if (health != null)
            {
                health.takeDamage(PistolDamage);
            }
        }
    }

    private void Update()
    {
        timeToLive.Update();
    }
}
