using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableBlock : MovableBlock
{
	protected override void DerivedClassStart(float initialPoint)
    {
        startingPoint = transform.position.x - initialPoint;
        endPoint = startingPoint + range;
	}
	
    public override void Move(float speed)
    {
        float newXPosition = transform.position.x + speed;

        newXPosition = Mathf.Clamp(newXPosition, startingPoint, endPoint);
        
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }
}
