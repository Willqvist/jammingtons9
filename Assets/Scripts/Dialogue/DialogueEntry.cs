using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueEntry : MonoBehaviour
{

    public Text textField;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setText(string text)
    {
        this.textField.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public DialogueEntry setup(GameObject findGameObjectWithTag)
    {
        return Instantiate(this, findGameObjectWithTag.transform);
    }
}
