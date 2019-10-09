using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public GameObject pistolModel;
    public ItemData data = new ItemData();
    public GameObject bullet;

    private PistolBase basePistol = new PistolBase();

    public void SetType(ItemType itemType)
    {
        if (itemType == ItemType.Pistol)
        {
            GameObject item = Instantiate(pistolModel, transform.position, transform.rotation) as GameObject;
            item.transform.parent = this.transform;
            data.itemType = itemType;
            data.damage = Random.Range(basePistol.damageMin, basePistol.damageCap + 1);
            data.attackSpeed = Random.Range(basePistol.attackSpeedMin, basePistol.attackSpeedCap);
            data.accuracy = Random.Range(basePistol.accuracyMin, basePistol.accuracyCap + 1);
            data.range = basePistol.range;
            data.reloadTime = basePistol.reloadTime;
            data.capacity = basePistol.capacity;
            data.unusedCapacity = basePistol.capacity;
            data.spawnedItemSpeed = basePistol.spawnedItemSpeed;
            data.spawnedItem = bullet;
        }
    }

    public void PickUp()
    {
        bool pickedUp = Inventory.instance.Add(data);
        if (pickedUp)
            Destroy(this.gameObject);
    }
}


/*
        string Name, 
        Sprite Image, 
        itemtype ItemType,
        int Damage,
        float AttackSpeed,
        int Capacity,
        int UnusedCapacity,
        bool Stun,
        int StunLength,
        bool Knockback,
        int KnockbackDistance,
        int SpawnedItemSpeed,
        GameObject SpawnedItem)
        */