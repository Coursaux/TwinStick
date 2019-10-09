using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int totalHealth = 100;
    public int currentHealth;
    public bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        dead = true;
    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
    }

    public void TakeHeal(int Heal)
    {
        currentHealth += Heal;
    }
}
