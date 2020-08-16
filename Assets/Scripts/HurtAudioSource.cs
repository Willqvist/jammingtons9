using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtAudioSource : MonoBehaviour
{

    public Hurt hurt;
    public AudioSource source;
    private float pitch = 0;

    private bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        pitch = source.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying && dead)
        {
            Destroy(this.gameObject);
        }
        if(!dead)
        this.transform.position = hurt.transform.position;
    }

    public void Play()
    {
        source.pitch = pitch + ((Random.value * 2) - 1)*0.06f;
        source.Play();
    }

    public void setup(Hurt hurt)
    {
        this.hurt = hurt;
        hurt.onDeath.AddListener(() =>
        {
            dead = true;
        });
}
}
