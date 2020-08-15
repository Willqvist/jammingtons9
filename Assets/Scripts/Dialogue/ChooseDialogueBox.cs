using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseDialogueBox : MonoBehaviour
{
    public HorizontalLayoutGroup layoutGroup;

    public Button buttonPrefab;

    public RectTransform l, r;

    public Text content;

    public Text title;

    private ChooseDialogueBox instance;

    private Action<string> callback;

    private bool started;

    private float time = 0;
    private float startTime = 0;

    private bool active = false;
    private bool isFinishedWithTypewriter;

    [HideInInspector] public int selectedButtonIndex;
    [HideInInspector] public int maxButtons;
    [HideInInspector] public List<Button> buttons = new List<Button>();

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
            if (!TypeWriter.Instance.IsFinished() && Input.GetKeyDown(KeyCode.Z))
            {
                TypeWriter.Instance.Speedup();
            }

            if (TypeWriter.Instance.IsFinished())
            {
                this.instance.layoutGroup.gameObject.SetActive(true);
            }
            else
            {
                TypeWriter.Instance.Update();
                return;
            }

            this.time -= Time.deltaTime;
            float percentComplete = this.time / startTime;
            scale.x = percentComplete;
            l.localScale = scale;
            r.localScale = scale;
            if (this.time <= 0)
            {
                active = false;
                this.instance.buttons[this.instance.selectedButtonIndex].onClick.Invoke();
                //this.instance.callback(null);
            }

            if(maxButtons == 0)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.instance.selectedButtonIndex--;
                if(this.instance.selectedButtonIndex <= 0)
                {
                    this.instance.selectedButtonIndex = maxButtons;
                }
                this.instance.selectedButtonIndex %= maxButtons;
            }

            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.instance.selectedButtonIndex++;
                this.instance.selectedButtonIndex %= maxButtons;
            }

            if(Input.GetKeyDown(KeyCode.Z))
            {
                this.instance.buttons[this.instance.selectedButtonIndex].onClick.Invoke();
            }

            int index = 0;
            foreach(var b in this.instance.buttons)
            {
                Image i = b.GetComponent<Image>();
                i.color = new Color(i.color.r, i.color.g, i.color.b, 0);

                if(index == this.instance.selectedButtonIndex)
                {
                    i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
                }
                index++;
            }
        }
    }

    public GameObject getInstance()
    {
        return instance.gameObject;
    }
    
    // Start is called before the first frame update
    public void show(string name,float time, string content, params string[] msg)
    {
        TypeWriter.Instance.Start(content, (callbackText) =>
        {
            //Update
            this.instance.content.text = callbackText;
        });

        this.instance.title.text = name;
        this.instance.selectedButtonIndex = 0;
        this.instance.buttons.Clear();
        this.instance.maxButtons = msg.Length;
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
            this.instance.buttons.Add(b);
        }
        this.instance.layoutGroup.gameObject.SetActive(false);
    }

    public void onClick(Action<string> callback)
    {
        this.instance.callback = callback;
    }
}
