using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform Player;     // reference to player
    int MoveSpeed = 7;
    int MinDist = 3;            // distance at which stops chasing player
    public int attackSpeed = 5;
    public int Damage = 25;

    private float time = -10f;//ATTACK SPEED TIMER
    private float stunTime = 0f;   //time enemy becomes unstunned
    private float stunLength = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > stunTime)
        {
            transform.LookAt(Player);

            if (Vector3.Distance(transform.position, Player.position) >= MinDist)
            {
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }

            else if (Vector3.Distance(transform.position, Player.position) < MinDist + 2 && Time.time > time + attackSpeed)
            {
                Player.GetComponent<HealthManager>().TakeDamage(Damage);
                time = Time.time;
            }
        }
    }

    // contains references to health manager for taking dmg on collision or other effects
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PlayerObject")
        {
            this.GetComponent<HealthManager>().TakeDamage(col.gameObject.GetComponent<PlayerObject>().dmg);
            if (col.gameObject.GetComponent<PlayerObject>().Knockback)
            {
                Knockback(col);
            }

            if (col.gameObject.GetComponent<PlayerObject>().Stun)
            {
                Debug.Log("Stunned");
                Stun();
            }
        }

    }

    //implements the knockback
    private void Knockback(Collider col)
    {
        Vector3 moveDirection = col.transform.position - this.transform.position;
        this.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * -200f);
    }

    //stuns the enemy
    private void Stun()
    {
        stunTime = Time.time + stunLength;
    }
}
