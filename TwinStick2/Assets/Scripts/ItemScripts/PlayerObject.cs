using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public bool Stun;
    public float StunLength;
    public bool Knockback;
    public int KnockbackDistance;
    public int Damage;
    public bool Piercing;
    public int ExplosionRadius;

    public void SetDmg(int _dmg, bool _Stun, float _StunLength, bool _Knockback, int _KnockbackDistance, bool _Piercing, int _ExplosionRadius)
    {
        Damage = _dmg;
        Stun = _Stun;
        StunLength = _StunLength;
        Knockback = _Knockback;
        KnockbackDistance = _KnockbackDistance;
        Piercing = _Piercing;
        ExplosionRadius = _ExplosionRadius;
    }
}
