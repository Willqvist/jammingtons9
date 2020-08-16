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
    private bool goDown = false;

    private void Start()
    {
        orgPos = lava.transform.position;
    }

    public void StartEvent()
    {
        this.goDown = false;
        this.isLavaAtTop = false;
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
        if (goDown)
        {
            if (lava.transform.position.y > orgPos.y)
            {
                lava.transform.position -= new Vector3(0, 1f * Time.deltaTime);
            }
            else
            {
                EventDialogue.Instance.startNext(1);
                goDown = false;
            }
        }

        if (!eventHasStarted)
            return;

        if (lava.transform.position.y < lavaTarget.transform.position.y)
            lava.transform.position += new Vector3(0, 0.5f * Time.deltaTime);
        else
        {
            Destroy(inst.gameObject);
            //lava.transform.position = orgPos;
            if(!isLavaAtTop)
            {
                Timer.Instance.StartTimer("fsfdsfs", 5f, () =>
                {
                    goDown = true;
                    GlobalVariables.Instance.lavaSurvived++;
                    ScoreUI.instance.setScore(ScoreScreen.calcTot());
                });
                eventHasStarted = false;
                isLavaAtTop = true;
            }
        } 
    }
}
