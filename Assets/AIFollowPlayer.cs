using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DirectionHolder), typeof(Rigidbody2D))]
public class AIFollowPlayer : MonoBehaviour
{
    public Animator animator;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            this.directionHolder.Direction = -this.directionHolder.Direction;
        }
    }
}
