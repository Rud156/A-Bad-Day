using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float rotationSpeed = 10f;

    private Rigidbody target;

    // Use this for initialization
    void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticPlayerData.stopPlayerMovement)
            return;

        float moveX = Input.GetAxis("Horizontal");
        target.transform.Rotate(Vector3.up * moveX * rotationSpeed * Time.deltaTime);

        float moveZ = Input.GetAxis("Vertical");
        Vector3 forwardMovement = gameObject.transform.forward * moveZ * movementSpeed * Time.deltaTime;
        target.AddForce(forwardMovement, ForceMode.VelocityChange);
    }
}
