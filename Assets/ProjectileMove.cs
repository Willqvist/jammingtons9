using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DirectionHolder), typeof(Rigidbody2D))]
public class ProjectileMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private DirectionHolder directionHolder;

    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.directionHolder = this.GetComponent<DirectionHolder>();
    }

    private void FixedUpdate()
    {
        if (!this.directionHolder.HasSetDirection)
        {
            return;
        }

        this.rb.velocity = this.directionHolder.Direction * speed;
    }
}
