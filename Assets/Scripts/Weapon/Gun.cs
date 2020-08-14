using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public GameObject projectile;
    public Transform shootOrigin;
    public float cooldownBetweenProjectiles;

    private bool startedTimer;

    public bool Shoot(Vector2 shootDirection)
    {
        if(this.startedTimer == true)
        {
            return false;
        }

        GameObject go = Instantiate(this.projectile);
        go.transform.position = shootOrigin.position;
        go.GetComponent<Projectile>().SetDirection(shootDirection);
        go.GetComponent<Projectile>().SetSource(this);

        this.startedTimer = true;
        Timer.Instance.StartTimer(this.cooldownBetweenProjectiles, () => 
        {
            this.startedTimer = false;
        });
        return true;
    }
}
