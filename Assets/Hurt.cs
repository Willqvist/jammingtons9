using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour
{
    public string objectWithTagToBeHurtBy = "Projectile";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == objectWithTagToBeHurtBy)
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
