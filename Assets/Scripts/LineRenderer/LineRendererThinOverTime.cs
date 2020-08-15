using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererThinOverTime : MonoBehaviour
{
    public string timerName;
    public LineRenderer lineRenderer;
    public float duration;

    private void Start()
    {
        Timer.Instance.StartTimer(timerName, this.duration, () =>
        {
            Destroy(this.gameObject);
        });
    }

    private void Update()
    {
        this.lineRenderer.startWidth = Timer.Instance.GetTimer(timerName).duration;
        this.lineRenderer.endWidth = this.lineRenderer.startWidth;
    }
}
