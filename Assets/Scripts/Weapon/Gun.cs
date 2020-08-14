using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public GameObject projectile;
    public Transform shootOrigin;
    public float cooldownBetweenProjectiles;

    private bool startedTimer;
    private Animator animator;

    private void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    public bool Shoot(Vector2 shootDirection)
    {
        if(this.startedTimer == true)
        {
            return false;
        }
        this.animator.Play("Recoil",-1,0);
        GameObject go = Instantiate(this.projectile);
        go.transform.position = shootOrigin.position;
        go.GetComponent<DirectionHolder>().Direction = shootDirection;
        go.GetComponent<DamageDealer>().Damage = this.weaponData.damage;

        this.startedTimer = true;
        Timer.Instance.StartTimer("Gun", this.cooldownBetweenProjectiles, () => 
        {
            this.startedTimer = false;
        });
        return true;
    }
}
