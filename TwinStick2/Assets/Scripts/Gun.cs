using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{ 
    public int Damage;
    public int speed;
    public float FireRate;
    public GameObject Projectile;
    public int TotalBullets;
    public int TotalReserve;
    public int TotalInGun;
    public int Capacity;

    private float lastShot = -10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire()
    {
        if (TotalInGun > 0 && Time.time > FireRate + lastShot)
        {
            GameObject bullet = Instantiate(Projectile, transform.Find("Spawner").gameObject.transform.position, transform.rotation) as GameObject;
            bullet.GetComponent<Projectile>().SetDmg(Damage);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            //TotalInGun -= 1;
            if (TotalInGun == 0)
            {
                Reload();
            }

            lastShot = Time.time;
        }
        else if(TotalInGun == 0)
        {
            Reload();
        }
    }

    public void Reload()
    {
        
    }
}