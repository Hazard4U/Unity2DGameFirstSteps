using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MOVE_SPEED;
    public float JUMP_FORCE;
    public Rigidbody2D rigidBody2D;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask layerMask;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private bool isJumping = false;
    private bool isGrounded = false;
    private float horizontalInput = 0;

    // Constants
    private float SMOOTH_TIME = .05f;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, layerMask);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
        Animation();
    }

    void FixedUpdate()
    {
        float horizontalMovement = horizontalInput * MOVE_SPEED * Time.deltaTime;
        MovePlayer(horizontalMovement);
    }

    private void MovePlayer(float horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(horizontalMovement, rigidBody2D.velocity.y);
        rigidBody2D.velocity = Vector3.SmoothDamp(rigidBody2D.velocity, targetVelocity, ref velocity, SMOOTH_TIME);

        if (isJumping)
        {
            rigidBody2D.AddForce(new Vector2(0f, JUMP_FORCE));
            isJumping = false;
        }
    }

    private void Animation()
    {
        float speed = rigidBody2D.velocity.x;
        animator.SetFloat("Speed", Mathf.Abs(speed));
        spriteRenderer.flipX = speed != 0 ? speed < 0 : spriteRenderer.flipX;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
