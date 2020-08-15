using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image heart_filled1;
    public Image heart_filled2;
    public Image heart_filled3;

    private void Start()
    {
        heart_filled1.enabled = false;
        heart_filled2.enabled = false;
        heart_filled3.enabled = false;
    }

    private void Update()
    {
        if(GlobalVariables.Instance.PlayerHealth == 3)
        {
            heart_filled1.enabled = true;
            heart_filled2.enabled = true;
            heart_filled3.enabled = true;
        }
        if (GlobalVariables.Instance.PlayerHealth == 2)
        {
            heart_filled1.enabled = true;
            heart_filled2.enabled = true;
            heart_filled3.enabled = false;
        }
        if (GlobalVariables.Instance.PlayerHealth == 1)
        {
            heart_filled1.enabled = true;
            heart_filled2.enabled = false;
            heart_filled3.enabled = false;
        }
        if (GlobalVariables.Instance.PlayerHealth == 0)
        {
            heart_filled1.enabled = false;
            heart_filled2.enabled = false;
            heart_filled3.enabled = false;
        }
    }
}
