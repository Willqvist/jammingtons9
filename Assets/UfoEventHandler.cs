using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoEventHandler : MonoBehaviour
{
    public UfoSpawnLocation[] spawnLocations;
    public void StartEvent()
    {
        foreach(var s in spawnLocations)
        {
            s.Spawn();
        }
    }
}
