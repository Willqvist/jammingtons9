﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public GameObject projectile;
    public Transform shootOrigin;
    public float cooldownBetweenProjectiles;

    private bool startedTimer;

    public void Shoot(Vector2 shootDirection)
    {
        if(this.startedTimer == true)
        {
            return;
        }

        GameObject go = Instantiate(this.projectile);
        go.transform.position = shootOrigin.position;
        go.GetComponent<DirectionHolder>().Direction = shootDirection;
        go.GetComponent<DamageDealer>().Damage = this.weaponData.damage;

        this.startedTimer = true;
        Timer.Instance.StartTimer("Gun", this.cooldownBetweenProjectiles, () => 
        {
            this.startedTimer = false;
        });
    }
}
