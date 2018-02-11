using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderActivator : MonoBehaviour
{

    private DialogueManager dialogueManager;

    // Use this for initialization
    void Start()
    {
        dialogueManager = gameObject.GetComponent<DialogueManager>();
        dialogueManager.onDialogueEndedCallback += DialogueEnded;
    }

    void DialogueEnded()
    {
        gameObject.GetComponent<FaderNegative>().enabled = true;
    }
}
