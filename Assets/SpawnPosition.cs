using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    public static bool stop = false;
    public GameObject[] mobPool;
    private bool shouldSpawn = false;

    private static bool haha = false;
    public static bool Haha { get { return haha; } set { haha = value; } }

    private bool haha_2;

    private void Update()
    {
        if(Haha && !haha_2)
        {
            SpawnLoop_2();
            haha_2 = true;
        }
    }

    public void StartSpawning()
    {
        if(this.mobPool.Length <= 0)
        {
            return;
        }

        shouldSpawn = true;

        Timer.Instance.StartTimer("SpawnPosition_2", CopsEventHandler.spawnTime, () => 
        {
            shouldSpawn = false;
        });

        this.SpawnLoop();
    }

    private void SpawnLoop()
    {
        for(int i = 0; i < CopsEventHandler.multiplier; i++)
        {
            Timer.Instance.StartTimer("SpawnPosition", Random.Range(2, 5), () =>
            {
                if(!stop)
                {
                    GameObject go = Instantiate(this.mobPool[Random.Range(0, this.mobPool.Length - 1)]);
                    go.transform.position = this.transform.position;
                }

                if (this.shouldSpawn)
                    this.SpawnLoop();
            });
        }
    }

    private void SpawnLoop_2()
    {
        Timer.Instance.StartTimer("SpawnPosition", Random.Range(5, 10), () =>
        {
            if(!stop)
            {
                GameObject go = Instantiate(this.mobPool[Random.Range(0, this.mobPool.Length - 1)]);
                go.transform.position = this.transform.position;
            }

            this.SpawnLoop_2();
        });
    }
}
