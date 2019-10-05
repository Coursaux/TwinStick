using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    void Update()
    {
        if (Time.time > ReloadStart + data.ReloadTime && Reloading)
        {
            if (GetComponentInParent<Inventory>().CurrentPistolRounds < data.Capacity)
            {
                data.UnusedCapacity = GetComponentInParent<Inventory>().CurrentPistolRounds;
                GetComponentInParent<Inventory>().CurrentPistolRounds = 0;
            }
            else
            {
                data.UnusedCapacity = data.Capacity;
                GetComponentInParent<Inventory>().CurrentPistolRounds -= data.Capacity;
            }
            Reloading = false;
        }
    }
}
