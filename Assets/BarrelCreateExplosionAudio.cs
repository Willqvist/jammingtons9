using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCreateExplosionAudio : MonoBehaviour
{
    public GameObject audioPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateAudio()
    {
        Instantiate(audioPrefab);
    }
}
