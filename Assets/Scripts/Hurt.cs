using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Hurt : MonoBehaviour
{
    public string objectWithTagToBeHurtBy = "Projectile";
    public Health health;
    public UnityEvent onHurt;
    public UnityEvent onDeath;
    public HurtAudioSource source;

    private HurtAudioSource inst;
    private bool ded = false;
    
    private void Start()
    {
        if (source != null)
        {
            inst = Instantiate(source);
            inst.setup(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == objectWithTagToBeHurtBy)
        {
            this.DealDamage(collision.gameObject.GetComponent<DamageDealer>().Damage);
        }
    }

    public virtual void DealDamage(int damage)
    {
        if (ded) return;
        if(this.health != null)
        {
            this.health.RemoveHealth(damage);

            if (this.health.currentHealth <= 0)
            {
                Debug.Log("DEATH");
                this.onDeath.Invoke();
                ded = true;
                Destroy(this.gameObject);
            }
        }
        if(inst != null)
            inst.Play();
        this.onHurt.Invoke();
   
    }
}
