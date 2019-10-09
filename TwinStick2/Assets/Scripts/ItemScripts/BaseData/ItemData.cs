using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// data class for items
[System.Serializable]
public class ItemData
{
    public string name;
    public Sprite image;

    public ItemType itemType;
    public Rarity rarity;

    public int damage;
    public float attackSpeed;
    public int capacity;
    public int unusedCapacity; // amount left in clip
    public float accuracy;
    public int range;
    public bool piercing;
    public float reloadTime;
    public bool stun;
    public float stunLength;
    public bool knockback;
    public int knockbackDistance;

    public int explosionRadius;


    public int spawnedItemSpeed; // look at feet per second for context
    public GameObject spawnedItem; // bullets or hitboxes
}

public enum Rarity
{
    standard,
    rare,
    epic,
    legendary
}

public enum ItemType
{
    Pistol,
    Assault,
    LMG,
    Sniper,
    Shotgun,
    Grenade,
    Sword,
    Bat,
    Other
};
