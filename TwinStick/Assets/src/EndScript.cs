using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeScreen", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeScreen()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
