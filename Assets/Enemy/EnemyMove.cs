using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    float moveSpeed = 1f;
    bool canMove = false;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (canMove) Move();
    }

    private void Move()
    {
        rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed *= -1;
        transform.localScale = transform.localScale * new Vector2(-1, 1);
        canMove = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canMove = true;
    }
}
