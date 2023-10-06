using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public static string gamestate = "playing";
    new Rigidbody2D rigidbody2D;
    public float speed = 3.0f;
    float axisH = 0f;

    public float jump = 8f;
    public LayerMask groundLayer;
    bool gojump = false;
    bool onGround = false;

    Animator animator;
    public string[] Animations;
    string cur_Anime = "";
    string pre_Anime = "";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        cur_Anime = Animations[0];
        pre_Anime = Animations[0];
        gamestate = "playing";
    }

    // Update is called once per frame
    void Update()
    {
        if (gamestate != "playing") return;

        axisH = Input.GetAxisRaw("Horizontal");
        if (axisH > 0)
            transform.localScale = new Vector2(1, 1);
        else if (axisH < 0)
            transform.localScale = new Vector2(-1, 1);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        gojump = true;
    }

    private void FixedUpdate()
    {
        if (gamestate != "playing") return;

        onGround = Physics2D.Linecast(transform.position, (transform.position - transform.up * 0.1f), groundLayer);
        if (onGround || axisH != 0)
        {
            rigidbody2D.velocity = new Vector2(axisH * speed, rigidbody2D.velocity.y);
        }
        if (onGround && gojump)
        {
            Vector2 jumpPw = new Vector2(0, jump);
            rigidbody2D.AddForce(jumpPw, ForceMode2D.Impulse);
            gojump = false;
        }
        if (onGround)
        {
            if (axisH == 0) cur_Anime = Animations[0];
            else cur_Anime = Animations[2];
        }
        else cur_Anime = Animations[1];

        if(cur_Anime != pre_Anime)
        {
            pre_Anime = cur_Anime;
            animator.Play(cur_Anime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if (collision.gameObject.tag == "Dead")
        {
            Dead();
        }
    }

    public void Dead()
    {
        gamestate = "gameover";
        animator.Play(Animations[3]);
        GameStop();
        GetComponent<CapsuleCollider2D>().enabled = false;
        rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    private void Goal()
    {
        gamestate = "gameclear";
        animator.Play(Animations[4]);
        GameStop();
    }

    private void GameStop()
    {
        rigidbody2D.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.zero;
    }
}
