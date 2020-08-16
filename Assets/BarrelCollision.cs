using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCollision : MonoBehaviour
{
    public GameObject explosion;
    public int explosionDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            Explode();
        }
    }

    public void Explode()
    {
        GlobalVariables.Instance.barrelsDestroyed++;
        ScoreUI.instance.setScore(ScoreScreen.calcTot());
        GameObject go = Instantiate(explosion);
        go.transform.position = this.transform.position;
        go.GetComponent<DamageDealer>().Damage = explosionDamage;
        Destroy(this.gameObject);
    }
}
