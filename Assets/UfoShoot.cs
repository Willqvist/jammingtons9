using System.Collections;
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
        gun.cooldownBetweenProjectiles = gun.cooldownBetweenProjectiles + (Random.value * 2) - 1;
        gun.delayStart(Random.value+0.5f);
    }

    public void Shoot()
    {
        gun.Shoot(Vector2.down);
        shootAudio.Play();

            //Debug.Log("Wew");
    }

    public void Splat()
    {
        GameObject go = Instantiate(this.splat);
        go.transform.position = this.transform.position;
    }
}
