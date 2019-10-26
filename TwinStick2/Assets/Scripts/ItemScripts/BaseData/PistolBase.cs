using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBase
{
    public int damageCap = 7;
    public int damageMin = 4;
    public float attackSpeedCap = 0.20f;
    public float attackSpeedMin = 0.30f;
    public float accuracyCap = 0.15f;
    public float accuracyMin = 0.25f;

    public int range = 20;
    public float reloadTime = 2;

    public int capacity = 9;
    public bool piercing = false;
    public bool stun = false;
    public bool knockback = false;
    public int spawnedItemSpeed = 2000; // look at feet per second for context
}
