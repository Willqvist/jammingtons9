using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hurt : MonoBehaviour
{
    public string objectWithTagToBeHurtBy = "Projectile";
    public GameObject bloodSplat;
    public GameObject bloodSplatParticle;
    public GameObject screenShake;
    public Health health;
    public GameObject headDeath;

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
            var obj = Instantiate(headDeath);
            var rb = obj.GetComponent<Rigidbody2D>();
            rb.transform.position = this.transform.position;
            rb.velocity = new Vector2(0, 0);
            rb.AddTorque(22);
            rb.AddForce(new Vector2((Random.value*4+1), 14), ForceMode2D.Impulse);
        }

        GameObject go = Instantiate(this.bloodSplat);
        go.transform.position = new Vector2(this.transform.position.x + Random.Range(-0.2f, 0.2f), this.transform.position.y - 0.2f);

        GameObject go2 = Instantiate(this.bloodSplatParticle);
        go2.transform.position = this.transform.position;

        GameObject go3 = Instantiate(this.screenShake);
        ScreenShake s = go3.GetComponent<ScreenShake>();
        s.GetShotAtScreenShakeTemplate();
    }
}
