using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealthCount : MonoBehaviour
{

    public GameObject healthPortalParticleEffect;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("HealthCollectible"))
            return;

        Instantiate(healthPortalParticleEffect,
            gameObject.transform.position,
            healthPortalParticleEffect.transform.rotation);
        Destroy(other.gameObject);

        StaticPlayerData.healthPortalsCollected += 1;

        CheckCollectedCount();
    }

    private void CheckCollectedCount()
    {
        int healthPortalsCollected = StaticPlayerData.healthPortalsCollected;
        if (healthPortalsCollected == StaticPlayerData.maxHealthPortalsForIncrease)
        {
            StaticPlayerData.maxLives += 1;
        }
    }
}
