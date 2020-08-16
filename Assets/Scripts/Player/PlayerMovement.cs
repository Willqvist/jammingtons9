using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public GameObject feet;
    public GameObject feetVisual;
    public LayerMask groundLayer;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public GameObject doubleJumpParticle;
    public GameObject landParticle;
    public AudioSource walkAudio;
    public AudioSource jumpAudio;
    public float stepSoundDelay = 1;
    private Rigidbody2D rb;
    public Collider2D collider;
    private Vector3 originalScale;

    public Animator gun;

    private float horizontal;

    private bool falling = false;

    private bool isWalking = false;

    private bool lastFrameGrounded = false;
    private bool doubleJump = false;

    private float pitch = 0,jumpPitch=0;

    private float walkTime = 0;
    
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.originalScale = this.transform.localScale;
        this.pitch = walkAudio.pitch;
        jumpPitch = jumpAudio.pitch;
    }
    
    void PlayWalkSound()
    {
        walkAudio.pitch = pitch + ((Random.value * 2) - 1)*0.1f;
        walkAudio.Play();
        walkTime = 0;
    }

    void Update()
    {
        if (IsGrounded() && !lastFrameGrounded)
        {
            this.animator.SetTrigger("down");
            PlayWalkSound();
            this.animator.ResetTrigger("jump");
            this.animator.ResetTrigger("fall");
            falling = false;
        }

        Debug.Log(GlobalVariables.Instance.PlayerIsStunned);

        if(GlobalVariables.Instance.PlayerIsStunned)
        {
            isWalking = false;
            this.horizontal = 0;
            this.rb.velocity = new Vector2(0, this.rb.velocity.y);
            this.animator.SetBool("walking", false);
            if(gun != null)
                gun.SetBool("walking",false);
            this.animator.ResetTrigger("jump");
            this.animator.ResetTrigger("fall");
            this.animator.ResetTrigger("down");
            jumpAudio.Stop();
            walkAudio.Stop();
            return;
        }

        this.horizontal = Input.GetAxisRaw("Horizontal");

        this.animator.SetBool("walking", Mathf.Abs(this.horizontal) > 0);
        if (Mathf.Abs(this.horizontal) > 0 && !isWalking)
        {
            isWalking = true;
            PlayWalkSound();
            //walkAudio.Play();
        }
        else if(Mathf.Abs(this.horizontal) <= 0 && isWalking && IsGrounded())
        {
            walkTime = 0;
            isWalking = false;
            //walkAudio.Stop();
        }

        if (isWalking && walkTime > stepSoundDelay && IsGrounded())
        {
            PlayWalkSound();
        }

        walkTime += Time.deltaTime;

        if (gun != null)
            gun.SetBool("walking", Mathf.Abs(this.horizontal) > 0);

        if(Input.GetKeyDown(KeyCode.Space) && (IsGrounded() || !doubleJump))
        {
            this.animator.SetTrigger("jump");
            this.animator.ResetTrigger("down");
            isWalking = false;
            walkAudio.Stop();
            if(!IsGrounded() && !doubleJump)
            {
                doubleJump = true;
                GameObject go = Instantiate(doubleJumpParticle);
                go.transform.position = this.feetVisual.transform.position;
                DoubleJump();
            }
            else
            {
                Jump();
            }
        }

        if(IsGrounded())
        {
            if(doubleJump)
            {
                GameObject go = Instantiate(landParticle);
                go.transform.position = this.feetVisual.transform.position;
            }
            doubleJump = false;
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
        jumpAudio.pitch = jumpPitch + ((Random.value * 2) - 1)*0.08f;
        jumpAudio.Play();
    }
    
    void DoubleJump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce*1.15f);
        rb.velocity = movement;
        jumpAudio.pitch = jumpPitch + ((Random.value * 2) - 1)*0.08f;
        jumpAudio.Play();
    }

    public bool IsGrounded()
    {
        Collider2D[] groundCheck = Physics2D.OverlapCircleAll(this.feet.transform.position, 0.05f, groundLayer);

        if(groundCheck == null)
        {
            return false;
        }

        if(groundCheck.Length > 0)
        {
            return true;
        }

        return false;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("shell")) {
            Physics2D.IgnoreCollision(other.collider, collider); 
        }
    }
}
