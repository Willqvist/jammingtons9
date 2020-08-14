using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
        print("DUDE COLLIDING" + other.gameObject.tag);
        if(other.gameObject.CompareTag("Environment"))
        {
            print("HELLO" + other.gameObject.name);
            GameObject go = Instantiate(dustParticles);
            go.transform.position = this.transform.position;
            var system = go.GetComponent<ParticleSystem>();
            var Shape = system.shape;
            var main = system.main;
            Shape.rotation = new Vector3(0,this.direction.x < 0 ? 90 : -90,0);
            main.startSpeed = (Random.value * 4) + 8;
            //Destroy(this.gameObject);
            /*
            var normal = other.contacts[0].normal.normalized;
            var deflect = this.direction - 2*(Vector2.Dot(normal, this.direction)) * normal;
            deflect += new Vector2((float) (((Random.value*2)-1)*Math.PI/4*0.2f), (float) (((Random.value*2)-1)*Math.PI/4*0.2f));
            deflect = deflect.normalized;
            var quat = Quaternion.FromToRotation(Vector2.up, -normal);
            Shape.rotation = new Vector3(0,quat.eulerAngles.z,0);
            this.direction = deflect;
            this.transform.rotation = Quaternion.Euler(new Vector3(0,0,Vector2.Angle(Vector2.left,deflect)));
            */
            Destroy(this.gameObject);
        }
        else
        {
            //Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>()); 
        }
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
        this.hasSetDirection = true;
        transform.localScale = new Vector3(direction.x*transform.localScale.x,transform.localScale.y,transform.localScale.z);
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
