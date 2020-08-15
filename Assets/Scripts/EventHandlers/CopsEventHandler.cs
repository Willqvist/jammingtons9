using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopsEventHandler : MonoBehaviour
{
    public SpawnPosition[] spawnLocations;

    public static int multiplier = 0;
    public static float spawnTime = 20f;

    public void StartEventHandler()
    {
        multiplier++;

        foreach (var spawnLocation in spawnLocations)
        {
            spawnLocation.StartSpawning();
        }

        Timer.Instance.StartTimer("wew4", spawnTime, () => 
        {
            multiplier--;
        });
    }
}
