using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject DeathSound;
    public float MaxHealth;
    public float CurrentHealth;
    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void GetDamage(float damage)
    {
        CurrentHealth -= damage;
        CheckDeath();
    }

    public virtual void CheckDeath()
    {

    }
}