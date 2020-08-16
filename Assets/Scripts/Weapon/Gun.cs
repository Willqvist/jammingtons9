using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Gun : Weapon
{
    public GameObject projectile;
    public Transform shootOrigin;
    public float cooldownBetweenProjectiles;
    public AudioSource audio;
    public float varyPitch = 0.08f;
    private bool startedTimer;
    private Animator animator;

    private float pitch = 0;
    public Sprite shellSprite;

    private void Start()
    {
        if (audio != null)
            pitch = audio.pitch;
        this.animator = GetComponent<Animator>();
    }

    public void delayStart(float delay)
    {
        this.startedTimer = true;
        Timer.Instance.StartTimer(this.gameObject.GetInstanceID()+"-delay", delay, () => 
        {
            this.startedTimer = false;
        });
    }

    public bool Shoot(Vector2 shootDirection)
    {
        if(this.startedTimer == true)
        {
            return false;
        }

        if (audio != null)
        {
            audio.pitch = pitch + ((Random.value * 2) - 1)*varyPitch;
            audio.Play();
        }

        this.animator.Play("Recoil",-1,0);
        GameObject go = Instantiate(this.projectile);
        go.transform.position = shootOrigin.position;
        go.GetComponent<DirectionHolder>().Direction = shootDirection;
        go.GetComponent<DamageDealer>().Damage = this.weaponData.damage;

        this.startedTimer = true;
        Timer.Instance.StartTimer(this.gameObject.GetInstanceID()+"", this.cooldownBetweenProjectiles, () => 
        {
            this.startedTimer = false;
        });
        return true;
    }
}
