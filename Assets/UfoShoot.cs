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

    public void Death()
    {
        GlobalVariables.Instance.aliensDeath++;
        ScoreUI.instance.setScore(ScoreScreen.calcTot());
    }
}
