using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Missive_CSharp;
using UnityEngine.AI;
using System;

public class Boss : MonoBehaviour
{
    private Timer damageCooldown;
    public static Boss instance;

    
    private Animator anim;

    public Transform target;

    [SerializeField]
    private float damageCooldownTime;

    [SerializeField] private int damage;

    public float attackCooldown;
    public float attackCooldownTimer;

    private NavMeshAgent agent;

    void Awake()
    {
        damageCooldown = new Timer(damageCooldownTime);
    }

    void Start()
    {
        gameObject.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        attackCooldownTimer = attackCooldown;
        anim = GetComponent<Animator>();
        agent = gameObject.GetComponentSafely<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }
    // Update is called once per frame
    void Update()
    {
        damageCooldown.Update();
        agent.SetDestination(target.transform.position);

        //If we can make it work 
        //anim.SetBool("BossAttack", false);
        //attackCooldownTimer -= Time.deltaTime;
        //if (Vector3.Distance(transform.position, target.position) < 5 && attackCooldownTimer <= 0 )
        //{
        //    anim.SetBool("BossAttack", true);
        //    attackCooldownTimer = attackCooldown;
        //}
    }

    private void OnCollisionStay(Collision other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealthManager>();        

        if (damageCooldown.IsComplete && playerHealth != null)
        {
            playerHealth.takeDamage(damage, this.gameObject);
            damageCooldown.Reset();
            damageCooldown.Unpause();
            MissiveAggregator.instance.Publish(new EnemyAttackEvent(transform.position));
        }
    }
}