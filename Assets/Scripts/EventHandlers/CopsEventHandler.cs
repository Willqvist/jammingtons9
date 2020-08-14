using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopsEventHandler : MonoBehaviour
{
    public SpawnPosition[] spawnLocations;
    
    public void StartEventHandler()
    {
        foreach(var spawnLocation in spawnLocations)
        {
            spawnLocation.StartSpawning();
        }
    }
}
