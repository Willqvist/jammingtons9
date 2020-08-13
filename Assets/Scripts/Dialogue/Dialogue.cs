using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    private ChooseDialogueBox choosePrefab;
    private ContinueDialogueBox continuePrefab;
    private Action callbackWhenDone;
    private GameObject activeView;

    private static Dialogue activeDialogue;
    
    private string npcName;

    private Vector3 pos;
    
    protected delegate AudioSource AudioMethod();
    
    protected bool disabled = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //yesNoPrefab = DialogueCanvasManager.instance.getYesNo();
        continuePrefab = DialogueCanvasManager.instance.getContinue();
        choosePrefab = DialogueCanvasManager.instance.getChoose();
        onStart();
    }
    

    protected virtual void onStart()
    {
    }


    protected void setAudioProvider(AudioMethod method)
    {
    }

    public virtual void setupDialogue(string npcName, Action action)
    {
        if (disabled)
        {
            action();
            return;
        }

        this.npcName = npcName;
        callbackWhenDone = action;
        activeDialogue = this;
        dialogue();
    }

    public static void forceQuitActiveDialogue()
    {
        activeDialogue?.end();
    }

    protected virtual void dialogue() { }

    public void end()
    {
        if(this.activeView != null)
            this.activeView.SetActive(false);
        this.activeView = null;
        activeDialogue = null;
        callbackWhenDone.Invoke();
    }

    protected Task<string> showOptions(float secondsToChoose, params string[] options)
    {
        if(activeView != null)
            activeView.SetActive(false);
        activeView = choosePrefab.getInstance();
        TaskCompletionSource<string> tcs1 = new TaskCompletionSource<string>();
        choosePrefab.show(npcName,secondsToChoose,options);
        choosePrefab.onClick((val) =>
        {
            tcs1.SetResult(val);
        });
        return tcs1.Task;
    }
    protected Task showContinue(string msg)
    {
        return showContinue(/*audioProvider != null ? audioProvider():DialogueAudio.randomMaleSound()*/null,this.npcName, msg);
    }
    
    protected Task showContinue(AudioSource audio, string msg)
    {
        return showContinue(audio,this.npcName, msg);
    }
    
    protected Task showContinueNoAudio(string msg)
    {
        return showContinue(null,this.npcName, msg);
    }
    protected Task showContinueNoAudio(string name,string msg)
    {
        return showContinue(null,this.npcName, msg);
    }
    protected Task showContinue(string name,string msg)
    {
        return showContinue(/*audioProvider != null ? audioProvider():DialogueAudio.randomMaleSound()*/null,name, msg);
    }
    
    protected Task showContinue(AudioSource audioSource, string name, string msg)
    {
        if(audioSource != null)
            audioSource.Play();
        TaskCompletionSource<bool> tcs1 = new TaskCompletionSource<bool>();
        if (Dialogue.activeDialogue == null)
        {
            tcs1.SetResult(true);
            return tcs1.Task;
        }

        if(activeView != null)
            activeView.SetActive(false);
        activeView = continuePrefab.getInstance();
        continuePrefab.show(name,msg);

        continuePrefab.onClick(() =>
        {
            tcs1.SetResult(true);
        });
        return tcs1.Task;
    }
}
