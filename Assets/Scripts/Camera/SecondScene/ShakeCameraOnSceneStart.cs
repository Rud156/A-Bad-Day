using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ShakeCameraOnSceneStart : MonoBehaviour
{
    public float startDelayTime = 2f;

    private CameraShakeInstance cameraShakeInstance;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ShakeCameraTwice());
    }

    IEnumerator ShakeCameraTwice()
    {
        yield return new WaitForSeconds(startDelayTime);

        cameraShakeInstance = CameraShaker.Instance.StartShake(4, 3, 0.5f);
        yield return new WaitForSeconds(1);
        cameraShakeInstance.StartFadeOut(5);
        yield return new WaitForSeconds(10);

        cameraShakeInstance = CameraShaker.Instance.StartShake(1, 3, 0.1f);
        yield return new WaitForSeconds(3);
        cameraShakeInstance.StartFadeOut(2);
        yield return new WaitForSeconds(3);
    }
}
