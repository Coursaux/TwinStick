using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("sgsgsdg");
        if (col.tag == "Player")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
