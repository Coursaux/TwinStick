using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform Player;
    int MoveSpeed = 7;
    int MinDist = 2;
    public int attackSpeed = 5;
    public int Damage = 25;

    private float time = -10f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PlayerObject")
        {
            this.GetComponent<HealthManager>().TakeDamage(col.gameObject.GetComponent<Projectile>().dmg);
        }

    }
}
