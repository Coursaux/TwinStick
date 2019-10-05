using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// data class for items
[System.Serializable]
public class ItemData
{
    public string Name;
    public Sprite Image;

    public itemtype ItemType;
    public rarity Rarity;

    public int Damage;
    public float AttackSpeed;
    public int Capacity;
    public int UnusedCapacity; // amount left in clip
    public float Accuracy;
    public int Range;
    public bool Piercing;
    public float ReloadTime;
    public bool Stun;
    public float StunLength;
    public bool Knockback;
    public int KnockbackDistance;

    public int ExplosionRadius;


    public int SpawnedItemSpeed; // look at feet per second for context
    public GameObject SpawnedItem; // bullets or hitboxes
}

public enum rarity
{
    standard,
    rare,
    epic,
    legendary
}

public enum itemtype
{
    pistol,
    assault,
    LMG,
    sniper,
    shotgun,
    grenade,
    sword,
    bat,
    other
};
