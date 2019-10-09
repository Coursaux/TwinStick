﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform player;     // reference to player
    int moveSpeed = 7;
    int minDist = 2;            // distance at which stops chasing player
    public int attackSpeed = 5;
    public int damage = 25;
    public GameObject spawner;

    private float time = -10f;//ATTACK SPEED TIMER
    private float stunTime = 0f;   //time enemy becomes unstunned

    private bool spawnedLoot = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    // if not stunned, face and chase player
    void Update()
    {
        if (!this.GetComponent<HealthManager>().dead)
        {
            if (Time.time > stunTime)
            {
                transform.LookAt(player);

                if (Vector3.Distance(transform.position, player.position) >= minDist)
                {
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                }

                else if (Vector3.Distance(transform.position, player.position) < minDist + 1 && Time.time > time + attackSpeed)
                {
                    player.GetComponent<HealthManager>().TakeDamage(damage);
                    time = Time.time;
                }
            }
        }
        if (this.GetComponent<HealthManager>().dead && !spawnedLoot)
        {
            Instantiate(spawner, transform.position, transform.rotation);
            spawnedLoot = true;
        }
    }

    // contains references to health manager for taking dmg on collision or other effects
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PlayerObject")
        {
            this.GetComponent<HealthManager>().TakeDamage(col.gameObject.GetComponent<PlayerObject>().damage);
            if (col.gameObject.GetComponent<PlayerObject>().knockback)
            {
                Knockback(col, col.gameObject.GetComponent<PlayerObject>().knockbackDistance);
            }

            if (col.gameObject.GetComponent<PlayerObject>().stun)
            {
                Stun(col.gameObject.GetComponent<PlayerObject>().stunLength);
            }
            
        }

    }

    //implements the knockback
    private void Knockback(Collider col, int knockbackDistance)
    {
        Vector3 moveDirection = col.transform.position - this.transform.position;
        this.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * -knockbackDistance);
    }

    //stuns the enemy
    private void Stun(float stunLength)
    {
        stunTime = Time.time + stunLength;
    }
}
