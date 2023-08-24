using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    public float Damage;

    public void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime, Space.Self);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<IDamageable>().GetDamage(Damage);
        Destroy(gameObject);
    }
}
