using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockZ : MonoBehaviour
{
    private Transform trans;
    // Start is called before the first frame update
    void Awake()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        trans.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}
