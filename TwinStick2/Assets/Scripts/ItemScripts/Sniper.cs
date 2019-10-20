using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Gun
{
    void Update()
    {
        if (Time.time > reloadStart + data.reloadTime && reloading)
        {
            if (GetComponentInParent<Inventory>().currentSniperRounds < data.capacity)
            {
                data.unusedCapacity = GetComponentInParent<Inventory>().currentSniperRounds;
                GetComponentInParent<Inventory>().currentSniperRounds = 0;
            }
            else
            {
                data.unusedCapacity = data.capacity;
                GetComponentInParent<Inventory>().currentSniperRounds -= data.capacity;
            }
            reloading = false;
        }
    }
}
