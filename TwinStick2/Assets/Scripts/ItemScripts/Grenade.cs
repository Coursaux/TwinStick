using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Item
{
    private float lastThrow = -10f;

    public void Throw()
    {
        if (Time.time > data.AttackSpeed + lastThrow)
        {
            if (GetComponentInParent<Inventory>().CurrentGrenades > 0)
            {
                GameObject grenade = Instantiate(data.SpawnedItem, transform.position, transform.rotation) as GameObject;
                grenade.GetComponent<ThrownGrenade>().SetDmg(data.Damage, data.Stun, data.StunLength, data.Knockback, data.KnockbackDistance, data.Piercing, data.ExplosionRadius);
                grenade.GetComponent<Rigidbody>().AddForce(transform.forward * data.SpawnedItemSpeed + transform.up * data.SpawnedItemSpeed);
                GetComponentInParent<Inventory>().CurrentGrenades -= 1;
                lastThrow = Time.time;
            }
        }
    }
}