using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{ 
    public Text controller;

    void Update()
    {
        controller.text = "Controller: " + GlobalVariables.controller;
    }

    public void InputToggle()
    {
        GlobalVariables.controller = !GlobalVariables.controller;
    }
}
