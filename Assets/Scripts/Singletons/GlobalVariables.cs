using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    private static GlobalVariables instance;
    public static GlobalVariables Instance => instance;

    public bool PlayerIsStunned { get; set; }
    public bool GameIsPaused { get; set; }
    public int PlayerHealth { get; set; }

    private void Awake()
    {
        instance = this;
        GlobalVariables.Instance.PlayerHealth = 3;
    }
}
