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
    public float colorReductionRate = 0.001f;

    void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag("DashCollectible"))
            return;

        gameObject.transform.SetParent(other.transform.parent);
        gameObject.transform.position = other.transform.position;
        other.GetComponent<Animator>().enabled = true;
        other.GetComponent<PausePlayerTillEffectComplete>().StopPlayerMovement();

        PlayerData.dashPortalsCollected += 1;
        CheckCollectedCount();
    }

    private void CheckCollectedCount()
    {
        int dashPortalsCollected = PlayerData.dashPortalsCollected;
        if (dashPortalsCollected == PlayerData.maxDashPortalsForIncrease)
        {
            PlayerData.maxDashes += 1;
            PlayerData.dashPortalsCollected = 0;
            displayBigText.text = Constants.dashIncreased;
            displayBigText.color = Color.white;
            displaySmallText.text = Constants.dashIncreasedSubText;
            displaySmallText.color = Color.blue;
            textHolderAnimator.Play(Constants.secondScreenTextAnimationName);
        }
        else
        {
            displayBigText.text = Constants.dashPortalCollected;
            displayBigText.color = Color.white;
            displaySmallText.text = Constants.dashPortalCollectedSubText;
            displaySmallText.color = Color.blue;
            textHolderAnimator.Play(Constants.secondScreenTextAnimationName);
        }
    }
}
