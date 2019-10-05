using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("RightTrigger") > 0)
        {
            GetComponentInChildren<Gun>().Fire();
        }

        if (Input.GetAxis("LeftTrigger") > 0)
        {
            GameObject.Find("Bat").GetComponent<MeleeWeapon>().Swing();
        }
        if (Input.GetButtonDown("LeftBumper"))
        {
            GetComponentInChildren<Grenade>().Throw();
        }
        if (Input.GetButtonDown("RightBumper"))
        {
            GetComponentInChildren<Gun>().Reload();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
        {
            if (Input.GetButtonDown("A"))
            {
                Debug.Log("entered");
                this.GetComponent<Inventory>().Add(other.GetComponentInParent<Interactable>().Data);
                Destroy(other);
            }
        }
    }
}