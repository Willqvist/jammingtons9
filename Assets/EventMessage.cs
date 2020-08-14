using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventMessage : MonoBehaviour
{
    private static EventMessage instance;
    public static EventMessage Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeEventMessage(string msg)
    {
        this.GetComponent<TextMeshProUGUI>().enabled = true;
        this.GetComponent<TextMeshProUGUI>().text = msg;
        this.PlayAnimation();
        Timer.Instance.StartTimer("wew2", 2f, () => 
        {
            this.GetComponent<TextMeshProUGUI>().enabled = false;
        });
    }

    public void PlayAnimation()
    {
        this.GetComponent<Animator>().Play("NextEventAnimation");
    }
}
