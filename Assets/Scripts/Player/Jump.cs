using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float jumpVelocity;

    private Rigidbody target;
    private bool jumpRequest;

    // Use this for initialization
    void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
        jumpRequest = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            jumpRequest = true;
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (StaticPlayerData.currentJumpCount >= StaticPlayerData.maxJumpCount)
        {
            jumpRequest = false;
            return;
        }

        if (jumpRequest)
        {
            jumpRequest = false;
            StaticPlayerData.currentJumpCount += 1;
            gameObject.transform.SetParent(null);
            target.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
    }
}
