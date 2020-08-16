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
        await this.showContinue("Child", "Dad, what happened to grandpa? Why can't he be around us anymore");
        await this.showContinue("Dad", "Hmmmm.... I'm not sure if you're old enough to hear about the story about grandpa..");
        await this.showContinue("Child", "I promise I'm old enough to hear about it dad! I'm a big boy now!");
        await this.showContinue("Dad", "Alright then... well... it began like this");
        end();
        fader.Fade();
    }
}
