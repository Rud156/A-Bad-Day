using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideGlowingOrbWithPlayer : MonoBehaviour
{
    public GameObject glowingOrbCollectionEffect;

    /// <summary>
    /// OnParticleCollision is called when a particle hits a collider.
    /// </summary>
    /// <param name="other">The GameObject hit by the particle.</param>
    void OnParticleCollision(GameObject other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (!target || !other.CompareTag("Player"))
            return;

        SecondScene.collectedGlowingOrbs += 1;
        Instantiate(glowingOrbCollectionEffect,
            other.transform.position,
            glowingOrbCollectionEffect.transform.rotation);
        Destroy(gameObject);
    }
}
