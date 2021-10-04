using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class CharacterController : MonoBehaviour
    {
        public float speed = 5f;
        public int speedMultiplier = 1;
        public float XAxis { get; set; }

        public float jumpForce = 5f;
        private bool pressedJump;

        private Rigidbody2D rb2D;
        
        public CapsuleCollider2D Collider { get; set; }
        public Vector3 LastFramePosition { get; set; }

        public GameObject[] raycast2DObjects;
        
        private void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            pressedJump = false;
            LastFramePosition = transform.position;

            Collider = GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            if (LastFramePosition != transform.position)
            {
                LastFramePosition = transform.position;
            }
            
            // CheckJumpKeyPressed();
            // SetXAxis();
        }

        private void FixedUpdate()
        {
            XAxis = rb2D.velocity.normalized.x;
            ControlHorizontalMovement();
            // ControlJump();
        }

        private void CheckJumpKeyPressed()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !pressedJump)
            {
                pressedJump = true;
            }
        }

        private void SetXAxis()
        {
            XAxis = Input.GetAxis("Horizontal");
        }

        private void ControlHorizontalMovement()
        {
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
        }

        private void ControlJump()
        {
            if (pressedJump)
            {
                pressedJump = false;
                rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }

        public void ChangeDirection()
        {
            speed *= -1;
        }

        public void Jump()
        {
            rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        public void StayStill()
        {
            speed = 0f;
        }

        public void GameOver()
        {
            // TODO: call game over method
            Debug.Log("Game Over!");
        }
    }
}