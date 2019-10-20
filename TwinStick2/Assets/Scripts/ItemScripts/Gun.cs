using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Item
{
    [HideInInspector] public float lastShot = -10f;

    public float reloadStart;
    public bool reloading = false;

    public virtual void Fire()
    {
        if (data.unusedCapacity > 0 && Time.time > data.attackSpeed + lastShot)
        {
            GameObject bullet = Instantiate(data.spawnedItem, transform.Find("Spawner").gameObject.transform.position, transform.rotation) as GameObject;
            bullet.GetComponent<Projectile>().SetDmg(data.damage, data.stun, data.stunLength, data.knockback, data.knockbackDistance, data.piercing, data.explosionRadius);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * data.spawnedItemSpeed + transform.right * Random.Range((-data.accuracy * data.spawnedItemSpeed), (data.accuracy * data.spawnedItemSpeed)));
            data.unusedCapacity -= 1;
            if (data.unusedCapacity == 0)
            {
                Reload();
            }

            lastShot = Time.time;
        }
        else if(data.unusedCapacity == 0)
        {
            Reload();
        }
    }

    public void Reload()
    {
        if (!reloading)
        {
            reloadStart = Time.time;
            reloading = true;
        }
    }
}