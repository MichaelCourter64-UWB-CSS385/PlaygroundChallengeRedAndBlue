using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeighableBlock : MovableBlock
{
    protected override void DerivedClassStart(float initialPoint)
    {
        startingPoint = transform.position.y - initialPoint;
        endPoint = startingPoint + range;
    }

    public override void Move(float speed)
    {
        float newXPosition = transform.position.y + speed;

        newXPosition = Mathf.Clamp(newXPosition, startingPoint, endPoint);

        transform.position = new Vector3(transform.position.x, newXPosition, transform.position.z);
    }
}
