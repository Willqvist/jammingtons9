using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform spawn;

    public int size;
    
    public Vector2 between;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            var obj = Instantiate(spawn);
            obj.transform.position = new Vector3(between.x+Random.value*(between.y-between.x),4,0);
                
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
