using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBase
{
    public int damageCap = 3;
    public int damageMin = 2;
    public float attackSpeedCap = 0.6f;
    public float attackSpeedMin = 0.4f;
    public float accuracyCap = 0.3f;
    public float accuracyMin = 0.5f;

    public int range = 20;
    public float reloadTime = 5;

    public int capacity = 8;
    public bool piercing = false;
    public bool stun = false;
    public bool knockback = false;
    public int spawnedItemSpeed = 2500; // look at feet per second for context
}
