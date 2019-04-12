using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableBlock : MonoBehaviour
{
    [SerializeField] protected float range;
    [SerializeField] protected float initialInterpolationPoint;

    protected float startingPoint;
    protected float endPoint;

    // Use this for initialization
    void Start () {
        float initialPoint = range * initialInterpolationPoint;

        DerivedClassStart(initialPoint);
    }

    protected abstract void DerivedClassStart(float startingPoint);

    public abstract void Move(float speed);
}
