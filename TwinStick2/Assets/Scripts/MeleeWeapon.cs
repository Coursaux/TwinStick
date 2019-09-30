using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{

    public int Dmg;
    public float attackSpeed;
    public bool Stun;
    public bool KnockBack;

    private float LastSwing = -10f;

    public GameObject Hitbox;

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
        if (Time.time > attackSpeed + LastSwing)
        {
            GameObject box = Instantiate(Hitbox, transform.position, transform.rotation) as GameObject;
            box.GetComponent<MeleeHitBox>().SetDmg(Dmg, Stun, KnockBack);
            LastSwing = Time.time;
        }
    }
}
