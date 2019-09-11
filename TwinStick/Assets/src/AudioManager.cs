using System.Collections;
using System.Collections.Generic;
using Missive_CSharp;
using UnityEngine;

public class AudioManager : MonoBehaviour, 
    IMissiveListener<SwordUsedEvent>,
    IMissiveListener<GunUsedEvent>,
    IMissiveListener<EnemyExplodedEvent>,
    IMissiveListener<MovementEvent>,
    IMissiveListener<EnemyAttackEvent>,
    IMissiveListener<StoppedMovingEvent>,
    IMissiveListener<EnemyDiedEvent>
{

    void Start()
    {
        MissiveAggregator.instance.Register(this as IMissiveListener<SwordUsedEvent>);
        MissiveAggregator.instance.Register(this as IMissiveListener<GunUsedEvent>);
        MissiveAggregator.instance.Register(this as IMissiveListener<MovementEvent>);
        MissiveAggregator.instance.Register(this as IMissiveListener<EnemyAttackEvent>);
        MissiveAggregator.instance.Register(this as IMissiveListener<EnemyExplodedEvent>);
        MissiveAggregator.instance.Register(this as IMissiveListener<StoppedMovingEvent>);
        MissiveAggregator.instance.Register(this as IMissiveListener<EnemyDiedEvent>);
    }

    public AudioSource Sword;
    public AudioSource Gun;
    public AudioSource Footstep;
    public AudioSource EnemyDeath;
    public AudioSource EnemyAttack;
    public AudioSource Explosion;
    
    void swordSound(Vector3 coords)
    {
        Sword.transform.position = coords;
        Sword.Play();
    }

    void gunSound(Vector3 coords)
    {
        Gun.transform.position = coords;
        Gun.Play();
    }
    
    void footstepSound(Vector3 coords)
    {
        Footstep.transform.position = coords;
        Footstep.Play();
    }
    
    /// <summary>
    /// i don't know why this was bugged. Love, cort
    /// </summary>
    /// <param name="coords"></param>
    void enemyDeathSound(Vector3 coords)
    {
        if (coords != null)
        {
            EnemyDeath.transform.position = coords;
            EnemyDeath.Play();
        }
    }
    
    void enemyAttackSound(Vector3 coords)
    {
        EnemyAttack.transform.position = coords;
        EnemyAttack.Play();
    }
    
    void explosionSound(Vector3 coords)
    {
        Explosion.transform.position = coords;
        Explosion.Play();
    }

    public void HandleMissive(SwordUsedEvent missive)
    {
        swordSound(missive.position);
    }

    public void HandleMissive(GunUsedEvent missive)
    {
        gunSound(missive.position);
    }

    public void HandleMissive(EnemyExplodedEvent missive)
    {
        explosionSound(missive.position);
    }

    public void HandleMissive(MovementEvent missive)
    {
        if (!Footstep.isPlaying)
        {
            footstepSound(missive.position);
        }
    }

    public void HandleMissive(EnemyAttackEvent missive)
    {
        enemyAttackSound(missive.position);
    }

    public void HandleMissive(StoppedMovingEvent missive)
    {
        Footstep.Stop();
    }

    public void HandleMissive(EnemyDiedEvent missive)
    {
        enemyDeathSound(missive.position);
    }
}