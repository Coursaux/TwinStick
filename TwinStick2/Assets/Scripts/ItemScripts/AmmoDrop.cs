using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{
    public int amount;
    public ItemType type;

    // Start is called before the first frame update
    void Start()
    {
        type = (ItemType)Random.Range(0, 6);
        if (type == ItemType.Pistol)
        {
            amount = Random.Range(1, 10);
        }
        else if (type == ItemType.Assault)
        {
            amount = Random.Range(1, 22);
        }
        else if (type == ItemType.LMG)
        {
            amount = Random.Range(1, 51);
        }
        else if (type == ItemType.Sniper)
        {
            amount = Random.Range(1, 6);
        }
        else if (type == ItemType.Shotgun)
        {
            amount = Random.Range(1, 9);
        }
        else if (type == ItemType.Grenade)
        {
            amount = 1;
        }
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log(type + " " + amount);
            if (type == ItemType.Pistol)
            {
                if (col.GetComponent<Inventory>().currentPistolRounds + amount > col.GetComponent<Inventory>().totalPistolRounds)
                {
                    col.GetComponent<Inventory>().currentPistolRounds = col.GetComponent<Inventory>().totalPistolRounds;
                }
                else
                {
                    col.GetComponent<Inventory>().currentPistolRounds += amount;
                }
            }

            else if (type == ItemType.Assault)
            {
                if (col.GetComponent<Inventory>().currentAssaultRounds + amount > col.GetComponent<Inventory>().totalAssaultRounds)
                {
                    col.GetComponent<Inventory>().currentAssaultRounds = col.GetComponent<Inventory>().totalAssaultRounds;
                }
                else
                {
                    col.GetComponent<Inventory>().currentAssaultRounds += amount;
                }
            }

            else if (type == ItemType.LMG)
            {
                if (col.GetComponent<Inventory>().currentLMGRounds + amount > col.GetComponent<Inventory>().totalLMGRounds)
                {
                    col.GetComponent<Inventory>().currentLMGRounds = col.GetComponent<Inventory>().totalLMGRounds;
                }
                else
                {
                    col.GetComponent<Inventory>().currentLMGRounds += amount;
                }
            }

            else if (type == ItemType.Sniper)
            {
                if (col.GetComponent<Inventory>().currentSniperRounds + amount > col.GetComponent<Inventory>().totalSniperRounds)
                {
                    col.GetComponent<Inventory>().currentSniperRounds = col.GetComponent<Inventory>().totalSniperRounds;
                }
                else
                {
                    col.GetComponent<Inventory>().currentSniperRounds += amount;
                }
            }

            else if (type == ItemType.Shotgun)
            {
                if (col.GetComponent<Inventory>().currentShotgunRounds + amount > col.GetComponent<Inventory>().totalShotgunRounds)
                {
                    col.GetComponent<Inventory>().currentShotgunRounds = col.GetComponent<Inventory>().totalShotgunRounds;
                }
                else
                {
                    col.GetComponent<Inventory>().currentShotgunRounds += amount;
                }
            }

            else if (type == ItemType.Grenade)
            {
                if (col.GetComponent<Inventory>().currentGrenades + amount > col.GetComponent<Inventory>().totalGrenades)
                {
                    col.GetComponent<Inventory>().currentGrenades = col.GetComponent<Inventory>().totalGrenades;
                }
                else
                {
                    col.GetComponent<Inventory>().currentGrenades += amount;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
