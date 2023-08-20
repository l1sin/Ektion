using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [Header ("Components")]
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;


    [Header("Settings")]
    [SerializeField] private float _speed;

    private void Update()
    {
        FlipX();
        Animation();
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = new Vector2(_playerInput.HorizontalInput, _playerInput.VerticalInput);
        Vector2 abs = new Vector2(Mathf.Abs(inputVector.x), Mathf.Abs(inputVector.y));
        _rb2d.velocity = inputVector.normalized * abs * _speed;
    }

    private void Animation()
    {
        _animator.SetFloat(GlobalStrings.AnimSpeed, _rb2d.velocity.magnitude);
    }

    private void FlipX()
    {
        if (_playerInput.HorizontalInput > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_playerInput.HorizontalInput < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
