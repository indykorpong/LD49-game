using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class CharacterController : MonoBehaviour
    {
        public float speed = 5f;
        private float xAxis;

        public float jumpForce = 5f;
        private float jumpCooldown = 1f; // in seconds
        private bool pressedJump;

        private Rigidbody2D rb2D;
        
        public Vector3 characterPosition;

        private void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            pressedJump = false;
        }

        // private void Update()
        // {
        //     CheckJumpKeyPressed();
        // }

        private void FixedUpdate()
        {
            characterPosition = transform.position;
        }

        private void ControlHorizontalMovement(float xAxis)
        {
            // xAxis = Input.GetAxis("Horizontal");
            rb2D.velocity = new Vector2(xAxis * speed, rb2D.velocity.y);
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

        public void WalkLeft()
        {
            ControlHorizontalMovement(-1f);
        }

        public void WalkRight()
        {
            ControlHorizontalMovement(1f);
        }

        public void Jump()
        {
            rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        public void StayStill()
        {
            ControlHorizontalMovement(0f);
        }

        public void GameOver()
        {
            // TODO: call game over method
            Debug.Log("Game Over!");
        }
    }
}