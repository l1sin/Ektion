public interface IDamageable
{
    public float HealthMax { get; set; }
    public float HealthCurrent { get; set; }

    public void GetDamage(float damage);
    public void Die();
}
