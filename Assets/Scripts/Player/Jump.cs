using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float jumpVelocity;

    private Rigidbody target;

    // Use this for initialization
    void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.transform.SetParent(null);
            target.velocity = Vector3.up * jumpVelocity;
        }
    }
}
