using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoSpawnLocation : MonoBehaviour
{
    public GameObject ufo;

    public void Spawn()
    {
        GameObject go = Instantiate(this.ufo);
        go.transform.position = this.transform.position;
    }
}
