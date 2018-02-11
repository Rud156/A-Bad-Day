using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{

    [Header("Canvas Elements")]
    public Image faderImage;

    [Header("Activator")]
    public Animator cameraAnimator;
    public CameraRotator cameraRotator;

    [Header("Required Stats")]
    public float reductionRate = 5;
    
    private float startAlpha = 255;
    private float currentReductionRate;

    // Use this for initialization
    void Awake()
    {
        currentReductionRate = 1;
        cameraRotator.enabled = false;
        cameraAnimator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentReductionRate >= startAlpha)
        {
            cameraAnimator.enabled = true;
            cameraRotator.enabled = true;
            gameObject.GetComponent<Fader>().enabled = false;
            return;
        }

        faderImage.color = new Color(0, 0, 0, (startAlpha - currentReductionRate) / 255);
        currentReductionRate += reductionRate * Time.deltaTime;
    }
}
