using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableBlock : MonoBehaviour {
    [SerializeField] float range;
    [SerializeField] float startingInterpolationPoint;

    float leftPoint;
    float rightPoint;

	// Use this for initialization
	void Start () {
        float startingPoint = range * startingInterpolationPoint;
        
        leftPoint = transform.position.x - startingPoint;
        rightPoint = leftPoint + range;
	}
	
    public void Move(float speed)
    {
        float newXPosition = transform.position.x + speed;

        newXPosition = Mathf.Clamp(newXPosition, leftPoint, rightPoint);
        
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }
}
