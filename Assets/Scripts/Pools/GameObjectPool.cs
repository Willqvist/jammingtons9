using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{

    public int maxObjects = 100;

    public GameObject prefab;

    private GameObject[] objects;

    private int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        objects = new GameObject[maxObjects];
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = Instantiate(prefab);
            objects[i].SetActive(false);
        }
    }

    public GameObject pull()
    {
        if (index >= maxObjects)
            index = 0;
        var obj = objects[index++];
        obj.SetActive(true);
        return obj;
    }
}
