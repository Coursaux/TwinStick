using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Item
{
    private float lastShot = -10f;

    public float ReloadStart;
    public bool Reloading = false;

    public void Fire()
    {
        if (data.UnusedCapacity > 0 && Time.time > data.AttackSpeed + lastShot)
        {
            Debug.Log(transform.rotation);
            GameObject bullet = Instantiate(data.SpawnedItem, transform.Find("Spawner").gameObject.transform.position, transform.rotation) as GameObject;
            bullet.GetComponent<Projectile>().SetDmg(data.Damage, data.Stun, data.StunLength, data.Knockback, data.KnockbackDistance, data.Piercing, data.ExplosionRadius);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * data.SpawnedItemSpeed + transform.right * Random.Range((-data.Accuracy * data.SpawnedItemSpeed), (data.Accuracy * data.SpawnedItemSpeed)));
            data.UnusedCapacity -= 1;
            if (data.UnusedCapacity == 0)
            {
                Reload();
            }

            lastShot = Time.time;
        }
        else if(data.UnusedCapacity == 0)
        {
            Reload();
        }
    }

    public void Reload()
    {
        if (!Reloading)
        {
            ReloadStart = Time.time;
            Reloading = true;
        }
    }
}