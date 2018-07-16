using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpOnPlayer : MonoBehaviour
{

    [Header("Player To Target")]
    public GameObject player;

    [Header("Jump Stats")]
    public float jumpUpSpeed = 4f;


    private Vector3 playerCurrentPosition;
    private bool startJump;
    private Rigidbody target;

    // Use this for initialization
    void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
        startJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startJump)
            return;


    }

    void TriggerJump()
    {
        if (startJump)
            return;

        playerCurrentPosition = player.transform.position;
        startJump = true;
    }
}
