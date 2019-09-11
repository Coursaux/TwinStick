using System;
using System.Collections;
using System.Collections.Generic;
using Missive_CSharp;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected EnemyHealthManager health;
    public GameObject player;
    // Start is called before the first frame update
    
    [SerializeField] 
    protected float aggroRadius;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = gameObject.GetComponentSafely<NavMeshAgent>();
        health = gameObject.GetComponentSafely<EnemyHealthManager>();
    }

    private void OnDestroy()
    {
        MissiveAggregator.instance.Publish(new EnemyDiedEvent(Vector3.zero));
    }
}
