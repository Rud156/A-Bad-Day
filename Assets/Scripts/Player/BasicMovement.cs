using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [Header("Default Speeds")]
    public float movementSpeed = 10f;
    public float rotationSpeed = 10f;

    private Rigidbody target;
    private bool playermovementStopped;

    // Use this for initialization
    void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
        playermovementStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Core.stopPlayerMovement)
            return;

        float moveX = Input.GetAxis(ControlConstants.horizontalAxis);
        target.transform.Rotate(Vector3.up * moveX * rotationSpeed * Time.deltaTime);

        float moveZ = Input.GetAxis(ControlConstants.verticalAxis);
        if (moveZ == 0 && !playermovementStopped)
        {
            target.velocity = Vector3.zero;
            playermovementStopped = true;
        }
        else if (moveZ != 0)
        {
            Vector3 forwardMovement = gameObject.transform.forward * moveZ * movementSpeed * Time.deltaTime;
            target.AddForce(forwardMovement, ForceMode.VelocityChange);
            playermovementStopped = false;
        }
    }
}
