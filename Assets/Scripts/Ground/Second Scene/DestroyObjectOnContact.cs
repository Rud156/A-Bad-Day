using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOnContact : MonoBehaviour
{

    public bool destroyParent = false;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (!target || other.CompareTag("Player"))
            return;

        if (destroyParent)
            Destroy(other.transform.parent.gameObject);
        else
            Destroy(other.gameObject);
    }

}
