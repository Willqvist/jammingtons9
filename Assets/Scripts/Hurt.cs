using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hurt : MonoBehaviour
{
    public string objectWithTagToBeHurtBy = "Projectile";
    public GameObject screenShake;
    public Health health;
    public UnityEvent onHurt;
    public UnityEvent onDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == objectWithTagToBeHurtBy)
        {
            this.DealDamage(collision.gameObject.GetComponent<DamageDealer>().Damage);
        }
    }

    public void DealDamage(int damage)
    {
        this.health.RemoveHealth(damage);

        if (this.health.currentHealth <= 0)
        {
            Destroy(this.gameObject);
            this.onDeath.Invoke();
        }

        this.onHurt.Invoke();

        
    }
}
