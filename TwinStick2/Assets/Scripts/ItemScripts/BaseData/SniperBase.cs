using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBase
{
    public int damageCap = 12;
    public int damageMin = 8;
    public float attackSpeedCap = 0.7f;
    public float attackSpeedMin = 0.50f;
    public float accuracyCap = 0.05f;
    public float accuracyMin = 0.10f;

    public int range = 20;
    public float reloadTime = 2;

    public int capacity = 5;
    public bool piercing = true;
    public bool stun = false;
    public bool knockback = false;
    public int spawnedItemSpeed = 3000; // look at feet per second for context
}
