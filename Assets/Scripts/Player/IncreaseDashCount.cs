using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseDashCount : MonoBehaviour
{
    public Animator textHolderAnimator;
    public Text displaySmallText;
    public Text displayBigText;

    void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag("DashCollectible"))
            return;

        gameObject.transform.SetParent(other.transform.parent);
        gameObject.transform.position = other.transform.position;
        other.GetComponent<Animator>().enabled = true;
        other.GetComponent<PausePlayerTillEffectComplete>().StopPlayerMovement();

        Core.dashPortalsCollected += 1;
        CheckCollectedCount();
    }

    private void CheckCollectedCount()
    {
        int dashPortalsCollected = Core.dashPortalsCollected;
        if (dashPortalsCollected == Core.maxDashPortalsForIncrease)
        {
            Core.maxDashes += 1;
            Core.dashPortalsCollected = 0;
            displayBigText.text = UITextConstants.dashIncreased;
            displayBigText.color = Color.white;
            displaySmallText.text = UITextConstants.dashIncreasedSubText;
            displaySmallText.color = Color.blue;
        }
        else
        {
            displayBigText.text = UITextConstants.dashPortalCollected;
            displayBigText.color = Color.white;
            displaySmallText.text = UITextConstants.dashPortalCollectedSubText;
            displaySmallText.color = Color.blue;
        }
        textHolderAnimator.Play(UITextConstants.secondScreenTextAnimationName);
    }
}
