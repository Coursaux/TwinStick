using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitBox : PlayerObject
{
    private float timeSpawned;
    private float length = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        timeSpawned = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeSpawned + length)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetDmg(int _dmg, bool _Stun, bool _Knockback)
    {
        dmg = _dmg;
        Stun = _Stun;
        Knockback = _Knockback;
    }
}
