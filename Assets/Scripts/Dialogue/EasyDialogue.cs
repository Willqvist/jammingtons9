using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyDialogue : MonoBehaviour
{

    public Dialogue dialogue;
    public string name;
    public BoxCollider2D triggerer;

    private NpcDialogue npcDialogue;
    
    // Start is called before the first frame update
    void Start()
    {
        npcDialogue = this.gameObject.AddComponent<NpcDialogue>();
        npcDialogue.manager = this.gameObject.AddComponent<DialogueManager>();
        npcDialogue.manager.entry = dialogue;
        npcDialogue.rotationSpeed = 0;
        npcDialogue.name = name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disable()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player")
        {
            return;
        }

        npcDialogue.onDialogueBegin();
    }
}
