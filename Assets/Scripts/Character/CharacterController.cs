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
        private bool hasJumpedUp = false;
        private bool hasJumpedPeak = false;
        private bool hasJumpedDown = false;

        private Rigidbody2D _rb2D;
        private CapsuleCollider2D _collider;

        private float _raycastDistance = 0.5f;
        private int _jumpableObjectLayerMask;

        [SerializeField] private GameManager gameManager;
        [SerializeField] private AnimationController animationController;

        private void Start()
        {
            _rb2D = GetComponent<Rigidbody2D>();
            _collider = GetComponent<CapsuleCollider2D>();

            _jumpableObjectLayerMask = LayerMask.GetMask("Object", "Ground");
        }

        private void Update()
        {
            if (!gameManager.isGameStart) return;

            SetXAxis();
            CheckJumpKeyPressed();
            SetIdleOrRunAnimation();
            SetJumpAnimations();
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
            Bounds colliderBounds = _collider.bounds;
            Vector3 origin = colliderBounds.center - new Vector3(0, colliderBounds.extents.y, 0);
            Debug.DrawRay(origin, Vector2.down *_raycastDistance, Color.red);
            RaycastHit2D raycastHit2D =
                Physics2D.BoxCast(origin, new Vector2(colliderBounds.size.x, colliderBounds.size.y), 0f,
                    Vector2.down, _raycastDistance, _jumpableObjectLayerMask);
            return raycastHit2D.collider != null;
        }

        private void Jump()
        {
            hasJumpedUp = true;
            animationController.PlayJumpUp();
            _rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        private void SetJumpAnimations()
        {
            if (hasJumpedUp && Mathf.Abs(_rb2D.velocity.y) <= 0.5f)
            {
                hasJumpedUp = false;
                hasJumpedPeak = true;
                animationController.PlayJumpPeak();
            }

            if (hasJumpedPeak && _rb2D.velocity.y < 0)
            {
                hasJumpedPeak = false;
                hasJumpedDown = true;
                animationController.PlayJumpDownLoop();
            }

            if ((hasJumpedPeak || hasJumpedDown) && IsGrounded())
            {
                hasJumpedUp = false;
                hasJumpedPeak = false;
                hasJumpedDown = false;
                animationController.PlayIdle();
            }
        }

        private void SetIdleOrRunAnimation()
        {
            if (hasJumpedUp || hasJumpedDown) return;
            // if (Mathf.Approximately(_rb2D.velocity.x,0) && Mathf.Approximately(_rb2D.velocity.y,0))
            if (_xAxis == 0)
            {
                animationController.PlayIdle();
            }
            else
            {
                animationController.PlayRun();
            }
        }

        private void ControlHorizontalMovement()
        {
            _rb2D.velocity = new Vector2(speed * _xAxis, _rb2D.velocity.y);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("OutZone"))
            {
                gameManager.GameOver();
            }
        }
    }
}