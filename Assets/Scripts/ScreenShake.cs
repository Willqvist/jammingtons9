using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float radius;
    public float intensity;
    public float duration;

    public bool hasParent = false;
    
    private Vector3 originalCameraPosition;
    private CameraFollow follow;

    private Vector3 screenShake = new Vector3(0,0,0);
    private string name,parent;
    private void Start()
    {
        this.name = this.gameObject.name;
        this.parent = this.transform.parent != null ? this.transform.parent.name : "null";
        this.follow = Camera.main.GetComponent<CameraFollow>();
        originalCameraPosition = Camera.main.transform.position;
        Timer.Instance.StartTimer("ScreenShake", duration, () =>
        {
            Camera.main.transform.position = new Vector2(0, Camera.main.transform.position.y);
            Debug.Log("NAME:" + name + " | " + parent);
            if(!hasParent)
                Destroy(this.gameObject);
        });
    }

    private void Update()
    {
        screenShake = new Vector3(Random.Range(-radius * intensity, radius * intensity), Random.Range(-radius * intensity, radius * intensity), 0);
        this.follow.transform.position = new Vector3(this.follow.transform.position.x+Mathf.Clamp(screenShake.x, -radius, radius), this.follow.transform.position.y+Mathf.Clamp(screenShake.y, -radius, radius), Camera.main.transform.position.z);
    }

    public void GetShotAtScreenShakeTemplate()
    {
        this.duration = 0.1f;
        this.intensity = 0.2f;
        this.radius = 0.2f;
    }
}
