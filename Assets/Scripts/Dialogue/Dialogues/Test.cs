using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Test : Dialogue
{
    public AudioSource plop;
    public GameObject prison;
    public Light2D globalLight;
    protected override async void dialogue()
    {
        end();
        EventDialogue.Instance.GetComponent<EasyDialogue>().BeginDialogue();
        return;

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
        result = await this.showOptions(10f, "Your gramps he really liked his guns... he would always play around with them as a child, but as an adult, he used them to", "Escape Prison");

        await this.wait(0.01f);
        this.plop.Play();

        if (result.Equals("Escape Prison"))
        {
            globalLight.intensity = 0.45f;
            prison.SetActive(true);
        }

        this.close();

        GlobalVariables.Instance.PlayerIsStunned = false;

        await this.wait(2f);

        GlobalVariables.Instance.PlayerIsStunned = true;

        await this.showOptions(10f, "He was sitting there... waiting for days, for something to happen, but then a", "Cop showed up!");

        GlobalVariables.Instance.PlayerIsStunned = false;

        this.close();

        GameObject go = Instantiate(PrefabRepository.Instance.guard);
        go.transform.position = SpawnPositions.Instance.spawnPositions[0].transform.position;

        await this.waitForMethod(go.GetComponent<Hurt>().onDeath);

        await this.wait(1f);

        GlobalVariables.Instance.PlayerIsStunned = true;

        await this.showContinue("...And then he killed him!");

        GlobalVariables.Instance.PlayerIsStunned = false;

        await this.showContinue("After this more cops and other shenanigans just kept coming.. and coming... You'll see");

        await this.wait(2);

        EventDialogue.Instance.GetComponent<EasyDialogue>().BeginDialogue();

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
