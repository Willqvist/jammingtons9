using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : Hurt
{
    public GameObject explosion;
    public float gracePeriod = 1f;

    bool can_be_hurt = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(can_be_hurt && (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Projectile"))
        {
            GlobalVariables.Instance.PlayerHealth--;
            can_be_hurt = false;
            Timer.Instance.StartTimer("weweew", gracePeriod, () => 
            {
                can_be_hurt = true;
            });

            /*
             * Explode on damage
            GameObject go = Instantiate(explosion);
            go.transform.localScale *= 4;
            go.transform.position = this.transform.position;
            go.GetComponent<DamageDealer>().Damage = 10;
            */
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (can_be_hurt && (collision.gameObject.tag == "Enemy" || collision.gameObject.name.StartsWith("Explosion")))
        {
            GlobalVariables.Instance.PlayerHealth--;
            can_be_hurt = false;
            Timer.Instance.StartTimer("weweew", gracePeriod, () =>
            {
                can_be_hurt = true;
            });
        }
    }

    public override void DealDamage(int damage)
    {
        GlobalVariables.Instance.PlayerHealth -= 1;
    }
}
