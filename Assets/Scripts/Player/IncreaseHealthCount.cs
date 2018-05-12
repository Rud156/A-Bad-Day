using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseHealthCount : MonoBehaviour
{

    public GameObject healthPortalParticleEffect;
    public Text displaySmallText;
    public Text displayBigText;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("HealthCollectible"))
            return;

        GameObject effect = Instantiate(healthPortalParticleEffect,
            gameObject.transform.position,
            healthPortalParticleEffect.transform.rotation);
        effect.GetComponent<PausePlayerTillEffectComplete>().SetPlayerRigidBody(
            gameObject.GetComponent<Rigidbody>()
        );

        effect.transform.SetParent(other.transform.parent);
        gameObject.transform.SetParent(other.transform.parent);

        Destroy(other.gameObject);
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
            displaySmallText.text = "Health increased";
        }
        else
        {
            displayBigText.text = "+1 Health Portal";
            displaySmallText.text = "Collect 1 more to increase health bar";
        }
    }
}
