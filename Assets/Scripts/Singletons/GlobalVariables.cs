using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    private static GlobalVariables instance;
    public int guardDeath = 0;
    public int barrelsDestroyed = 0;
    public int lavaSurvived = 0;
    public int aliensDeath = 0;
    public static bool replay;
    public static GlobalVariables Instance => instance;

    public bool PlayerIsStunned { get; set; }
    public bool GameIsPaused { get; set; }
    public int PlayerHealth { get; set; }

    private void Awake()
    {
        instance = this;
        Object.DontDestroyOnLoad(instance);
        GlobalVariables.Instance.PlayerHealth = 3;
    }
}
