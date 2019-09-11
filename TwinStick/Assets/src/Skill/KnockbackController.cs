using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KnockbackController : MonoBehaviour
{
    private Timer knockbackTimer = new Timer(0f);

    private NavMeshAgent agent;
    private Rigidbody rb;

    void Start()
    {
        agent = gameObject.GetComponentSafely<NavMeshAgent>();
        rb = gameObject.GetComponentSafely<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        knockbackTimer.Update();
    }
    
    public void Knockback(Vector3 Direction, float time)
    {
        agent.isStopped = true;
        rb.AddForce(Direction, ForceMode.Impulse);
        knockbackTimer = new Timer(time);
        knockbackTimer.RegisterTimerCallback(TurnKnockBackOff);
    }

    private void TurnKnockBackOff()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        agent.isStopped = false;
        
    }
}
