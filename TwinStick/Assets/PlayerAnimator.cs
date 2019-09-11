using Missive_CSharp;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// This whole class is a dirty boy. the animator isn't a state machine
/// the animator
/// i
/// s
///
/// n
/// o
/// t
///
/// f
/// o
/// r
///
/// t
/// h
/// i
/// s
/// </summary>
public class PlayerAnimator : MonoBehaviour, IMissiveListener<SwordInputEvent>, IMissiveListener<GunInputEvent>
{
    private Animator animator;
    private NavMeshAgent playerAgent;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentSafely<Animator>();
        playerAgent = gameObject.GetComponentInParent<NavMeshAgent>();
        MissiveAggregator.instance.Register(this as IMissiveListener<SwordInputEvent>);
        MissiveAggregator.instance.Register(this as IMissiveListener<GunInputEvent>);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAgent.velocity.magnitude > 0f)
        {
            animator.SetBool("IsMoving", true);
            MissiveAggregator.instance.Publish(new MovementEvent(this.transform.position));
        }
        else
        {
            animator.SetBool("IsMoving", false);
            MissiveAggregator.instance.Publish(new StoppedMovingEvent());
        }
        
    }

    /// <summary>
    /// These two below methods: Forgive me Father Linus, for I have sinned.
    /// </summary>
    /// <param name="missive"></param>
    public void HandleMissive(SwordInputEvent missive)
    {
        if (gameObject.GetComponentInParent<SwordSkill>().Cooldown.IsComplete)
        {
            animator.SetTrigger("SwordAttack");
        }
    }

    public void HandleMissive(GunInputEvent missive)
    {
        if (gameObject.GetComponentInParent<PistolSkill>().Cooldown.IsComplete)
        {
            animator.SetTrigger("GunAttack");
        }
    }
}
