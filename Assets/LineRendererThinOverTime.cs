using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererThinOverTime : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float duration;

    private void Start()
    {
        Timer.Instance.StartTimer("LineRendererThinOverTime", this.duration, () =>
        {
            Destroy(this.gameObject);
        });
    }

    private void Update()
    {
        this.lineRenderer.startWidth = Timer.Instance.GetTimer("LineRendererThinOverTime").duration;
        this.lineRenderer.endWidth = this.lineRenderer.startWidth;
    }
}
