using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWave : MonoBehaviour
{
    public enum Direction
    {
        xAxis,
        yAxis,
        zAxis
    };

    [Header("General Stats")]
    public float maxEndPosition;
    public float duration;
    public Direction direction;


    private Vector3 startPosition;
    private Vector3 endPosition;
    private float fixedEndPosition;

    void Start()
    {
        startPosition = gameObject.transform.position;
        switch (direction)
        {
            case Direction.xAxis:
                fixedEndPosition = startPosition.x + maxEndPosition;
                endPosition = new Vector3(fixedEndPosition, startPosition.y, startPosition.z);
                break;
            case Direction.yAxis:
                fixedEndPosition = startPosition.y + maxEndPosition;
                endPosition = new Vector3(startPosition.x, fixedEndPosition, startPosition.z);
                break;
            case Direction.zAxis:
                fixedEndPosition = startPosition.z + maxEndPosition;
                endPosition = new Vector3(startPosition.x, startPosition.y, fixedEndPosition);
                break;
        }
    }

    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(startPosition, endPosition,
            Mathf.PingPong(Time.time / duration, 1));
    }
}
