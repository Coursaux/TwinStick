using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int TotalHealth = 100;
    private float CurrentHealth;
    public bool Dead = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = TotalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Dead = true;
    }

    public void TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;
        Debug.Log(CurrentHealth + " health");
    }

    public void TakeHeal(int Heal)
    {
        CurrentHealth += Heal;
    }
}
