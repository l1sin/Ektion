using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Character;
    public Rigidbody2D Rb2d;

    public float Speed;
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

    public void FullReset()
    {

    }
}
