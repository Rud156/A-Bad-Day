using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInOneDirection : MonoBehaviour
{

    public enum Direction
    {
        xAxis,
        yAxis,
        zAxis
    };

    [Header("Movement Values")]
    public float moveDistance;
    public float movementSpeed;
    public Direction direction;

    private float startingAxisPosition;
    private bool stopMoving;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        stopMoving = false;

        switch (direction)
        {
            case Direction.xAxis:
                startingAxisPosition = gameObject.transform.position.x;
                break;

            case Direction.yAxis:
                startingAxisPosition = gameObject.transform.position.y;
                break;

            case Direction.zAxis:
                startingAxisPosition = gameObject.transform.position.z;
                break;
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (stopMoving)
            return;

        MoveObject();
        CheckOutOfPosition();
    }

    void MoveObject()
    {
        switch (direction)
        {
            case Direction.xAxis:
                gameObject.transform.Translate(Vector3.right * movementSpeed);
                break;

            case Direction.yAxis:
                gameObject.transform.Translate(Vector3.up * movementSpeed);
                break;

            case Direction.zAxis:
                gameObject.transform.Translate(Vector3.forward * movementSpeed);
                break;
        }
    }

    void CheckOutOfPosition()
    {
        float currentAxisPosition = 0;

        switch (direction)
        {
            case Direction.xAxis:
                currentAxisPosition = gameObject.transform.position.x;
                break;

            case Direction.yAxis:
                currentAxisPosition = gameObject.transform.position.y;
                break;

            case Direction.zAxis:
                currentAxisPosition = gameObject.transform.position.z;
                break;
        }

        if (currentAxisPosition >= startingAxisPosition + moveDistance)
            stopMoving = true;
    }
}
