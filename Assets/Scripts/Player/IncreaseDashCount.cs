using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDashCount : MonoBehaviour
{

    public GameObject dashPortalParticleEffect;

    void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag("DashCollectible"))
            return;

        GameObject effect = Instantiate(dashPortalParticleEffect,
            gameObject.transform.position,
            dashPortalParticleEffect.transform.rotation);
        effect.GetComponent<PausePlayerTillEffectComplete>().SetPlayerRigidBody(
            gameObject.GetComponent<Rigidbody>()
        );

        effect.transform.SetParent(other.transform.parent);
        gameObject.transform.SetParent(other.transform.parent);

        Destroy(other.gameObject);
        StaticPlayerData.dashPortalsCollected += 1;

        CheckCollectedCount();
    }

    private void CheckCollectedCount()
    {
        int dashPortalsCollected = StaticPlayerData.dashPortalsCollected;
        if (dashPortalsCollected == StaticPlayerData.maxDashPortalsForIncrease)
            StaticPlayerData.maxDashes += 1;
    }
}
