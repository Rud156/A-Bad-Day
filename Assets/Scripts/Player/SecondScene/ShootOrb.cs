﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOrb : MonoBehaviour
{

    [Header("Orb Stats")]
    public GameObject orbToShoot;
    public float movementVelocity = 7f;

    [Header("Launch Point")]
    public GameObject launcher;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(ControlConstants.orbLaunchKeyboard) ||
            Input.GetKeyDown(ControlConstants.orbLaunchJoystick))
        {
            if (SecondScene.collectedGlowingOrbs <= 0)
                return;

            Vector3 launchPosition = launcher.transform.position;
            GameObject instantiatedOrb = Instantiate(orbToShoot, launchPosition,
                orbToShoot.transform.rotation);
            Rigidbody orbRigidbody = instantiatedOrb.GetComponent<Rigidbody>();
            orbRigidbody.velocity = gameObject.transform.forward * movementVelocity * Time.deltaTime;

            SecondScene.collectedGlowingOrbs -= 1;
        }
    }
}
