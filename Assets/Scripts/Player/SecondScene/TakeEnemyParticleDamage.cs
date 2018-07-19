using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class TakeEnemyParticleDamage : MonoBehaviour
{
    [Header("Text Details")]
    public Animator textHolderAnimator;
    public Text displaySmallText;
    public Text displayBigText;

    [Header("Enemy Damage Stats")]
    public float minEnemyAttackDamage = 0.5f;
    public float maxEnemyAttackDamage = 1f;

    [Header("Fader")]
    public GameObject fadeOut;

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

        if (Core.currentHealthLeft <= 0)
        {
            Core.stopPlayerMovement = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            displayBigText.text = "0 Health";
            displayBigText.color = Color.red;
            displaySmallText.text = "You were defeated";
            textHolderAnimator.Play(UITextConstants.screenTextAnimationName);
            fadeOut.SetActive(true);
        }
    }
}
