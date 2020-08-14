using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public string targetTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == targetTag)
        {
            Destroy(this.gameObject);
        }
    }
}
