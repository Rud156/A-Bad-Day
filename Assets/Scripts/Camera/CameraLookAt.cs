using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [Range(0, 10)]
    public float damping = 5f;

    [Header("Target")]
    public Transform lookAtTarget;

    // Update is called once per frame
    private void Update()
    {
        var position = lookAtTarget.position - gameObject.transform.position;
        var newRotation = Quaternion.LookRotation(position);
        gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, damping * Time.deltaTime);
    }
}