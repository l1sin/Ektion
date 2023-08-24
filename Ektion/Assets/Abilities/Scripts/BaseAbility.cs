using UnityEngine;

public class BaseAbility: MonoBehaviour
{
    public string ID;
    public Sprite Icon;
    public float Cooldown;
    public float CooldownTimer;

    public void Start()
    {
        CooldownTimer = Cooldown;
    }
    public void ReduceCooldown()
    {
        CooldownTimer -= Time.deltaTime;
        if (CooldownTimer <= 0)
        {
            Use();
        }
    }
    public virtual void Use()
    {
        CooldownTimer = Cooldown;
    }
}
