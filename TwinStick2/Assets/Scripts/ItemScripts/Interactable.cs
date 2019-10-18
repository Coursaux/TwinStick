using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject pistolModel;
    public GameObject assaultModel;
    public ItemData data = new ItemData();
    public GameObject bullet;

    private PistolBase basePistol = new PistolBase();
    private AssaultBase baseAssault = new AssaultBase();

    public void SetType(ItemType itemType)
    {
        if (itemType == ItemType.Pistol)
        {
            GameObject item = Instantiate(pistolModel, transform.position, transform.rotation) as GameObject;
            item.transform.parent = this.transform;
            data.name = "Pistol";
            data.itemType = itemType;
            data.damage = Random.Range(basePistol.damageMin, basePistol.damageCap + 1);
            data.attackSpeed = Random.Range(basePistol.attackSpeedMin, basePistol.attackSpeedCap);
            data.accuracy = Random.Range(basePistol.accuracyMin, basePistol.accuracyCap);
            data.range = basePistol.range;
            data.reloadTime = basePistol.reloadTime; data.capacity = basePistol.capacity;
            data.unusedCapacity = basePistol.capacity;
            data.spawnedItemSpeed = basePistol.spawnedItemSpeed;
            data.spawnedItem = bullet;
        }
        else if (itemType == ItemType.Assault)
        {
            GameObject item = Instantiate(assaultModel, transform.position, transform.rotation) as GameObject;
            item.transform.parent = this.transform;
            data.name = "Assault Rifle";
            data.itemType = itemType;
            Debug.Log(data.itemType);
            data.damage = Random.Range(baseAssault.damageMin, baseAssault.damageCap + 1);
            data.attackSpeed = Random.Range(baseAssault.attackSpeedMin, baseAssault.attackSpeedCap);
            data.accuracy = Random.Range(baseAssault.accuracyMin, baseAssault.accuracyCap);
            data.range = baseAssault.range;
            data.reloadTime = baseAssault.reloadTime; data.capacity = baseAssault.capacity;
            data.unusedCapacity = baseAssault.capacity;
            data.spawnedItemSpeed = baseAssault.spawnedItemSpeed;
            data.spawnedItem = bullet;
        }
    }

    public void PickUp()
    {
        //bool pickedUp = Inventory.instance.Add(data);
        bool pickedUp = GameObject.Find("Player").GetComponent<Inventory>().Add(data);
        if (pickedUp)
            Destroy(this.gameObject);
    }
}