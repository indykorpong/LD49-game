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

        private Rigidbody2D _rb2D;
        private CapsuleCollider2D _collider;

        private int _jumpableObjectLayerMask;

        private void Start()
        {
            _rb2D = GetComponent<Rigidbody2D>();
            _collider = GetComponent<CapsuleCollider2D>();
            
            _jumpableObjectLayerMask = LayerMask.GetMask("Object", "Ground");
        }

        private void Update()
        {
            SetXAxis();
            CheckJumpKeyPressed();
        }

        private void FixedUpdate()
        {
            ControlHorizontalMovement();
        }
        
        private void SetXAxis()
        {
            _xAxis = Input.GetAxis("Horizontal");
        }
        
        private void CheckJumpKeyPressed()
        {
            if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        private bool IsGrounded()
        {
            Vector3 origin = _collider.bounds.center - new Vector3(0, _collider.bounds.extents.y,0);
            RaycastHit2D raycastHit2D =
                Physics2D.Raycast(origin, Vector2.down, 0.1f, _jumpableObjectLayerMask);
            return raycastHit2D.collider != null;
        }
        
        private void Jump()
        {
            _rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        private void ControlHorizontalMovement()
        {
            _rb2D.velocity = new Vector2(speed * _xAxis, _rb2D.velocity.y);
        }
    }
}