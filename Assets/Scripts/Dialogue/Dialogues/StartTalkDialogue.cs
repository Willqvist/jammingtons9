using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTalkDialogue : Dialogue
{

    public SceneFader fader;
    
    protected override void onStart()
    {
        base.onStart();
        setupDialogue("none", () => { });
    }

    protected override async void dialogue()
    {
        await this.wait(2);
        await this.showContinue("Child", "Dad! Dad! Tell me about that story again back in Mexico 1987!");
        await this.showContinue("Dad", "Okay Son, but it was along time ago so i will have to try hard to bring back my memories.");
        await this.showContinue("Dad", "It first started when...");
        end();
        fader.Fade();
    }
}
