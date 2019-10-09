using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public bool stun;
    public float stunLength;
    public bool knockback;
    public int knockbackDistance;
    public int damage;
    public bool piercing;
    public int explosionRadius;

    public void SetDmg(int _dmg, bool _Stun, float _StunLength, bool _Knockback, int _KnockbackDistance, bool _Piercing, int _ExplosionRadius)
    {
        damage = _dmg;
        stun = _Stun;
        stunLength = _StunLength;
        knockback = _Knockback;
        knockbackDistance = _KnockbackDistance;
        piercing = _Piercing;
        explosionRadius = _ExplosionRadius;
    }
}
