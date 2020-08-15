using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelEventHandler : MonoBehaviour
{
    public BarrelSpawnPosition[] spawnPositions;

    public void StartEventHandler()
    {
        foreach(var spawnPosition in spawnPositions)
        {
            spawnPosition.SpawnBarrel();
        }
    }
}
