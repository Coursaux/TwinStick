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

    public int TotalGrenades;
    public int CurrentGrenades;

    public int TotalPistolRounds;
    public int CurrentPistolRounds;

    public int TotalShotgunRounds;
    public int CurrentShotgunRounds;

    public int TotalAssaultRounds;
    public int CurrentAssaultRounds;

    public int TotalLMGounds;
    public int CurrentLMGRounds;

    public int TotalSniperRounds;
    public int CurrentSniperRounds;

    public void Add(ItemData item)
    {
        items.Add(item);
    }

    public void Remove(ItemData item)
    {
        items.Remove(item);
    }
}
