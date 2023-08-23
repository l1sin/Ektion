using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    public float HealthMax { get => healthMax; set => healthCurrent = value; }
    public float HealthCurrent { get => healthCurrent; set => healthCurrent = value; }
    [SerializeField] private float healthMax;
    [SerializeField] private float healthCurrent;

    public void Awake()
    {
        healthCurrent = healthMax;
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void GetDamage(float damage)
    {
        HealthCurrent -= damage;
        if (HealthCurrent <= 0)
        {
            Die();
        }
    }
}
