﻿using System.Collections;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [Header("Attributes")]
    public float rotationSpeed = 7;
    public float rotationTime = 7;

    [Header("Camera Attributes")]
    public Animator animator;
    public float dampenTime = 5;

    private bool rotate = false;
    private bool animationComplete = false;

    private void Start()
    {
        StartCoroutine(StartRotation());
    }

    private IEnumerator StartRotation()
    {
        yield return new WaitForSeconds(1.99f);
        rotate = true;

        yield return new WaitForSeconds(rotationTime);
        rotate = false;
        animationComplete = true;
        
        yield return new WaitForSeconds(0.99f);
        animationComplete = false;
        animator.SetBool("ZoomIn", true);
    }

    // Update is called once per frame
    private void Update()
    {
        if (rotate)
            gameObject.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        if (animationComplete)
            gameObject.transform.rotation = Quaternion.Slerp(
                gameObject.transform.rotation,
                Quaternion.Euler(Vector3.zero),
                dampenTime * Time.deltaTime
                );
    }
}