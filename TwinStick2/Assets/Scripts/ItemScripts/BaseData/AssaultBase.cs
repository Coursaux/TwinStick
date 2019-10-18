using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultBase
{
    public int damageCap = 9;
    public int damageMin = 5;
    public float attackSpeedCap = 0.05f;
    public float attackSpeedMin = 0.15f;
    public float accuracyCap = 0.15f;
    public float accuracyMin = 0.25f;

    public int range = 20;
    public float reloadTime = 3;

    public int capacity = 21;
    public bool piercing = false;
    public bool stun = false;
    public bool knockback = false;
    public int spawnedItemSpeed = 2500; // look at feet per second for context
}
