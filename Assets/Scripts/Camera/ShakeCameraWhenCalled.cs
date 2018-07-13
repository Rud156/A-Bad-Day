using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ShakeCameraWhenCalled : MonoBehaviour
{

    [Header("Camera Shake Stats")]
    public float magnitude = 4f;
    public float roughness = 3f;
    public float fadeInTime = 0.5f;
    public float fadeOutTime = 5f;
    public float totalShakeTime = 2f;


    private CameraShakeInstance cameraShakeInstance;

    public void StartShaking()
    {
        StartCoroutine(StartShake());

    }

    IEnumerator StartShake()
    {
        cameraShakeInstance = CameraShaker.Instance.StartShake(magnitude, roughness, fadeInTime);
        yield return new WaitForSeconds(totalShakeTime);
        cameraShakeInstance.StartFadeOut(fadeOutTime);
    }

}
