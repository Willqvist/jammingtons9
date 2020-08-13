using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogue : MonoBehaviour
{

    private bool readyForDialogue;

    public float rotationSpeed = 2;
    public DialogueManager manager;
    public string name = "Unamed";
    
    private bool inDialogue = false;
    private Vector3 startForward;
    // Start is called before the first frame update
    void Start()
    {
        startForward = this.transform.forward;
    }

    void lookAt(Vector3 Point)
    {
        
        Vector3 direction = transform.position - Point;
        Quaternion oldRot = transform.rotation;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        float dot = Vector3.Dot(startForward, this.transform.forward);
        if (dot < 0.6)
        {
            this.transform.rotation = oldRot;
            return;
        }

        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, eulerRotation.y, 0);
    }

    public void onReadyDialogue(bool val)
    {
        readyForDialogue = val;
    }

    public void onDialogueBegin()
    {
        if (inDialogue) return;
        GlobalVariables.Instance.PlayerIsStunned = true;
        inDialogue = true;
        manager.showDialogue(name,() =>
        {
            inDialogue = false;
        });
    }

}
