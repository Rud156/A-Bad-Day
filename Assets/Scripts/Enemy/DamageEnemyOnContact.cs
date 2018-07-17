using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEnemyOnContact : MonoBehaviour
{
    [Header("Damage Stats")]
    public float damageConstant = 0.7f;

    [Header("Health")]
    public Slider healthSlider;
    public Image healthFiller;
    public Color minHealthColor = Color.red;
    public Color halfHealthColor = Color.yellow;
    public Color maxHealthColor = Color.green;

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        float currentHealthLeft = EnemyStats.health;
        float maxHealth = EnemyStats.maxEnemyHealth;
        float healthRatio = (float)currentHealthLeft / maxHealth;

        if (healthRatio <= 0.5)
            healthFiller.color = Color.Lerp(minHealthColor, halfHealthColor, healthRatio * 2);
        else
            healthFiller.color = Color.Lerp(halfHealthColor, maxHealthColor, (healthRatio - 0.5f) * 2);
        healthSlider.value = healthRatio;
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        Rigidbody target = other.gameObject.GetComponent<Rigidbody>();
        if (!target && !other.gameObject.CompareTag("Player") &&
            !other.gameObject.CompareTag(EnemyStats.orb))
            return;

        string otherTag = other.gameObject.tag;
        if (otherTag == "Player")
        {
            float collisionVelocity = other.relativeVelocity.magnitude;
            float damageAmount = collisionVelocity * damageConstant;
            EnemyStats.health -= damageAmount;
        }
        else
        {
            float randomDamageAmount = Random.Range(EnemyStats.minOrbDamage,
                EnemyStats.maxOrbDamage);
            EnemyStats.health -= randomDamageAmount;
            Destroy(other.gameObject);
        }
    }

}
