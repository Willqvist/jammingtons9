using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public string ignoreCollisionFromTag;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ignoreCollisionFromTag)
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }
    }
}
