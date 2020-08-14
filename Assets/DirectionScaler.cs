using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DirectionHolder))]
public class DirectionScaler : MonoBehaviour
{
    public Transform targetToScale;

    private DirectionHolder directionHolder;

    private void Start()
    {
        this.directionHolder = this.GetComponent<DirectionHolder>();
        this.directionHolder.onSetDirection.AddListener(() =>
        {
            this.targetToScale.localScale = new Vector3(this.directionHolder.Direction.x * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        });
    }
}
