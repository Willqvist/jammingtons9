using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererSetPosition : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private void Start()
    {
        this.lineRenderer = this.GetComponent<LineRenderer>();
    }

    public void SetPosition(Vector2 start, Vector2 end)
    {
        this.lineRenderer.SetPosition(0, start);
        this.lineRenderer.SetPosition(1, end);
    }
}
