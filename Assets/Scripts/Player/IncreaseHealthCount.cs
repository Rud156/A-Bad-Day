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
            StaticPlayerData.maxHealth += 1;
    }
}
