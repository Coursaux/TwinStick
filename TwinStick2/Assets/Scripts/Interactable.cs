using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public GameObject PistolModel;
    public ItemData Data = new ItemData();
    public GameObject Bullet;

    private PistolBase BasePistol = new PistolBase();

    public void SetType(itemtype ItemType)
    {
        if (ItemType == itemtype.pistol)
        {
            GameObject item = Instantiate(PistolModel, transform.position, transform.rotation) as GameObject;
            item.transform.parent = this.transform;
            Data.ItemType = ItemType;
            Data.Damage = Random.Range(BasePistol.DamageMin, BasePistol.DamageCap + 1);
            Data.AttackSpeed = Random.Range(BasePistol.AttackSpeedMin, BasePistol.AttackSpeedCap);
            Data.Accuracy = Random.Range(BasePistol.AccuracyMin, BasePistol.AccuracyCap + 1);
            Data.Range = BasePistol.Range;
            Data.ReloadTime = BasePistol.ReloadTime;
            Data.Capacity = BasePistol.Capacity;
            Data.UnusedCapacity = BasePistol.Capacity;
            Data.SpawnedItemSpeed = BasePistol.SpawnedItemSpeed;
            Data.SpawnedItem = Bullet;
        }
    }

    public void PickUp()
    {
        Inventory.instance.Add(Data);
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