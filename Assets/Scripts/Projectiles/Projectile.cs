using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public GameObject dustParticles;

    private Vector2 direction;
    private bool hasSetDirection;

    private Rigidbody2D rb;
    private Gun source;

    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!hasSetDirection)
        {
            return;
        }

        this.rb.velocity = this.direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Environment"))
        {
            GameObject go = Instantiate(dustParticles);
            go.transform.position = this.transform.position;
        }
        Destroy(this.gameObject);
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
        this.hasSetDirection = true;
    }

    public void SetSource(Gun source)
    {
        this.source = source;
    }

    public Gun GetSource()
    {
        return this.source;
    }
}
