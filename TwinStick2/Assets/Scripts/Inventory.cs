using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{
    #region singleton

    public static Inventory instance;

    void awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("more than one instance of inventory");
            return;
        }
        instance = this;
    }
    #endregion

    public List<ItemData> items = new List<ItemData>();

    public int totalGrenades;
    public int currentGrenades;

    public int totalPistolRounds;
    public int currentPistolRounds;

    public int totalShotgunRounds;
    public int currentShotgunRounds;

    public int totalAssaultRounds;
    public int currentAssaultRounds;

    public int totalLMGounds;
    public int currentLMGRounds;

    public int totalSniperRounds;
    public int currentSniperRounds;

    public ItemData primary = null;
    public ItemData secondary;
    public ItemData equippedGrenade;
    public ItemData equippedMelee;

    public int space = 20;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public delegate void OnWeaponChange();
    public OnWeaponChange onWeaponChangedCallback;

    public GameObject pistol;
    public GameObject assault;
    public GameObject LMG;
    public GameObject Sniper;
    public GameObject Shotgun;

    float switchTime = -10f;

    void Start()
    {

    }

    public bool Add(ItemData item)
    {
        if (secondary.damage == 0)
        {
            
            secondary = item;
            return true;
        }
        if (items.Count >= space)
        {
            return false;
        }
        items.Add(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        return true;
    }

    public void Remove(ItemData item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    // spaghetti
    public ItemData Equip(ItemData item)
    {
        ItemData temp = null;
        ItemType type = primary.itemType;
        if (item != null)
        {
            if (primary != null)
            {
                string sType = type.ToString();
                Destroy(GameObject.Find(sType + "(Clone)"));
            }
            GameObject gun = null;
            if (item.itemType == ItemType.Pistol)
            {
                gun = Instantiate(pistol, transform.Find("GunPlacement").gameObject.transform.position, transform.rotation) as GameObject;
            }
            else if (item.itemType == ItemType.Assault)
            {
                gun = Instantiate(assault, transform.Find("GunPlacement").gameObject.transform.position, transform.rotation) as GameObject;
            }
            else if (item.itemType == ItemType.LMG)
            {
                gun = Instantiate(LMG, transform.Find("GunPlacement").gameObject.transform.position, transform.rotation) as GameObject;
            }
            else if (item.itemType == ItemType.Sniper)
            {
                gun = Instantiate(Sniper, transform.Find("GunPlacement").gameObject.transform.position, transform.rotation) as GameObject;
            }
            else if (item.itemType == ItemType.Shotgun)
            {
                gun = Instantiate(Shotgun, transform.Find("GunPlacement").gameObject.transform.position, transform.rotation) as GameObject;
            }
            gun.transform.SetParent(transform.Find("GunPlacement"));
            gun.GetComponent<Gun>().data = item;

            temp = primary;
            primary = item;
            if (onWeaponChangedCallback != null)
                onWeaponChangedCallback.Invoke();
        }
        return temp;

    }

    public void SwitchWeapons()
    {
        if (Time.time > switchTime)
        {
            switchTime = Time.time + 0.2f;
            ItemType type = primary.itemType;
            if (secondary != null)
            {
                if (primary != null)
                {
                    string sType = type.ToString();
                    Destroy(GameObject.Find(sType + "(Clone)"));
                }
                GameObject gun = null;
                if (secondary.itemType == ItemType.Pistol)
                {
                    gun = Instantiate(pistol, transform.Find("GunPlacement").gameObject.transform.position, transform.rotation) as GameObject;
                }
                else if (secondary.itemType == ItemType.Assault)
                {
                    gun = Instantiate(assault, transform.Find("GunPlacement").gameObject.transform.position, transform.rotation) as GameObject;
                }
                else if (secondary.itemType == ItemType.LMG)
                {
                    gun = Instantiate(LMG, transform.Find("GunPlacement").gameObject.transform.position, transform.rotation) as GameObject;
                }
                else if (secondary.itemType == ItemType.Sniper)
                {
                    gun = Instantiate(Sniper, transform.Find("GunPlacement").gameObject.transform.position, transform.rotation) as GameObject;
                }
                else if (secondary.itemType == ItemType.Shotgun)
                {
                    gun = Instantiate(Shotgun, transform.Find("GunPlacement").gameObject.transform.position, transform.rotation) as GameObject;
                }
                gun.transform.SetParent(transform.Find("GunPlacement"));

                ItemData temp;
                temp = primary;
                primary = secondary;
                secondary = temp;
                if (onWeaponChangedCallback != null)
                    onWeaponChangedCallback.Invoke();
            }
        }
    }
}
