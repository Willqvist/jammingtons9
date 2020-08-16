using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDialogue : Dialogue
{
    private static EventDialogue instance;
    public static EventDialogue Instance => instance;
    public AudioSource plopp;
    public CopsEventHandler copsEventHandler;
    public BarrelEventHandler barrelEventHandler;
    public UfoEventHandler ufoEventHandler;
    public FloorIsLavaEvent floorIsLavaEventHandler;
    public bool canStartNextEvent = true;

    private string cops = "Even more cops arrived!";
    private string barrels = "Bomb barrels away!";
    private string lava = "Floor is lava";
    private string alien = "Alien attack!";

    private string ak47 = "Ak47";
    private string Raygun = "Raygun";
    private string Bazooka = "Bazooka";
    private string pistol = "Pistol";

    private string text = "Well you see, what happened next was...";
    private string text1 = "The gun that he used you know was";

    private void Awake()
    {
        instance = this;
    }

    protected override async void dialogue()
    {
        SpawnPosition.stop = false;
        GlobalVariables.Instance.GameIsPaused = true;

            var rand = Random.Range((int) 0, (int) 3);

            await this.showContinue("Oh and you know, you know what happened next");

            var result = "";
            var gun = "";

            if (rand == 0)
            {
                result = await this.showOptions(5f, this.text, cops, barrels, lava);
            }

            if (rand == 1)
            {
                result = await this.showOptions(5f, this.text, lava, alien);
            }

            if (rand == 2)
            {
                result = await this.showOptions(5f, this.text, cops, lava);
            }

            if (rand == 3)
            {
                result = await this.showOptions(5f, this.text, lava);
            }

            if (rand == 4)
            {
                result = await this.showOptions(5f, this.text, alien);
            }

            plopp.Play();
            if (result != null)
            {
                if (result.Equals(cops))
                {
                    this.copsEventHandler.StartEventHandler();
                    //EventMessage.Instance.ChangeEventMessage("COPS INBOUND!");
                    startNext(15);
                }

                if (result.Equals(barrels))
                {
                    this.barrelEventHandler.StartEventHandler();
                    //EventMessage.Instance.ChangeEventMessage("BaRreLs");
                    startNext(15);
                }

                if (result.Equals(lava))
                {
                    floorIsLavaEventHandler.StartEvent();
                    SpawnPosition.stop = true;
                }

                if (result.Equals(alien))
                {
                    this.ufoEventHandler.StartEvent();
                    //EventMessage.Instance.ChangeEventMessage("ALIEN ATTACK");
                    SpawnPosition.stop = true;
                    startNext(15);
                }
            }

            if (!result.Equals(lava))
            {
                await this.showContinue(
                    "Oh and he ofcourse had a different gun because you know haha he loves them so much");

                SpawnPosition.Haha = true;

                if (rand == 0)
                {
                    gun = await this.showOptions(5f, this.text1, ak47, pistol);
                }

                if (rand == 1)
                {
                    gun = await this.showOptions(5f, this.text1, Bazooka);
                }

                if (rand == 2)
                {
                    gun = await this.showOptions(5f, this.text1, Raygun);
                }

                if (rand == 3)
                {
                    gun = await this.showOptions(5f, this.text1, Bazooka);
                }

                if (rand == 4)
                {
                    gun = await this.showOptions(5f, this.text1, pistol);
                }

                plopp.Play();
                if (gun != null)
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

                    if (gun.Equals(pistol))
                    {
                        PlayerWeaponLibrary.Instance.GiveGun(PlayerWeaponLibrary.Instance.pistol);
                    }
                }
            }

            end();

        GlobalVariables.Instance.GameIsPaused = false;
    }

    public void startNext(int time)
    {
        Timer.Instance.StartTimer("NextEventTimer", time, () =>
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
