using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{

    [Header("Jump Fall Rates")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2;

    private Rigidbody target;

    // Use this for initialization
    void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (PlayerData.stopPlayerMovement)
            return;

        if (target.velocity.y < 0)
        {
            target.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (target.velocity.y > 0 &&
            !(Input.GetKeyDown(ControlConstants.jumpButtonKeyboard) || Input.GetKeyDown(ControlConstants.jumpButtonJoystick))
        )
        {
            target.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
