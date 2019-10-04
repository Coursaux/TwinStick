using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Item
{
    private float LastSwing = -10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Swing()
    {
        if (Time.time > data.AttackSpeed + LastSwing)
        {
            GameObject box = Instantiate(data.SpawnedItem, transform.position, transform.rotation) as GameObject;
            box.GetComponent<MeleeHitBox>().SetDmg(data.Damage, data.Stun, data.StunLength, data.Knockback, data.KnockbackDistance, data.Piercing, data.ExplosionRadius);
            LastSwing = Time.time;
        }
    }
}
