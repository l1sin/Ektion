using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControls : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float speed;
    private InputAction moveAction;
    private Vector3 moveVector;
    public PlayerInput PlayerInput
    {
        get => playerInput;
    }

    public void Awake()
    {
        moveAction = PlayerInput.actions["Move"];
        PlayerInput.onActionTriggered += PlayerInput_onActionTriggered;
    }

    private void PlayerInput_onActionTriggered(InputAction.CallbackContext obj)
    {
        if (obj.action == moveAction)
        {
            moveVector = obj.ReadValue<Vector2>();
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(moveVector * speed * Time.deltaTime);
    }
}
