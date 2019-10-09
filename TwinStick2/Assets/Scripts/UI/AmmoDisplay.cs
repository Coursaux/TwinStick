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
        ammo.text = player.GetComponent<Inventory>().currentPistolRounds + " / " + player.GetComponentInChildren<Pistol>().data.unusedCapacity;
    }
}
