using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private int currentScore = 0;
    public Text score;
    public static ScoreUI instance;

    private void Awake()
    {
        instance = this;
    }

    public void setScore(int score)
    {
        this.score.text = score+"";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
