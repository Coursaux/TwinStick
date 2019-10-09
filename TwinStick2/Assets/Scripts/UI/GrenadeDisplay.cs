using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeDisplay : MonoBehaviour
{
    public Text grenades;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        grenades.text = "Grenades: " + player.GetComponent<Inventory>().currentGrenades;
    }
}
