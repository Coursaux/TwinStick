using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerHealthManager : MonoBehaviour
{
    public int totalHealth;
    public int currentHealth;

    [SerializeField] private CanvasGroup redFlash;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UIManager.instance.maxHealth = totalHealth;
        UIManager.instance.currentHealth = currentHealth;
    }

    void LateUpdate()
    {
        redFlash.alpha -= 10f * Time.deltaTime;
    }

    public void takeDamage(int damage, GameObject caller)
    {
        redFlash.alpha = 1f;
        currentHealth += -damage;
        Debug.Log(caller);
        if (currentHealth <= 0)
        {
            Invoke("GoToMain", 1f);
        }
    }

    private void GoToMain()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
