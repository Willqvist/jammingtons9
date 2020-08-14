using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionComponent : MonoBehaviour
{
    Vector3 oldPosition;
    public Transform target;
    enum Direction
    {
        LEFT,
        RIGHT
    }

    private Direction direction = Direction.RIGHT;

    private void FixedUpdate()
    {
        if(target.localScale.x > 0)
        {
            this.direction = Direction.RIGHT;
        }

        if(target.localScale.x < 0)
        {
            this.direction = Direction.LEFT;
        }
        
    }

    public Vector2 GetDirection()
    {
        return this.direction == Direction.RIGHT ? new Vector2(1, 0) : new Vector2(-1, 0);
    }
}
