using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text healthText;
    public static UIManager instance;
    public int maxHealth;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth >= 0 ? currentHealth : 0;
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
    }
}
