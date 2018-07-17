using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeEnemyParticleDamage : MonoBehaviour
{

    public float enemyAttackDamage = 0.5f;

    /// <summary>
    /// OnParticleCollision is called when a particle hits a collider.
    /// </summary>
    /// <param name="other">The GameObject hit by the particle.</param>
    void OnParticleCollision(GameObject other)
    {
        ParticleSystem particles = other.GetComponent<ParticleSystem>();
        print("Collision Occurred");

        if (!particles || !other.CompareTag("Enemy"))
            return;

        List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
        int collisionCount = particles.GetCollisionEvents(gameObject, collisionEvents);
        print("Total Collisions: " + collisionCount);

        foreach (var item in collisionEvents)
            Core.currentHealthLeft -= enemyAttackDamage;
    }
}
