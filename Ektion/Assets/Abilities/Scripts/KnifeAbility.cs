using UnityEngine;

public class KnifeAbility : BaseAbility
{
    public int ProjectileCount;
    public float Damage;
    public float Speed;
    public GameObject KnifePrefab;

    public override void Use()
    {
        Instantiate(KnifePrefab, transform.position, Quaternion.identity);
        base.Use();
    }
}
