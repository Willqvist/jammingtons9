using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class EndRoundHandler : MonoBehaviour
{

    public static EndRoundHandler instance;

    public Volume volume;

    public AudioSource dyingSound;
    
    public CanvasGroup group;
    public float speed = 2;
    private Bloom bloom;
    private bool fade = false;
    
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!volume.profile.TryGet<Bloom>(out bloom))
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            group.alpha = Mathf.Lerp(group.alpha, 1, Time.deltaTime * speed);
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 50f, Time.deltaTime * speed);
            if (group.alpha > 0.92)
            {
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene("Score");
                //bloom.intensity.value = 0;
            }
        }
    }

    public void StartEnding()
    {
        dyingSound.Play();
        fade = true;
    }
}
