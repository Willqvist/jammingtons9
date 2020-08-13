using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public GameObject feet;
    public LayerMask groundLayer;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private Vector3 originalScale;

    private float horizontal;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.originalScale = this.transform.localScale;
    }

    void Update()
    {
        this.horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }

        if(this.horizontal > 0)
        {
            this.transform.localScale = this.originalScale;
        }

        if(this.horizontal < 0)
        {
            this.transform.localScale = new Vector3(-this.originalScale.x, this.originalScale.y, this.originalScale.z);
        }
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontal * speed, rb.velocity.y);
        rb.velocity = movement;
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(this.feet.transform.position, 0.5f, groundLayer);

        if(groundCheck?.gameObject != null)
        {
            return true;
        }

        return false;
    }
}
