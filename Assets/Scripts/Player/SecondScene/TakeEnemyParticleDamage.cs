using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeEnemyParticleDamage : MonoBehaviour
{

    public float minEnemyAttackDamage = 0.5f;
    public float maxEnemyAttackDamage = 1f;

    /// <summary>
    /// OnParticleCollision is called when a particle hits a collider.
    /// </summary>
    /// <param name="other">The GameObject hit by the particle.</param>
    void OnParticleCollision(GameObject other)
    {
        ParticleSystem particles = other.GetComponent<ParticleSystem>();

        if (!particles || !other.CompareTag("Enemy"))
            return;

        List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
        particles.GetCollisionEvents(gameObject, collisionEvents);

        foreach (var item in collisionEvents)
        {
            float randomDamage = Random.Range(minEnemyAttackDamage, maxEnemyAttackDamage);
            Core.currentHealthLeft -= randomDamage;
        }
    }
}
