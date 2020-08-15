using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawnPosition : MonoBehaviour
{
    public GameObject barrel;

    public void SpawnBarrel()
    {
        GameObject go = Instantiate(this.barrel);
        go.transform.position = this.transform.position;
    }
}
