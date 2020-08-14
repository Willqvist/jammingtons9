using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float radius;
    public float intensity;
    public float duration;

    private Vector3 originalCameraPosition;

    private void Start()
    {
        originalCameraPosition = Camera.main.transform.position;

        Timer.Instance.StartTimer("ScreenShake", duration, () => 
        {
            Camera.main.transform.position = originalCameraPosition;
            Destroy(this.gameObject);
        });
    }

    private void Update()
    {
        Camera.main.transform.position += new Vector3(Random.Range(-radius * intensity, radius * intensity), Random.Range(-radius * intensity, radius * intensity), 0);
        Camera.main.transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.position.x, -radius, radius), Mathf.Clamp(Camera.main.transform.position.y, -radius, radius), Camera.main.transform.position.z);
    }

    public void GetShotAtScreenShakeTemplate()
    {
        this.duration = 0.1f;
        this.intensity = 0.2f;
        this.radius = 0.2f;
    }
}
