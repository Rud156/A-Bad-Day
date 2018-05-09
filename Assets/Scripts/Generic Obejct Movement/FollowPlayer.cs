using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public enum FollowAxis
    {
        xAxis,
        yAxis,
        zAxis
    }

    public FollowAxis followAxis;

    public GameObject player;

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        Vector3 objectPosition = gameObject.transform.position;

        switch (followAxis)
        {
            case FollowAxis.xAxis:
                objectPosition.x = player.transform.position.x;
                break;

            case FollowAxis.yAxis:
                objectPosition.y = player.transform.position.y;
                break;

            case FollowAxis.zAxis:
                objectPosition.z = player.transform.position.z;
                break;
        }

        gameObject.transform.position = objectPosition;
    }
}
