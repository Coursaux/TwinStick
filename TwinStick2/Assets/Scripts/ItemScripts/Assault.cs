using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assault : Gun
{
    void Update()
    {
        if (Time.time > reloadStart + data.reloadTime && reloading)
        {
            if (GetComponentInParent<Inventory>().currentAssaultRounds < data.capacity)
            {
                data.unusedCapacity = GetComponentInParent<Inventory>().currentAssaultRounds;
                GetComponentInParent<Inventory>().currentAssaultRounds = 0;
            }
            else
            {
                data.unusedCapacity = data.capacity;
                GetComponentInParent<Inventory>().currentAssaultRounds -= data.capacity;
            }
            reloading = false;
        }
    }
}
