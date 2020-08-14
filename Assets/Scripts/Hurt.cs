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
