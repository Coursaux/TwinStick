using Missive_CSharp;
using UnityEngine.AI;
using UnityEngine;

public class Boss2 : EnemyController
{
    public static Boss2 instance;
    
    private Timer damageCooldown;

    [SerializeField]
    private float damageCooldownTime;

    [SerializeField] private int damage;

    void Awake()
    {
        damageCooldown = new Timer(damageCooldownTime);
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
        agent.SetDestination(player.transform.position);
        damageCooldown.Update();
    }

    private void OnCollisionStay(Collision other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealthManager>();

        if (damageCooldown.IsComplete && playerHealth != null)
        {
            playerHealth.takeDamage(damage, this.gameObject);
            damageCooldown.Reset();
            damageCooldown.Unpause();
            MissiveAggregator.instance.Publish(new EnemyAttackEvent(transform.position));
        }
    }


    void OnDestroy()
    {
        GameObject.Find("Unlock").SetActive(false);
    }
}
