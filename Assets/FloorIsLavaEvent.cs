using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIsLavaEvent : MonoBehaviour
{
    public GameObject lava;

    public GameObject lavaTarget;
    public GameObject screenshake;
    private ScreenShake inst;

    private bool eventHasStarted;
    private bool isLavaAtTop = false;

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
            Debug.Log("Haha");
            if (!isLavaAtTop)
                Destroy(inst.gameObject);
            isLavaAtTop = true;
        }      
    }
}
