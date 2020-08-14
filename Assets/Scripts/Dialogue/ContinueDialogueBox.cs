using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueDialogueBox : MonoBehaviour
{
    public Text textField;
    
    public Text nameField;

    public GameObject continueField;

    private ContinueDialogueBox instance;

    private Action callback = null;

    private bool started;

    private void Start()
    {
    }

    public void setup()
    {
        Transform parent = GameObject.FindGameObjectWithTag("DialogueEntryCanvas").transform;
        this.instance = Instantiate(this, parent);
        this.instance.instance = this.instance;
        this.instance.gameObject.SetActive(false);
    }

    public GameObject getInstance()
    {
        return instance.gameObject;
    }
    
    // Start is called before the first frame update
    public void show(string name, string text)
    {
        this.instance.nameField.text = name;
        this.instance.gameObject.SetActive(true);
        this.instance.continueField.SetActive(false);
        
        this.instance.callback = null;
        TypeWriter.Instance.Start(text, (callbackText) => 
        {
            //Update
            this.instance.textField.text = callbackText;
            this.instance.started = true;
        });
    }

    private void Update()
    {
        if (this.instance.continueField.activeInHierarchy && Input.GetKeyDown(KeyCode.Z) && this.callback != null)
        {
            var cb = this.callback;
            this.callback = null;
            cb();
        }

        if (this.started && !this.instance.continueField.activeInHierarchy && Input.GetKeyDown(KeyCode.Z))
        {
            TypeWriter.Instance.Speedup();
        }

        if(TypeWriter.Instance.IsFinished())
        {
            this.continueField.SetActive(true);
            this.started = false;
        }

        TypeWriter.Instance.Update();
    }

    public void onClick(Action callback)
    {
        this.instance.callback = callback;
    }
}

public class TypeWriter
{
    private static TypeWriter instance = new TypeWriter();
    public static TypeWriter Instance => instance;

    private Action<String> updateCallback;
    private float originalTime = 0.025f;
    private float delayBetweenTicks = 0.025f;
    private String fullText;
    private String segmentedText;
    private int index;
    private bool started;
    private bool isSpedUp;
    private bool isFinished;

    public void Start(String text, Action<String> updateCallback)
    {
        this.started = true;
        this.isFinished = false;
        this.segmentedText = "";
        this.fullText = text;
        this.updateCallback = updateCallback;
        this.isSpedUp = false;
        this.index = 0;
        this.originalTime = 0.025f;
        this.delayBetweenTicks = 0.025f;
    }

    public void Update()
    {
        if(!this.started)
        {
            return;
        }

        this.delayBetweenTicks -= Time.deltaTime;
        if(this.delayBetweenTicks <= 0)
        {
            this.delayBetweenTicks = this.originalTime;

            if(index >= fullText.Length - 1)
            {
                this.Finish();
                return;
            }

            this.segmentedText += fullText[index];
            index++;
            if(fullText[index] == '<')
                while (fullText[index++] != '>');
            this.updateCallback(this.segmentedText);
        }
    }

    public void Speedup()
    {
        this.isSpedUp = true;
        this.delayBetweenTicks = 0f;
        this.originalTime = 0f;
    }

    public bool IsSpedUp()
    {
        return this.isSpedUp;
    }

    public void Finish()
    {
        this.segmentedText = this.fullText;
        this.updateCallback.Invoke(this.segmentedText);
        this.started = false;
        this.isFinished = true;
    }

    public bool IsFinished()
    {
        return this.isFinished;
    }
}
