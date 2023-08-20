using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControls : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float speed;
    private InputAction moveAction;
    private Vector3 moveVector;

    public void Awake()
    {
        moveAction = playerInput.actions["Move"];
        playerInput.onActionTriggered += PlayerInput_onActionTriggered;
    }

    private void PlayerInput_onActionTriggered(InputAction.CallbackContext obj)
    {
        if (obj.action == moveAction)
        {
            moveVector = obj.ReadValue<Vector2>();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb2D.velocity = moveVector * speed;
    }
}