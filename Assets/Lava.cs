using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GlobalVariables.Instance.PlayerHealth = 0;
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("IM HERE");
            collision.gameObject.GetComponent<Hurt>().DealDamage(100000000);
        }
    }
}
