using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBazookaProjectileCollision : MonoBehaviour
{
    public GameObject explosion;
    public GameObject audioPrefab;
    public void OnCollision()
    {
        GameObject go = Instantiate(explosion);
        Instantiate(audioPrefab);
        go.transform.position = this.transform.position;
        go.GetComponent<DamageDealer>().Damage = this.GetComponent<DamageDealer>().Damage / 2;
    }
}
