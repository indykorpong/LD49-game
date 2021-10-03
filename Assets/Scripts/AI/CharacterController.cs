using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 velocity;
    private float xAxis;

    public float jumpForce = 100f;
    private float jumpCooldown = 1f;  // in seconds
    private bool pressedJump;
    private bool touchedGround;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        pressedJump = false;
        touchedGround = true;
    }

    private void Update()
    {
        ControlHorizontalMovement();
        CheckJumpKeyPressed();
        ControlJump();
        
        Debug.Log($"ground: {touchedGround}, jump: {pressedJump}");
    }

    private void ControlHorizontalMovement()
    {
        xAxis = Input.GetAxis("Horizontal");

        velocity = new Vector3(xAxis, 0, 0);
        transform.position += velocity * speed * Time.deltaTime;
    }

    private void CheckJumpKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !pressedJump && touchedGround)
        {
            pressedJump = true;
        }
    }

    private void ControlJump()
    {
        if (pressedJump)
        {
            rb2D.AddForce(new Vector2(0, jumpForce));
            pressedJump = false;
            touchedGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            touchedGround = true;
        }
    }
}
