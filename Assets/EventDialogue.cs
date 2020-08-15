using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDialogue : Dialogue
{
    private static EventDialogue instance;
    public static EventDialogue Instance => instance;

    public CopsEventHandler copsEventHandler;
    public BarrelEventHandler barrelEventHandler;
    public UfoEventHandler ufoEventHandler;

    private string cops = "Even more cops arrived!";
    private string barrels = "Bomb barrels away!";
    private string lava = "Floor is lava";
    private string alien = "Alien attack!";

    private string ak47 = "Ak47";
    private string Raygun = "Raygun";
    private string Bazooka = "Bazooka";

    private void Awake()
    {
        instance = this;
    }

    protected override async void dialogue()
    {
        GlobalVariables.Instance.GameIsPaused = true;
        await this.showContinue("Oh and you know, you know what happened next");
        var result = await this.showOptions(5f, "Well you see, what happened next was...", cops, barrels, lava, alien);

        await this.showContinue("Oh and he ofcourse had a different gun because you know haha he loves them so much");

        var gun = await this.showOptions(5f, "The gun that he used you know was", ak47,Raygun,Bazooka);
        
        SpawnPosition.Haha = true;

        if(gun != null)
        {
            if (gun.Equals(ak47))
            {
                PlayerWeaponLibrary.Instance.GiveGun(PlayerWeaponLibrary.Instance.Ak47);
            }

            if (gun.Equals(Raygun))
            {
                PlayerWeaponLibrary.Instance.GiveGun(PlayerWeaponLibrary.Instance.Raygun);
            }

            if (gun.Equals(Bazooka))
            {
                PlayerWeaponLibrary.Instance.GiveGun(PlayerWeaponLibrary.Instance.bazooka);
            }
        }

        if(result != null)
        {
            if (result.Equals(cops))
            {
                this.copsEventHandler.StartEventHandler();
                EventMessage.Instance.ChangeEventMessage("COPS INBOUND!");
            }
            if (result.Equals(barrels))
            {
                this.barrelEventHandler.StartEventHandler();
                EventMessage.Instance.ChangeEventMessage("BaRreLs");
            }
            if (result.Equals(lava))
            {

            }
            if(result.Equals(alien))
            {
                this.ufoEventHandler.StartEvent();
                EventMessage.Instance.ChangeEventMessage("ALIEN ATTACK");
            }
        }

        end();

        GlobalVariables.Instance.GameIsPaused = false;

        Timer.Instance.StartTimer("NextEventTimer", 15f, () => 
        {
            this.GetComponent<EasyDialogue>().BeginDialogue();
        });
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
