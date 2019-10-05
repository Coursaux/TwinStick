using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBase
{
    public int DamageCap = 7;
    public int DamageMin = 3;
    public float AttackSpeedCap = 0.10f;
    public float AttackSpeedMin = 0.20f;
    public float AccuracyCap = 0.15f;
    public float AccuracyMin = 0.25f;

    public int Range = 20;
    public float ReloadTime = 2;

    public int Capacity = 9;
    public bool Piercing = false;
    public bool Stun = false;
    public bool Knockback = false;
    public int SpawnedItemSpeed = 900; // look at feet per second for context
}
