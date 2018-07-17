using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObjectOnTriggerExitPlayer : MonoBehaviour
{

    public GameObject objectToDeactivate;

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (!target || !other.CompareTag("Player"))
            return;

        objectToDeactivate.SetActive(false);
    }

}
