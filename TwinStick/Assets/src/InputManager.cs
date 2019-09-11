using System.Collections;
using System.Collections.Generic;
using Missive_CSharp;
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
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
            MissiveAggregator.instance.Publish(new SkillDashEvent()); 
        
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
            MissiveAggregator.instance.Publish(new SkillOneEvent());

        if (Input.GetKeyDown(KeyCode.JoystickButton2))
            MissiveAggregator.instance.Publish(new SkillTwoEvent());

        if (Input.GetKeyDown(KeyCode.JoystickButton3))
            MissiveAggregator.instance.Publish(new SkillThreeEvent());

        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            MissiveAggregator.instance.Publish(new SwordInputEvent());
        }
        
        if (Input.GetKeyDown(KeyCode.JoystickButton4))
            MissiveAggregator.instance.Publish(new GunInputEvent());
    }
}
