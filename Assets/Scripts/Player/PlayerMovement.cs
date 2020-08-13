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
    public Animator animator;

    private Rigidbody2D rb;
    private Vector3 originalScale;

    private float horizontal;

    private bool falling = false;

    private bool lastFrameGrounded = false;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.originalScale = this.transform.localScale;
    }

    void Update()
    {
        if (IsGrounded() && !lastFrameGrounded)
        {
            Debug.Log("IM HERE DUDE");
            this.animator.SetTrigger("down");
            this.animator.ResetTrigger("jump");
            this.animator.ResetTrigger("fall");
            falling = false;
        }

        if(GlobalVariables.Instance.PlayerIsStunned)
        {
            this.horizontal = 0;
            this.rb.velocity = new Vector2(0, this.rb.velocity.y);
            this.animator.SetBool("walking", false);
            return;
        }

        this.horizontal = Input.GetAxisRaw("Horizontal");

        this.animator.SetBool("walking", Mathf.Abs(this.horizontal) > 0);

        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            this.animator.SetTrigger("jump");
            this.animator.ResetTrigger("down");
            Jump();
        }

        if (!IsGrounded() && rb.velocity.y < 0 && !falling)
        {
            this.animator.ResetTrigger("jump");
            this.animator.SetTrigger("fall");
            falling = true;
        }

        if(this.horizontal > 0)
        {
            this.transform.localScale = this.originalScale;
        }

        if(this.horizontal < 0)
        {
            this.transform.localScale = this.originalScale;
            this.transform.localScale = new Vector3(-this.originalScale.x, this.originalScale.y, this.originalScale.z);
        }
        lastFrameGrounded = IsGrounded();
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
        Collider2D groundCheck = Physics2D.OverlapCircle(this.feet.transform.position, 0.05f, groundLayer);

        if(groundCheck?.gameObject != null)
        {
            return true;
        }

        return false;
    }
}
