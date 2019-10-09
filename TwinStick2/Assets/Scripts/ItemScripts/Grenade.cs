using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Item
{
    private float lastThrow = -10f;

    public void Throw()
    {
        if (Time.time > data.attackSpeed + lastThrow)
        {
            if (GetComponentInParent<Inventory>().currentGrenades > 0)
            {
                GameObject grenade = Instantiate(data.spawnedItem, transform.position, transform.rotation) as GameObject;
                grenade.GetComponent<ThrownGrenade>().SetDmg(data.damage, data.stun, data.stunLength, data.knockback, data.knockbackDistance, data.piercing, data.explosionRadius);
                grenade.GetComponent<Rigidbody>().AddForce(transform.forward * data.spawnedItemSpeed + transform.up * data.spawnedItemSpeed);
                GetComponentInParent<Inventory>().currentGrenades -= 1;
                lastThrow = Time.time;
            }
        }
    }
}