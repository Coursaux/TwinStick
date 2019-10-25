using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownGrenade : PlayerObject
{
    private float timeThrown;
    private int fuseLength = 2;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        timeThrown = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeThrown + fuseLength)
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            foreach (Collider hit in colliders)
            {
                if (!hit.isTrigger)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        rb.AddExplosionForce(knockbackDistance, explosionPos, explosionRadius, 3.0F);
                    }

                    if (hit.tag == "Enemy")
                    {
                        hit.GetComponent<HealthManager>().TakeDamage(damage);
                    }
                }
            }
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
