using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMG : Gun
{
    void Update()
    {
        if (Time.time > reloadStart + data.reloadTime && reloading)
        {
            if (GetComponentInParent<Inventory>().currentLMGRounds < data.capacity)
            {
                data.unusedCapacity = GetComponentInParent<Inventory>().currentLMGRounds;
                GetComponentInParent<Inventory>().currentLMGRounds = 0;
            }
            else
            {
                data.unusedCapacity = data.capacity;
                GetComponentInParent<Inventory>().currentLMGRounds -= data.capacity;
            }
            reloading = false;
        }
    }
}
