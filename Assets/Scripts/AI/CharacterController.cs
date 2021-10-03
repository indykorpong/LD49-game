using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    private float xAxis;

    public float jumpForce = 5f;
    private float jumpCooldown = 1f;  // in seconds
    private bool pressedJump;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        pressedJump = false;
    }

    private void Update()
    {
        CheckJumpKeyPressed();
    }

    private void FixedUpdate()
    {
        ControlHorizontalMovement();
        ControlJump();
    }

    private void ControlHorizontalMovement()
    {
        xAxis = Input.GetAxis("Horizontal");

        rb2D.velocity = new Vector2(xAxis * speed, rb2D.velocity.y);
        //transform.position += velocity * speed * Time.deltaTime;
    }

    private void CheckJumpKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !pressedJump)
        {
            pressedJump = true;
        }
    }

    private void ControlJump()
    {
        if (pressedJump)
        {
            pressedJump = false;
            rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
