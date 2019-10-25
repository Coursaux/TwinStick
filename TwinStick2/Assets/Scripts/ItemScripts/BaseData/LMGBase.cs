using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMGBase
{
    public int damageCap = 6;
    public int damageMin = 3;
    public float attackSpeedCap = 0.1f;
    public float attackSpeedMin = 0.2f;
    public float accuracyCap = 0.15f;
    public float accuracyMin = 0.35f;

    public int range = 20;
    public float reloadTime = 5;

    public int capacity = 50;
    public bool piercing = false;
    public bool stun = false;
    public bool knockback = false;
    public int spawnedItemSpeed = 2500; // look at feet per second for context
}
