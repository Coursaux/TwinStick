using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwordObjectController : MonoBehaviour
{
    [SerializeField]
    private float timeActive;

    private Timer timeToLive;
    private LayerMask allMask = ~0;
    
    [SerializeField]
    private int SwordDamage;

    [SerializeField] private float force;
    void Start()
    {
        timeToLive = new Timer(timeActive);
        timeToLive.RegisterTimerCallback( () => Destroy(gameObject) );
        
        var colliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, allMask );
        foreach (var col in (colliders))
        {
            var kb = col.GetComponent<KnockbackController>();
            if(kb != null)
            {
                kb.Knockback(transform.forward*force, 0.1f);
            }
            var health = col.GetComponent<EnemyHealthManager>();
            if (health != null)
            {
               health.takeDamage(SwordDamage);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        timeToLive.Update();
    }
}
