using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DirectionHolder), typeof(Rigidbody2D))]
public class AIFollowPlayer : MonoBehaviour
{
    public Animator animator;
    public float jumpForce;

    private DirectionHolder directionHolder;
    private Rigidbody2D rb;

    private void Start()
    {
        this.directionHolder = this.GetComponent<DirectionHolder>();
        this.directionHolder.Direction = new Vector2(1, 0);

        this.rb = this.GetComponent<Rigidbody2D>();

        this.animator.SetBool("walk", true);
    }

    private void Update()
    {
        this.rb.velocity = new Vector2(5 * this.directionHolder.Direction.x, this.rb.velocity.y);

        var hits = Physics2D.RaycastAll(this.transform.position, Vector2.up);

        foreach(var hit in hits)
        {
            if(hit.transform.CompareTag("Player"))
            {
                Jump();
            }
        }

        if(Random.Range(0, (10000f * 1.2f)) < 10)
        {
            Jump();
        }
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
    }
}
