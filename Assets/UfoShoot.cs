﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoShoot : MonoBehaviour
{
    public Gun gun;
    public GameObject splat;
    public AudioSource shootAudio;
    private void Start()
    {
        StartTimer();
    }
    void StartTimer()
    {
        Timer.Instance.StartTimer("edffsd", 2f, () =>
        {

        });
    }

    public void Shoot()
    {
        gun.Shoot(Vector2.down);
        StartTimer();
        shootAudio.Play();
        //Debug.Log("Wew");
    }

    public void Splat()
    {
        GameObject go = Instantiate(this.splat);
        go.transform.position = this.transform.position;
    }
}
