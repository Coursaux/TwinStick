using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public int dmg;
    private float timeSpawned;
    private int length = 1;

    // Start is called before the first frame update
    void Start()
    {
        timeSpawned = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeSpawned + length)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetDmg(int _dmg)
    {
        dmg = _dmg;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

    }
}
