using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue entry;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void showDialogue(string npcName, Action action)
    {
        entry.setupDialogue(npcName, action);
    }
}
