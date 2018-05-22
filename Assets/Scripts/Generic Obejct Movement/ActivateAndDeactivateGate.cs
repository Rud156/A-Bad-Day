using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAndDeactivateGate : MonoBehaviour
{

    public MoveInOneDirection movementScriptFirst;
    public MoveInOneDirection movementScriptSecond;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (!target || !other.CompareTag("Player"))
            return;

        movementScriptSecond.DeactivateMovement();
        movementScriptFirst.ActivateMovement();
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (!target || !other.CompareTag("Player"))
            return;

        movementScriptFirst.DeactivateMovement();
        movementScriptSecond.ActivateMovement();
    }

}
