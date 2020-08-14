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
    }

    private void Update()
    {
        if(!this.directionHolder.HasSetDirection)
        {
            return;
        }

        this.targetToScale.localScale = new Vector3(Mathf.Sign(this.directionHolder.Direction.x), transform.localScale.y, transform.localScale.z);
    }
}
