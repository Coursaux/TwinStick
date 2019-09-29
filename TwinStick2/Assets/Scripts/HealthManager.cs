using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float TotalHealth = 100f;
    private float CurrentHealth;

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
        Destroy(this.gameObject);
    }

    public void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;
    }

    public void TakeHeal(float Heal)
    {
        CurrentHealth += Heal;
    }
}
