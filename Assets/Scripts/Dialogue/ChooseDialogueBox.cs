﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseDialogueBox : MonoBehaviour
{
    public HorizontalLayoutGroup layoutGroup;

    public Button buttonPrefab;

    public RectTransform l, r;
    
    private ChooseDialogueBox instance;

    private Action<string> callback;

    private bool started;

    private float time = 0;
    private float startTime = 0;

    private bool active = false;

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

    private Vector3 scale = new Vector3(1,1,1);
    
    private void Update()
    {
        if (active)
        {
            this.time -= Time.deltaTime;
            float percentComplete = this.time / startTime;
            scale.x = percentComplete;
            l.localScale = scale;
            r.localScale = scale;
            if (this.time <= 0)
            {
                active = false;
                this.instance.callback(null);
            }
        }
    }

    public GameObject getInstance()
    {
        return instance.gameObject;
    }
    
    // Start is called before the first frame update
    public void show(string name,float time, params string[] msg)
    {
        this.instance.gameObject.SetActive(true);
        foreach (Transform child in this.instance.layoutGroup.transform) {
            GameObject.Destroy(child.gameObject);
        }

        this.instance.active = true;
        l.localScale = Vector3.one;
        r.localScale = Vector3.one;
        this.instance.time = time;
        this.instance.startTime = time;
        this.instance.scale = new Vector3(1,1,1);
        foreach (var m in msg)
        {
            Button b = Instantiate(buttonPrefab,this.instance.layoutGroup.transform);
            b.gameObject.GetComponentInChildren<Text>().text = m;
            b.onClick.AddListener(() =>
            {
                this.instance.active = false;
                this.instance.callback(m);
            });
        }
        
    }

    public void onClick(Action<string> callback)
    {
        this.instance.callback = callback;
    }
}
