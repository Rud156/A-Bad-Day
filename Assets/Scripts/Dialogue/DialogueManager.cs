using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public struct DialogueObject
    {
        public Dialogue dialogue;
        public GameObject dialogueSpeaker;
    }

    [Header("Required Components")]
    public Text nameText;
    public Text dialogueText;
    public RawImage objectImage;

    [Header("Dialogue Panel")]
    public GameObject dialoguePanel;

    [Header("Dialogue Data")]
    public DialogueObject[] dialogueObjects;
    public float waitTimeAfterDialogue = 2;


    private bool sentenceDisplayCompleted;

    void Start()
    {
        sentenceDisplayCompleted = true;
        StartCoroutine(StartDialogue());
    }

    private IEnumerator StartDialogue()
    {
        dialoguePanel.SetActive(true);
        foreach (DialogueObject dialogueObject in dialogueObjects)
        {
            nameText.text = dialogueObject.dialogue.name;
            nameText.color = dialogueObject.dialogue.nameColor;

            objectImage.texture = dialogueObject.dialogue.spriteImage;
            objectImage.color = dialogueObject.dialogue.nameColor;

            if (dialogueObject.dialogueSpeaker != null)
                dialogueObject.dialogueSpeaker.GetComponent<FastObjectJump>().ResetAndPlayJump();

            foreach (string line in dialogueObject.dialogue.sentences)
            {
                StartCoroutine(TypeSentence(line));
                yield return new WaitUntil(() => sentenceDisplayCompleted);
            }
            yield return null;
        }

        yield return new WaitForSeconds(waitTimeAfterDialogue);
        EndDialogue();
    }

    private IEnumerator TypeSentence(string sentence)
    {
        sentenceDisplayCompleted = false;
        dialogueText.text = "";
        foreach (var letter in sentence)
        {
            dialogueText.text += letter;
            yield return null;
        }

        yield return new WaitForSeconds(waitTimeAfterDialogue);
        sentenceDisplayCompleted = true;
    }

    private void EndDialogue()
    {
        Debug.Log("End of conversation");
        dialoguePanel.SetActive(false);
    }
}
