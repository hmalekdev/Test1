using System;
using UnityEngine;

namespace Starbend.Test1
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float downForce = 10f;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundCheckRadius = 0.1f;
        [SerializeField] private LayerMask groundLayer;

        private Rigidbody2D rb;
        private bool isGrounded;
        private bool isJump;
        private float moveInput;

        public static Action<float> OnChangeMoveSpeed;
        public static Action<float> OnChangeJumpForce;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            OnChangeMoveSpeed?.Invoke(moveSpeed);
            OnChangeJumpForce?.Invoke(jumpForce);
        }

        private void Update()
        {
            CheckGround();
            InputHandler();
            LookDirectionHandler();
        }

        private void CheckGround()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        private void InputHandler()
        {
            isJump = Input.GetKey(KeyCode.Space) && isGrounded;
            moveInput = Input.GetAxis("Horizontal");
        }

        private void LookDirectionHandler()
        {
            if (moveInput == 0) return;

            var lookDirection = moveInput > 0 ? 1 : -1;
            transform.localScale = new Vector3(lookDirection, 1, 1);
        }

        private void FixedUpdate()
        {
            DownForce();
            MovementHandler();
            JumpHandler();
        }

        private void DownForce()
        {
            if (isGrounded) return;

            rb.AddForce(Vector2.down * downForce);
        }

        private void MovementHandler()
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }

        private void JumpHandler()
        {
            if (!isJump) return;

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        internal void BoostSpeed(float boost)
        {
            moveSpeed += boost;
            OnChangeMoveSpeed?.Invoke(moveSpeed);
        }

        internal void BoostJump(float boost)
        {
            jumpForce += boost;
            OnChangeJumpForce?.Invoke(jumpForce);
        }
    }
}
