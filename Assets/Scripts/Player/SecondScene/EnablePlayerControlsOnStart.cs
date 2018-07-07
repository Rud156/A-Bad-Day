using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlayerControlsOnStart : MonoBehaviour
{
    private Rigidbody target;

    // Use this for initialization
    void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();

        Core.stopPlayerMovement = false;

        target.isKinematic = false;
        target.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
}
