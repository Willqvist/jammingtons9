using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Dialogue
{
    // Start is called before the first frame update
    protected override void onStart()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override async void dialogue()
    {
        await this.showContinue("Hello");
        string res = await this.showOptions(2f, "Hello", "hello2");
        await this.showContinue("You chose " + res);
        res = await this.showOptions(22f, "Hello", "hello2","Hello3");
        end();
    }
}
