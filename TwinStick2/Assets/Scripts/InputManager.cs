using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool inventoryOpen = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.controller)
        {
            if (Input.GetAxis("RightTrigger") > 0)
            {
                GetComponentInChildren<Gun>().Fire();
            }

            if (Input.GetAxis("LeftTrigger") > 0)
            {
                GetComponentInChildren<MeleeWeapon>().Swing();
            }

            if (Input.GetButtonDown("LeftBumper"))
            {
                GetComponentInChildren<Grenade>().Throw();
            }

            if (Input.GetButtonDown("RightBumper"))
            {
                GetComponentInChildren<Gun>().Reload();
            }

            if (Input.GetButtonDown("Inventory"))
            {
                inventoryOpen = !inventoryOpen;
            }

            if (Input.GetButtonDown("Y") && !inventoryOpen)
            {
                gameObject.GetComponent<Inventory>().SwitchWeapons();
            }
        }
        else if (!GlobalVariables.controller)
        {
            if (Input.GetAxis("ShootM+K") > 0)
            {
                GetComponentInChildren<Gun>().Fire();
            }

            if (Input.GetAxis("MeleeM+K") > 0)
            {
                GetComponentInChildren<MeleeWeapon>().Swing();
            }

            if (Input.GetButtonDown("GrenadeM+K"))
            {
                GetComponentInChildren<Grenade>().Throw();
            }

            if (Input.GetButtonDown("ReloadM+K"))
            {
                GetComponentInChildren<Gun>().Reload();
            }

            if (Input.GetButtonDown("Inventory"))
            {
                inventoryOpen = !inventoryOpen;
            }

            if (Input.GetAxis("SwitchM+K") != 0 && !inventoryOpen)
            {
                gameObject.GetComponent<Inventory>().SwitchWeapons();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
        {
            if (Input.GetButtonDown("A") && !inventoryOpen)
            {
                other.GetComponentInParent<Interactable>().PickUp();
            }
        }
    }
}