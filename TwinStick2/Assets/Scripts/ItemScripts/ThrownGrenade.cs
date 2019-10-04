using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownGrenade : PlayerObject
{
    private float TimeThrown;
    private int FuseLength = 2;

    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        TimeThrown = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > TimeThrown + FuseLength)
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, ExplosionRadius);
            foreach (Collider hit in colliders)
            {
                if (!hit.isTrigger)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        rb.AddExplosionForce(KnockbackDistance, explosionPos, ExplosionRadius, 3.0F);
                    }

                    if (hit.tag == "Enemy")
                    {
                        Debug.Log("Hit");
                        hit.GetComponent<HealthManager>().TakeDamage(Damage);
                    }
                }
            }
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
