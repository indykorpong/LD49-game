using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    private float xAxisInput;

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
        ControlHorizontalMovement();
        CheckJumpKeyPressed();
        ControlJump();
    }

    private void ControlHorizontalMovement()
    {
        xAxisInput = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(xAxisInput * speed, rb2D.velocity.y);
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
            rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            pressedJump = false;
        }
    }

}
