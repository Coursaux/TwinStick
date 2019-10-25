using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject pistolModel;
    public GameObject assaultModel;
    public GameObject LMGModel;
    public GameObject SniperModel;
    public GameObject ShotgunModel;

    public ItemData data = new ItemData();
    public GameObject bullet;

    private PistolBase basePistol = new PistolBase();
    private AssaultBase baseAssault = new AssaultBase();
    private LMGBase baseLMG = new LMGBase();
    private SniperBase baseSniper = new SniperBase();
    private ShotgunBase baseShotgun = new ShotgunBase();

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
            data.damage = Random.Range(baseAssault.damageMin, baseAssault.damageCap + 1);
            data.attackSpeed = Random.Range(baseAssault.attackSpeedMin, baseAssault.attackSpeedCap);
            data.accuracy = Random.Range(baseAssault.accuracyMin, baseAssault.accuracyCap);
            data.range = baseAssault.range;
            data.reloadTime = baseAssault.reloadTime; data.capacity = baseAssault.capacity;
            data.unusedCapacity = baseAssault.capacity;
            data.spawnedItemSpeed = baseAssault.spawnedItemSpeed;
            data.spawnedItem = bullet;
        }
        else if (itemType == ItemType.LMG)
        {
            GameObject item = Instantiate(LMGModel, transform.position, transform.rotation) as GameObject;
            item.transform.parent = this.transform;
            data.name = "LMG";
            data.itemType = itemType;
            data.damage = Random.Range(baseLMG.damageMin, baseLMG.damageCap + 1);
            data.attackSpeed = Random.Range(baseLMG.attackSpeedMin, baseLMG.attackSpeedCap);
            data.accuracy = Random.Range(baseLMG.accuracyMin, baseLMG.accuracyCap);
            data.range = baseLMG.range;
            data.reloadTime = baseLMG.reloadTime; data.capacity = baseLMG.capacity;
            data.unusedCapacity = baseLMG.capacity;
            data.spawnedItemSpeed = baseLMG.spawnedItemSpeed;
            data.spawnedItem = bullet;
        }
        else if (itemType == ItemType.Sniper)
        {
            GameObject item = Instantiate(SniperModel, transform.position, transform.rotation) as GameObject;
            item.transform.parent = this.transform;
            data.name = "Sniper Rifle";
            data.itemType = itemType;
            data.damage = Random.Range(baseSniper.damageMin, baseSniper.damageCap + 1);
            data.attackSpeed = Random.Range(baseSniper.attackSpeedMin, baseSniper.attackSpeedCap);
            data.accuracy = Random.Range(baseSniper.accuracyMin, baseSniper.accuracyCap);
            data.range = baseSniper.range;
            data.reloadTime = baseSniper.reloadTime; data.capacity = baseSniper.capacity;
            data.unusedCapacity = baseSniper.capacity;
            data.spawnedItemSpeed = baseSniper.spawnedItemSpeed;
            data.spawnedItem = bullet;
            data.piercing = baseSniper.piercing;
        }
        else if (itemType == ItemType.Shotgun)
        {
            GameObject item = Instantiate(ShotgunModel, transform.position, transform.rotation) as GameObject;
            item.transform.parent = this.transform;
            data.name = "Shotgun";
            data.itemType = itemType;
            data.damage = Random.Range(baseShotgun.damageMin, baseShotgun.damageCap + 1);
            data.attackSpeed = Random.Range(baseShotgun.attackSpeedMin, baseShotgun.attackSpeedCap);
            data.accuracy = Random.Range(baseShotgun.accuracyMin, baseShotgun.accuracyCap);
            data.range = baseShotgun.range;
            data.reloadTime = baseShotgun.reloadTime; data.capacity = baseShotgun.capacity;
            data.unusedCapacity = baseShotgun.capacity;
            data.spawnedItemSpeed = baseShotgun.spawnedItemSpeed;
            data.spawnedItem = bullet;
            data.piercing = baseShotgun.piercing;
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