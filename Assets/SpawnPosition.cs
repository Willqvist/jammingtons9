using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    public GameObject[] mobPool;
    private bool shouldSpawn = false;

    public void StartSpawning()
    {
        if(this.mobPool.Length <= 0)
        {
            return;
        }

        shouldSpawn = true;

        Timer.Instance.StartTimer("SpawnPosition_2", 20f, () => 
        {
            shouldSpawn = false;
        });

        this.SpawnLoop();
    }

    private void SpawnLoop()
    {
        Timer.Instance.StartTimer("SpawnPosition", Random.Range(5, 10), () =>
        {
            GameObject go = Instantiate(this.mobPool[Random.Range(0, this.mobPool.Length - 1)]);
            go.transform.position = this.transform.position;
            
            if(this.shouldSpawn)
                this.SpawnLoop();
        });
    }
}
