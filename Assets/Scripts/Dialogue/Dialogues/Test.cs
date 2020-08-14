﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Dialogue
{
    public AudioSource plop;
    public GameObject pistol;
    public GameObject raygun;
    public GameObject prison;

    protected override async void dialogue()
    {
        await this.showContinue("You see.. Gramps haven't always been as old as useless as he is now, you know, his story starts a long long time ago");
        ObjectActivator.Instance.player.SetActive(true);
        this.close();
        await this.wait(0.01f);
        this.plop.Play();
        await this.wait(1.5f);
        await this.showContinue("Ah yes.. he was a true fighter");
        var result = await this.showOptions(15f, "For the longest time, he was a freedom fighter, a rebel! He always enjoyed playing with a", "Pistol", "Raygun");

        Debug.Log(result);

        if(result.Equals("Pistol"))
        {
            ObjectActivator.Instance.player.GetComponent<PlayerShoot>().Gun = ObjectActivator.Instance.player.GetComponent<PlayerWeaponLibrary>().Ak47;
        }
        if(result.Equals("Raygun"))
        {
            ObjectActivator.Instance.player.GetComponent<PlayerShoot>().Gun = ObjectActivator.Instance.player.GetComponent<PlayerWeaponLibrary>().Raygun;
        }

        await this.wait(0.01f);
        this.plop.Play();

        this.close();
        GlobalVariables.Instance.PlayerIsStunned = false;
        await this.wait(4f);
        GlobalVariables.Instance.PlayerIsStunned = true;
        result = await this.showOptions(10f, "He used this to", "Escape Prison");

        await this.wait(0.01f);
        this.plop.Play();

        if (result.Equals("Escape Prison"))
        {
            prison.SetActive(true);
        }


        end();
    }
}
