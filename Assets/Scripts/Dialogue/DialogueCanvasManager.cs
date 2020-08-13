using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCanvasManager : MonoBehaviour
{
    
    public ChooseDialogueBox choosePrefab;
    public ContinueDialogueBox continuePrefab;

    private ChooseDialogueBox chooseInstance;
    private string activeNpcName = "";
    public static DialogueCanvasManager instance;

    private void Awake()
    {
        instance = this;
        choosePrefab.setup();
        continuePrefab.setup();
    }

    public void setActiveNpcName(string name)
    {
        this.activeNpcName = name;
    }
    public ChooseDialogueBox getChoose()
    {
        return choosePrefab;
    }
    
    public ContinueDialogueBox getContinue()
    {
        return continuePrefab;
    }

    public string getActiveNpcName()
    {
        return this.activeNpcName;
    }
}
