using System.Collections;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [Header("Attributes")]
    public float rotationSpeed = 7;
    public float rotationTime = 7;

    [Header("Camera Attributes")]
    public Animator cameraAnimator;
    public float dampenTime = 5;

    [Header("Dialogue Attributes")]
    public GameObject secondaryDialogueManager;

    [Header("Player Attributes")]
    public Animator playerAnimator;
    public float animationTime = 4.49f;

    private bool rotate = false;
    private bool animationComplete = false;

    private void Start()
    {
        StartCoroutine(StartRotation());
    }

    private IEnumerator StartRotation()
    {
        yield return new WaitForSeconds(3.99f);
        rotate = true;

        yield return new WaitForSeconds(rotationTime);
        rotate = false;
        animationComplete = true;

        yield return new WaitForSeconds(0.99f);
        animationComplete = false;
        // animator.SetBool("ZoomIn", true);
        playerAnimator.enabled = true;

        yield return new WaitForSeconds(animationTime);
        playerAnimator.enabled = false;
        secondaryDialogueManager.SetActive(true);
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