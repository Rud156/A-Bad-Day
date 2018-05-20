using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseHealthCount : MonoBehaviour
{
    public Animator textHolderAnimator;
    public Text displaySmallText;
    public Text displayBigText;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("HealthCollectible"))
            return;

        gameObject.transform.SetParent(other.transform.parent);
        gameObject.transform.position = other.transform.position;
        other.GetComponent<Animator>().enabled = true;
        other.GetComponent<PausePlayerTillEffectComplete>().StopPlayerMovement();

        Core.healthPortalsCollected += 1;
        CheckCollectedCount();
    }

    private void CheckCollectedCount()
    {
        int healthPortalsCollected = Core.healthPortalsCollected;

        if (healthPortalsCollected == Core.maxHealthPortalsForIncrease)
        {
            Core.healthPortalsCollected = 0;
            Core.maxHealth += 1;
            Core.currentHealthLeft += 1;

            displayBigText.text = UITextConstants.healthIncreased;
            displayBigText.color = Color.white;
            displaySmallText.text = UITextConstants.healthIncreasedSubText;
            displaySmallText.color = Color.green;
        }
        else
        {
            displayBigText.text = UITextConstants.healthPortalCollected;
            displayBigText.color = Color.white;
            displaySmallText.text = UITextConstants.healthPortalCollectedSubText;
            displaySmallText.color = Color.green;
        }
        textHolderAnimator.Play(UITextConstants.screenTextAnimationName);
    }
}
