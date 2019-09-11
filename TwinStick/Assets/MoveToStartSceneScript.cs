using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToStartSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeScreen", 2);
    }

    void ChangeScreen()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
