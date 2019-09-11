using UnityEngine;

public abstract class PlayerSkill : MonoBehaviour
{
    public abstract Timer Cooldown { get; set; }

    /// <summary>
    /// Returns true if the skill is off cooldown
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public bool Use(GameObject user)
    {
        if (!Cooldown.IsComplete)
        {
            return false;
        }

        Cooldown.Reset();
        Cooldown.Unpause();
        Behave(user);
            
        return true;

    }
    protected abstract void Behave(GameObject User);

    void Update()
    {
        Cooldown.Update();
        OnUpdate();
    }

    protected virtual void OnUpdate()
    {
    }
}
