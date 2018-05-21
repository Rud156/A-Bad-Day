using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectOnTriggerPlayer : MonoBehaviour
{
    public MoveInOneDirection movementScript;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (!target || !other.CompareTag("Player"))
            return;

        movementScript.enabled = true;
    }
}
