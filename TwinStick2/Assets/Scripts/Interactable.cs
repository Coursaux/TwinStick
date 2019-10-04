using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public GameObject PistolModel;
    public ItemData Data = new ItemData();

    //private PistolBaseData BasePistol;

    public void SetType(itemtype ItemType)
    {
        if ( true) // ItemType == itemtype.pistol)
        {
            GameObject item = Instantiate(PistolModel, transform.position, transform.rotation) as GameObject;
            item.transform.parent = this.transform;
        }
    }

    public void PickUp()
    {
        Inventory.instance.Add(Data);
        DestroyImmediate(this.gameObject);
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