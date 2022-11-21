using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerControl : MonoBehaviour
{
    public Animator anime;
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 1;
    public float jumpForce = 5;

    void Start()
    {
        Debug.Log("IM WORK");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        walk();
        jump();
        CheckGround();
    }

    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        if (Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer >().flipX = true;
        }
        else
        {
            GetComponent < SpriteRenderer >().flipX = false;
        }
        if(moveVector.x!=0)
        {
            anime.SetBool("stop",false);
        }
        else
        {
            anime.SetBool("stop",true);
        }
        
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;

    void CheckGround()
    {

        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }
}
