using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float jumpForce = 100f;
    [Range(0, 0.5f)] private float movementSmoothing = 0.5f;
    private Rigidbody2D rigidbodyPlayer;
    private Collider2D colliderPlayer;
    private bool facingRight = true;
    private Vector3 velocity = Vector3.zero;
    private float moveInput;

    private void Awake()
    {
        rigidbodyPlayer = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rigidbodyPlayer.velocity = new Vector2(moveInput * movementSmoothing, rigidbodyPlayer.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            FlipPlayer();
        }
        else if(facingRight == true && moveInput < 0)
        {
            FlipPlayer();
        }

    }

    private void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
