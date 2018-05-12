using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseDashCount : MonoBehaviour
{
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

        StaticPlayerData.dashPortalsCollected += 1;
        CheckCollectedCount();
    }

    private void CheckCollectedCount()
    {
        int dashPortalsCollected = StaticPlayerData.dashPortalsCollected;
        if (dashPortalsCollected == StaticPlayerData.maxDashPortalsForIncrease)
        {
            StaticPlayerData.maxDashes += 1;
            StaticPlayerData.dashPortalsCollected = 0;
            displayBigText.text = "+1 Dash";
            displaySmallText.text = "Dash ability increased";
            StartCoroutine(ReduceOpacityTo0());
        }
        else
        {
            displayBigText.text = "+1 Dash Portal";
            displaySmallText.text = "Collect 1 more to increase dash ability";
            StartCoroutine(ReduceOpacityTo0());
        }
    }

    IEnumerator ReduceOpacityTo0()
    {
        float currentAlpha = 1;
        while (currentAlpha > 0)
        {
            currentAlpha -= colorReductionRate;
            displayBigText.color = new Color(1, 1, 1, currentAlpha);
            displaySmallText.color = new Color(0, 0, 1, currentAlpha);
            yield return null;
        }
    }
}
