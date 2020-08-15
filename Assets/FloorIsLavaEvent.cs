using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIsLavaEvent : MonoBehaviour
{
    public GameObject lava;
    private Vector3 orgPos = new Vector3();
    public GameObject lavaTarget;
    public GameObject screenshake;
    private ScreenShake inst;

    private bool eventHasStarted;
    private bool isLavaAtTop = false;

    private void Start()
    {
        orgPos = lava.transform.position;
    }

    public void StartEvent()
    {
        eventHasStarted = true;
        GameObject s = Instantiate(screenshake);
        var f = s.GetComponent<ScreenShake>();
        f.duration = 100f;
        f.intensity = 0.1f;
        f.radius = 0.5f;
        inst = f;
        
    }

    private void Update()
    {
        if (!eventHasStarted)
            return;

        if (lava.transform.position.y < lavaTarget.transform.position.y)
            lava.transform.position += new Vector3(0, 0.5f * Time.deltaTime);
        else
        {
            Destroy(inst.gameObject);
            lava.transform.position = orgPos;
            eventHasStarted = false;
            isLavaAtTop = true;
        }      
    }
}
