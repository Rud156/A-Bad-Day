using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPosition : MonoBehaviour
{
    [Header("Optional Parameters")]
    public Vector3 resetPosition = Vector3.zero;
    public bool useCheckPoint = false;


    private Rigidbody target;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("ResetGround"))
            return;

        gameObject.transform.SetParent(null);
        target.velocity = Vector3.zero;
        if (!useCheckPoint)
            target.transform.position = resetPosition;
        else
            target.transform.position = Core.currentCheckPoint;
    }
}
