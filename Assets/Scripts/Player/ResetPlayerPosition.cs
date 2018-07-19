using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPlayerPosition : MonoBehaviour
{
    [Header("Text Details")]
    public Animator textHolderAnimator;
    public Text displaySmallText;
    public Text displayBigText;

    [Header("Fader")]
    public GameObject fadeOut;

    [Header("Optional Parameters")]
    public Vector3 resetPosition = Vector3.zero;
    public bool useCheckPoint = false;


    private Rigidbody target;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("ResetGround"))
            return;

        gameObject.transform.SetParent(null);
        target.velocity = Vector3.zero;

        SecondScene.currentFallCount += 1;

        if (SecondScene.maxFallCount < SecondScene.currentFallCount)
        {
            displayBigText.text = "You're Dead...";
            displaySmallText.text = "Better Luck Next Time...";
            displayBigText.color = Color.red;
            textHolderAnimator.Play(UITextConstants.screenTextAnimationName);
            Core.stopPlayerMovement = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            target.isKinematic = true;
            fadeOut.SetActive(true);

            return;
        }
        displayBigText.text = "You Fell";
        displayBigText.color = Color.red;
        int timesLeft = SecondScene.maxFallCount - SecondScene.currentFallCount;
        displaySmallText.text = "Lives left: " + timesLeft;
        textHolderAnimator.Play(UITextConstants.screenTextAnimationName);

        if (!useCheckPoint)
            target.transform.position = resetPosition;
        else
            target.transform.position = Core.currentCheckPoint;
    }
}
