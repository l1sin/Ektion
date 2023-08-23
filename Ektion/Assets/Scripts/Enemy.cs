using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public Transform Character;
    public Rigidbody2D Rb2d;
    public BoxCollider2D Collider2d;
    public SpriteRenderer EnemySpriteRenderer;

    public float Speed;
    public float ContactDamage;
    public int DropLevel;
    public LayerMask CharacterLayerMask;

    public float HealthMax { get; set ; }
    public float HealthCurrent { get; set; }

    private void Update()
    {
        MoveToPlayer();
    }
    public void MoveToPlayer()
    {
        Vector2 direction = Character.position - transform.position;
        direction.Normalize();
        Rb2d.velocity = direction * Speed;
    }

    public void SetStats(EnemyData enemyData)
    {
        HealthMax = enemyData.MaxHP;
        HealthCurrent = HealthMax;
        Speed = enemyData.Speed;
        ContactDamage = enemyData.ContactDamage;
        DropLevel = enemyData.DropLevel;
        EnemySpriteRenderer.sprite = enemyData.EnemySprite;
        Collider2d.size = EnemySpriteRenderer.sprite.bounds.size;
    }

    public void GetDamage(float damage)
    {
        HealthCurrent -= damage;
        if (HealthCurrent <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if ((CharacterLayerMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            collision.gameObject.GetComponent<IDamageable>().GetDamage(ContactDamage * Time.deltaTime);
        }
    }
}
