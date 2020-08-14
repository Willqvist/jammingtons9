using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float radius;
    public float intensity;
    public float duration;

    private Vector3 originalCameraPosition;
    
    private Vector3 screenShake = new Vector3(0,0,0);
    
    private void Start()
    {
    }

    private void Update()
    {
        screenShake += new Vector3(Random.Range(-radius * intensity, radius * intensity), Random.Range(-radius * intensity, radius * intensity), 0);
        Camera.main.transform.position = new Vector3(originalCameraPosition.x+Mathf.Clamp(screenShake.x, -radius, radius), originalCameraPosition.y+Mathf.Clamp(screenShake.y, -radius, radius), Camera.main.transform.position.z);
    }

    public void GetShotAtScreenShakeTemplate()
    {
        originalCameraPosition = Camera.main.transform.position;

        Timer.Instance.StartTimer(duration, () => 
        {
            Camera.main.transform.position = originalCameraPosition;
            Destroy(this.gameObject);
        });
        this.duration = 0.1f;
        this.intensity = 0.2f;
        this.radius = 0.2f;
    }
}
