using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DirectionHolder : MonoBehaviour
{
    private Vector2 direction;
    public Vector2 Direction
    {
        get
        {
            return direction;
        }
        set
        {
            direction = value;
            this.HasSetDirection = true;
            this.onSetDirection.Invoke();
        }
    }
    public bool HasSetDirection { get; set; }

    [HideInInspector] public UnityEvent onSetDirection;
}
