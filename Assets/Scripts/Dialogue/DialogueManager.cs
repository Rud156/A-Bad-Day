using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Required Components")]
    public Text nameText;
    public Text dialogueText;
    public RawImage objectImage;

    [Header("Dialogue Data")]
    public Dialogue[] dialogues;
    public float waitTimeAfterDialogue = 2;


    private bool sentenceDisplayCompleted;

    void Start()
    {
        sentenceDisplayCompleted = true;
        StartCoroutine(StartDialogue());
    }

    private IEnumerator StartDialogue()
    {
        foreach (Dialogue dialogue in dialogues)
        {
            nameText.text = dialogue.name;
            nameText.color = dialogue.nameColor;
            objectImage.texture = dialogue.spriteImage;
            objectImage.color = dialogue.nameColor;

            foreach (string line in dialogue.sentences)
            {
                StartCoroutine(TypeSentence(line));
                yield return new WaitUntil(() => sentenceDisplayCompleted);
            }
            yield return null;
        }

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
    }
}
