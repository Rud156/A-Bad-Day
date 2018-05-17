using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public enum Direction
    {
        xAxis,
        yAxis,
        zAxis
    };

    public Direction direction;
    public float rotationSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case Direction.xAxis:
                gameObject.transform.Rotate(Vector3.right * rotationSpeed);
                break;

            case Direction.yAxis:
                gameObject.transform.Rotate(Vector3.up * rotationSpeed);
                break;

            case Direction.zAxis:
                gameObject.transform.Rotate(Vector3.forward * rotationSpeed);
                break;
        }
    }
}
