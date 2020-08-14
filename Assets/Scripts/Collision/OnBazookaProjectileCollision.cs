using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBazookaProjectileCollision : MonoBehaviour
{
    public GameObject explosion;

    public void OnCollision()
    {
        GameObject go = Instantiate(explosion);
        go.transform.position = this.transform.position;
        go.GetComponent<DamageDealer>().Damage = this.GetComponent<DamageDealer>().Damage;
    }
}
