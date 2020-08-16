using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DirectionHolder), typeof(Rigidbody2D))]
public class AIFollowPlayer : MonoBehaviour
{
    public Animator animator;
    public float jumpForce;
    public float movespeed = 1f;

    private DirectionHolder directionHolder;
    private Rigidbody2D rb;
    private float jumpTimer = 15f;

    private int choose(int a, int b)
    {
        if(Random.Range(0, 2) == 0)
        {
            return a;
        }
        else
        {
            return b;
        }
    }

    private void Start()
    {
        this.directionHolder = this.GetComponent<DirectionHolder>();
        this.directionHolder.Direction = new Vector2(choose(-1, 1), 0);

        this.rb = this.GetComponent<Rigidbody2D>();

        this.animator.SetBool("walk", true);
    }

    private void Update()
    {
        if(GlobalVariables.Instance.GameIsPaused)
        {
            this.rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        jumpTimer -= Time.deltaTime;
        if(jumpTimer <= 0)
        {
            Jump();
            jumpTimer = 15f;
        }
        this.rb.velocity = new Vector2(movespeed * this.directionHolder.Direction.x, this.rb.velocity.y);


        //Jump when player is above

        /*
        var hits = Physics2D.RaycastAll(this.transform.position, Vector2.up);

        foreach(var hit in hits)
        {
            if(hit.transform.CompareTag("Player"))
            {
                Jump();
            }
        }

        if(Random.Range(0, (10000f * 1.5f)) < 10)
        {
            Jump();
        }
        */
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            this.directionHolder.Direction = -this.directionHolder.Direction;
        }
        if(collision.gameObject.CompareTag("Barrel"))
        {
            Jump();
        }
        if (collision.gameObject.tag.Equals("shell"))
        {
            Physics2D.IgnoreCollision(collision.collider, this.GetComponent<BoxCollider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Jump();
        }
    }
}
