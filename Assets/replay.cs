using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replay : MonoBehaviour
{
    public GameObject sewer;
    public GameObject dialog;
    public GameObject player;

    private void Start()
    {
        Timer.Instance.StartTimer("fsdfs", 1, () =>
        {
            if (GlobalVariables.replay)
            {
                sewer.SetActive(true);
                dialog.GetComponent<Test>().end();
                dialog.SetActive(false);
                player.SetActive(true);
                EventDialogue.Instance.GetComponent<EasyDialogue>().BeginDialogue();
                Debug.Log("WHY");
            }
        });
    }
}
