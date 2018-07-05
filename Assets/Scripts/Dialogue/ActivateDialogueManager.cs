using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogueManager : MonoBehaviour
{

    public ShakeCameraOnTrigger shakeCameraOnTrigger;
    public GameObject dialogueManager;

    // Use this for initialization
    void Start()
    {
        shakeCameraOnTrigger.onCameraShakeEndCallback += ActivateDialogManager;
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        shakeCameraOnTrigger.onCameraShakeEndCallback -= ActivateDialogManager;
    }

    void ActivateDialogManager()
    {
        dialogueManager.SetActive(true);
    }
}
