using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseHealthCount : MonoBehaviour
{
    public Text displaySmallText;
    public Text displayBigText;
    public float colorReductionRate = 0.001f;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("HealthCollectible"))
            return;

        gameObject.transform.SetParent(other.transform.parent);
        gameObject.transform.position = other.transform.position;
        other.GetComponent<Animator>().enabled = true;
        other.GetComponent<PausePlayerTillEffectComplete>().StopPlayerMovement();

        PlayerData.healthPortalsCollected += 1;
        CheckCollectedCount();
    }

    private void CheckCollectedCount()
    {
        int healthPortalsCollected = PlayerData.healthPortalsCollected;

        if (healthPortalsCollected == PlayerData.maxHealthPortalsForIncrease)
        {
            PlayerData.healthPortalsCollected = 0;
            PlayerData.maxHealth += 1;
            PlayerData.currentHealthLeft += 1;

            displayBigText.text = Constants.healthIncreased;
            displayBigText.color = Color.white;
            displaySmallText.text = Constants.healthIncreasedSubText;
            displaySmallText.color = Color.green;
            StartCoroutine(ReduceOpacityTo0());
        }
        else
        {
            displayBigText.text = Constants.healthPortalCollected;
            displaySmallText.text = Constants.healthPortalCollectedSubText;
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
            displaySmallText.color = new Color(0, 1, 0, currentAlpha);
            yield return null;
        }
    }
}
