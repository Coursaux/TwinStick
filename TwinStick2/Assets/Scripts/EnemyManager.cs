using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform Player;     // reference to player
    int MoveSpeed = 7;
    int MinDist = 2;            // distance at which stops chasing player
    public int attackSpeed = 5;
    public int Damage = 25;
    public GameObject Spawner;

    private float time = -10f;//ATTACK SPEED TIMER
    private float stunTime = 0f;   //time enemy becomes unstunned

    private bool SpawnedLoot = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    // if not stunned, face and chase player
    void Update()
    {
        if (!this.GetComponent<HealthManager>().Dead)
        {
            if (Time.time > stunTime)
            {
                transform.LookAt(Player);

                if (Vector3.Distance(transform.position, Player.position) >= MinDist)
                {
                    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                }

                else if (Vector3.Distance(transform.position, Player.position) < MinDist + 1 && Time.time > time + attackSpeed)
                {
                    Player.GetComponent<HealthManager>().TakeDamage(Damage);
                    time = Time.time;
                }
            }
        }
        if (this.GetComponent<HealthManager>().Dead && !SpawnedLoot)
        {
            Instantiate(Spawner, transform.position, transform.rotation);
            //SpawnedLoot = true;
        }
    }

    // contains references to health manager for taking dmg on collision or other effects
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PlayerObject")
        {
            this.GetComponent<HealthManager>().TakeDamage(col.gameObject.GetComponent<PlayerObject>().Damage);
            if (col.gameObject.GetComponent<PlayerObject>().Knockback)
            {
                Knockback(col, col.gameObject.GetComponent<PlayerObject>().KnockbackDistance);
            }

            if (col.gameObject.GetComponent<PlayerObject>().Stun)
            {
                Stun(col.gameObject.GetComponent<PlayerObject>().StunLength);
            }
            
        }

    }

    //implements the knockback
    private void Knockback(Collider col, int KnockbackDistance)
    {
        Vector3 moveDirection = col.transform.position - this.transform.position;
        this.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * -KnockbackDistance);
    }

    //stuns the enemy
    private void Stun(float StunLength)
    {
        stunTime = Time.time + StunLength;
    }
}
