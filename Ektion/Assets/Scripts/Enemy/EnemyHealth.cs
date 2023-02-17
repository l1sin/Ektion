using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private EnemyDrop _enemyDrop;
    public override void CheckDeath()
    {
        if (CurrentHealth <= 0)
        {
            _enemyDrop.CalculateAndDrop();
            Instantiate(DeathSound, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
