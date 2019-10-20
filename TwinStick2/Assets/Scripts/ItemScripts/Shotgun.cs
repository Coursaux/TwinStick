using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    void Update()
    {
        if (Time.time > reloadStart + data.reloadTime && reloading)
        {
            if (GetComponentInParent<Inventory>().currentShotgunRounds < data.capacity)
            {
                data.unusedCapacity = GetComponentInParent<Inventory>().currentShotgunRounds;
                GetComponentInParent<Inventory>().currentShotgunRounds = 0;
            }
            else
            {
                data.unusedCapacity = data.capacity;
                GetComponentInParent<Inventory>().currentShotgunRounds -= data.capacity;
            }
            reloading = false;
        }
    }

    public override void Fire()
    {
        if (data.unusedCapacity > 0 && Time.time > data.attackSpeed + lastShot)
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject bullet = Instantiate(data.spawnedItem, transform.Find("Spawner").gameObject.transform.position, transform.rotation) as GameObject;
                bullet.GetComponent<Projectile>().SetDmg(data.damage, data.stun, data.stunLength, data.knockback, data.knockbackDistance, data.piercing, data.explosionRadius);
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * data.spawnedItemSpeed + transform.right * Random.Range((-data.accuracy * data.spawnedItemSpeed), (data.accuracy * data.spawnedItemSpeed)));
            }
            data.unusedCapacity -= 1;
            if (data.unusedCapacity == 0)
            {
                Reload();
            }

            lastShot = Time.time;
        }
        else if (data.unusedCapacity == 0)
        {
            Reload();
        }
    }
}
