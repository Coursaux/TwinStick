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
            try
            {
                GameObject.Find("Pistol").GetComponent<Gun>().Fire();
            }
            catch
            { }

        }

        if (Input.GetButtonDown("A"))
        {
            Debug.Log("A");
        }
    }
}
