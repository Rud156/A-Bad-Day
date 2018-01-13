using System.Collections;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [Header("Attributes")]
    public float rotationSpeed = 7;
    public float rotationTime = 7;

    [Header("Camera Attributes")]
    public Animator animator;

    private bool rotate = false;

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
        gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        animator.SetBool("ZoomIn", true);
    }

    // Update is called once per frame
    private void Update()
    {
        if (rotate)
            gameObject.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}