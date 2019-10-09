using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Item
{
    private float lastSwing = -10f;

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
        if (Time.time > data.attackSpeed + lastSwing)
        {
            GameObject box = Instantiate(data.spawnedItem, transform.position, transform.rotation) as GameObject;
            box.GetComponent<MeleeHitBox>().SetDmg(data.damage, data.stun, data.stunLength, data.knockback, data.knockbackDistance, data.piercing, data.explosionRadius);
            lastSwing = Time.time;
        }
    }
}
