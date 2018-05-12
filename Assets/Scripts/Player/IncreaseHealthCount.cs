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
        other.GetComponent<PausePlayerTillEffectComplete>().SetPlayerRigidBody(
            gameObject.GetComponent<Rigidbody>()
        );

        StaticPlayerData.healthPortalsCollected += 1;
        CheckCollectedCount();
    }

    private void CheckCollectedCount()
    {
        int healthPortalsCollected = StaticPlayerData.healthPortalsCollected;

        if (healthPortalsCollected == StaticPlayerData.maxHealthPortalsForIncrease)
        {
            StaticPlayerData.healthPortalsCollected = 0;
            StaticPlayerData.maxHealth += 1;

            displayBigText.text = "+1 Health";
            displayBigText.color = Color.white;
            displaySmallText.text = "Health increased";
            displaySmallText.color = Color.green;
            StartCoroutine(ReduceOpacityTo0());
        }
        else
        {
            displayBigText.text = "+1 Health Portal";
            displaySmallText.text = "Collect 1 more to increase health bar";
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
