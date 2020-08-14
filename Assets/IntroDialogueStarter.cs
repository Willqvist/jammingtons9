using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogueStarter : MonoBehaviour
{
    void Start()
    {
        Timer.Instance.StartTimer("wew", 1, () => 
        {
            this.GetComponent<EasyDialogue>().BeginDialogue();
        });
    }
}
