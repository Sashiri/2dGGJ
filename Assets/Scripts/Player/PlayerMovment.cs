using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [Range(0, 0.5f)] [SerializeField] private float movementSmoothing = 0.5f;
    [SerializeField] private float movementSpeed = 10f;

    [SerializeField] private LayerMask GroundLayer;
    private Rigidbody2D rigidbodyPlayer;
    private Collider2D colliderPlayer;
    private Animator animatorPlayer;

    private Vector3 velocity = Vector3.zero;
    private float moveInput;
    private bool IsGrounded = true;
    private bool IsAbleToDoubleJump = false;
    private bool facingLeft = false;

    List<IInteractable> interactables;


    private void Awake()
    {
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        colliderPlayer = GetComponent<Collider2D>();
        animatorPlayer = GetComponent<Animator>();
        FlipPlayer();

    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded)
            {
                rigidbodyPlayer.velocity = new Vector2(rigidbodyPlayer.velocity.x / 2,0) +  Vector2.up * jumpForce;
                IsAbleToDoubleJump = true;
                IsGrounded = false;
            }
            else if (IsAbleToDoubleJump)
            {
                rigidbodyPlayer.velocity = new Vector2(rigidbodyPlayer.velocity.x / 2, 0) + Vector2.up * jumpForce;
                IsAbleToDoubleJump = false;
            }
        }

        if (rigidbodyPlayer.velocity.y > 0)
        {
            rigidbodyPlayer.velocity += Vector2.up * Physics2D.gravity.y * 1.5f * Time.deltaTime;
        }
        else if (rigidbodyPlayer.velocity.y < 0)
        {
            rigidbodyPlayer.velocity += Vector2.up * Physics2D.gravity.y * 1 * Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal") * movementSpeed;
        animatorPlayer.SetFloat("Speed", Mathf.Abs(moveInput));
        Vector3 TargetVelocity = new Vector2(moveInput, rigidbodyPlayer.velocity.y);
        rigidbodyPlayer.velocity = Vector3.SmoothDamp(rigidbodyPlayer.velocity, TargetVelocity, ref velocity, movementSmoothing);

        if (!facingLeft && moveInput > 0)
        {
            FlipPlayer();
        }
        else if (facingLeft && moveInput < 0)
        {
            FlipPlayer();
        }

    }

    private void FlipPlayer()
    {
        facingLeft = !facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            IsGrounded = true;
        }
    }
}
