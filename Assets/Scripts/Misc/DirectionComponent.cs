using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionComponent : MonoBehaviour
{
    Vector3 oldPosition;

    enum Direction
    {
        LEFT,
        RIGHT
    }

    private Direction direction = Direction.RIGHT;

    private void FixedUpdate()
    {
        Vector2 diff = this.transform.position - oldPosition;

        if(diff.x > 0)
        {
            this.direction = Direction.RIGHT;
        }

        if(diff.x < 0)
        {
            this.direction = Direction.LEFT;
        }
        
        this.oldPosition = this.transform.position;
    }

    public Vector2 GetDirection()
    {
        return this.direction == Direction.RIGHT ? new Vector2(1, 0) : new Vector2(-1, 0);
    }
}
