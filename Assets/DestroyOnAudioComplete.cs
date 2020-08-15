﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAudioComplete : MonoBehaviour
{
    public AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        source.Play();        
    }

    // Update is called once per frame
    void Update()
    {
        if(!source.isPlaying)
            Destroy(this.gameObject);
    }
}
