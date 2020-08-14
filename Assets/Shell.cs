using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{

    private bool active = false;

    public LayerMask colliding;
    
    private Rigidbody2D rb;

    private Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.gameObject.activeSelf)
        {
            active = false;
            return;
        }

        if (rb.velocity.y < 0 && !active)
        {
            active = true;
            collider.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (colliding != (colliding | (1 << other.gameObject.layer))) {
            Physics2D.IgnoreCollision(other.collider, collider); 
        }
    }
}
