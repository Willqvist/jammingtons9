using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDialogue : Dialogue
{
    private static EventDialogue instance;
    public static EventDialogue Instance => instance;

    public CopsEventHandler copsEventHandler;

    private string cops = "Even more cops arrived!";
    private string barrels = "Bomb barrels away!";
    private string lava = "Floor is lava";

    private void Awake()
    {
        instance = this;
    }

    protected override async void dialogue()
    {
        var result = await this.showOptions(5f, "Oh and then...", cops, barrels, lava);

        if (result.Equals(cops))
        {
            this.copsEventHandler.StartEventHandler();
            EventMessage.Instance.ChangeEventMessage("COPS INBOUND!");
        }
        if (result.Equals(barrels))
        {

        }
        if (result.Equals(lava))
        {

        }

        end();
    }
}

/*
Cops spawn
Bomb barrels
Alien Attack Ufo
Big Bad Guy
Spawn health pickups
X2 score
Floor is lava
Prison free day
Squirrel attack
Party mode
*/
