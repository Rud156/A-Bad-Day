using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectDashWallBreaker : MonoBehaviour
{

    [Header("Text Details")]
    public Animator textHolderAnimator;
    public Text displaySmallText;
    public Text displayBigText;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("DashWallBreakerCollectible"))
            return;

        other.GetComponent<Animator>().enabled = true;
        other.GetComponent<PausePlayerTillEffectComplete>().StopPlayerMovement();

        Core.wallBreakCollected = true;

        displayBigText.text = UITextConstants.secondSceneDashWallBreaker;
        displayBigText.color = new Color(0, 242, 255);
        displaySmallText.text = UITextConstants.secondSceneDashWallBreakerSubText;
        textHolderAnimator.Play(UITextConstants.screenTextAnimationName);
    }
}
