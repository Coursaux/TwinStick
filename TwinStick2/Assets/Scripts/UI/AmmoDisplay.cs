using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    public Text ammo;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Inventory>().primary.itemType == ItemType.Pistol)
            ammo.text = player.GetComponent<Inventory>().currentPistolRounds + " / " + player.GetComponentInChildren<Gun>().data.unusedCapacity;
        if (player.GetComponent<Inventory>().primary.itemType == ItemType.Assault)
            ammo.text = player.GetComponent<Inventory>().currentAssaultRounds + " / " + player.GetComponentInChildren<Gun>().data.unusedCapacity;
        if (player.GetComponent<Inventory>().primary.itemType == ItemType.LMG)
            ammo.text = player.GetComponent<Inventory>().currentLMGRounds + " / " + player.GetComponentInChildren<Gun>().data.unusedCapacity;
        if (player.GetComponent<Inventory>().primary.itemType == ItemType.Sniper)
            ammo.text = player.GetComponent<Inventory>().currentSniperRounds + " / " + player.GetComponentInChildren<Gun>().data.unusedCapacity;
        if (player.GetComponent<Inventory>().primary.itemType == ItemType.Shotgun)
            ammo.text = player.GetComponent<Inventory>().currentShotgunRounds + " / " + player.GetComponentInChildren<Gun>().data.unusedCapacity;
    }
}
