using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class CharacterController : MonoBehaviour
    {
        public float speed = 5f;
        private float _xAxis;

        public float jumpForce = 5f;
        private bool pressedJump;

        private Rigidbody2D rb2D;
        
        public Vector3 CharacterPosition { get; set; }
        public Vector3 LastFramePosition { get; set; }

        public GameObject[] raycast2DObjects;
        
        private void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            pressedJump = false;
            LastFramePosition = transform.position;
        }

        private void Update()
        {
            // CheckJumpKeyPressed();
            // SetXAxis();
        }

        private void FixedUpdate()
        {
            CharacterPosition = transform.position;
            
            // ControlHorizontalMovement(_xAxis);
            // ControlJump();

            if (LastFramePosition != CharacterPosition)
            {
                LastFramePosition = CharacterPosition;
            }
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
            _xAxis = Input.GetAxis("Horizontal");
        }

        private void ControlHorizontalMovement(float xAxis)
        {
            rb2D.velocity = new Vector2(xAxis * speed, rb2D.velocity.y);
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