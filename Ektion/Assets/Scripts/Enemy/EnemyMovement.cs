using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [Header("Settings")]
    [HideInInspector] public Transform Target;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _speed;
    private Vector3 _direction;
    private float _distance;

    private void Update()
    {
        if (Target != null)
        {
            CalculateDirection();
            if (_distance > _maxDistance)
            {
                FlipX();
            } 
        }
        else
        {
            _rb2d.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (_distance > _maxDistance)
        {
            _rb2d.velocity = _direction * _speed;
        } 
    }

    private void CalculateDirection()
    {
        _distance = (Target.position - transform.position).magnitude;
        _direction = (Target.position - transform.position).normalized;
    }

    private void FlipX()
    {
        if (_direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
