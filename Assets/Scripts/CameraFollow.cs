using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followY;
    public float speed = 1;
    private Vector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        pos.Set(this.transform.position.x,this.transform.position.y,this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        pos.y = Mathf.Lerp(pos.y, followY.transform.position.y, speed * Time.deltaTime);
        pos.y = Mathf.Max(0, pos.y);
        pos.y = Mathf.Min(5, pos.y);
        this.transform.position = pos;
    }
}
