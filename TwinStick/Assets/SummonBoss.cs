using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonBoss : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        if (other.gameObject.name == "Player")
        {
            Boss2.instance.gameObject.SetActive(true);
        }
    }
}
