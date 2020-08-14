using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositions : MonoBehaviour
{
    private static SpawnPositions instance;
    public static SpawnPositions Instance => instance;
    public GameObject[] spawnPositions;

    private void Awake()
    {
        instance = this;
    }
}
