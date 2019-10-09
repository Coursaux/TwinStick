using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    void Update()
    {
        if (Time.time > reloadStart + data.reloadTime && reloading)
        {
            if (GetComponentInParent<Inventory>().currentPistolRounds < data.capacity)
            {
                data.unusedCapacity = GetComponentInParent<Inventory>().currentPistolRounds;
                GetComponentInParent<Inventory>().currentPistolRounds = 0;
            }
            else
            {
                data.unusedCapacity = data.capacity;
                GetComponentInParent<Inventory>().currentPistolRounds -= data.capacity;
            }
            reloading = false;
        }
    }
}
