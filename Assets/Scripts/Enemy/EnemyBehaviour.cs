using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JumpOnPlayer))]
public class EnemyBehaviour : MonoBehaviour
{

    [Header("Generic Effects")]
    public GameObject firstEffect;
    public GameObject secondEffect;
    public float secondEffectPlayTime;
    public GameObject destroyEnemyEffect;

    [Header("Effect Location")]
    public float heightBelowEnemyCenter = 2f;

    private int timeBetweenEffects;
    private JumpOnPlayer jumpOnPlayer;
    private Rigidbody target;

    // Use this for initialization
    void Start()
    {
        timeBetweenEffects = 5;
        jumpOnPlayer = gameObject.GetComponent<JumpOnPlayer>();
        target = gameObject.GetComponent<Rigidbody>();

        target.isKinematic = true;
        StartCoroutine(StartEnemy());
    }

    IEnumerator StartEnemy()
    {
        while (true)
        {
            if (!EnemyStats.playerInBox || EnemyStats.isJumping)
                yield return null;

            float currentHealth = EnemyStats.health;
            Vector3 position = gameObject.transform.position;

            if (currentHealth >= 50)
            {
                timeBetweenEffects = 5;
                int randomState = Random.Range(0, 100) % 2;
                yield return StartCoroutine(PlayRandomEffect(randomState, position));
            }
            else if (currentHealth >= 25 && currentHealth < 50)
            {
                timeBetweenEffects = 3;
                int randomState = Random.Range(0, 100) % 3;
                yield return StartCoroutine(PlayRandomEffect(randomState, position, 0.5f));
            }
            else if (currentHealth > 0)
            {
                timeBetweenEffects = 1;
                int randomState = Random.Range(0, 100) % 2;
                randomState += 1;
                yield return StartCoroutine(PlayRandomEffect(randomState, position, 0.7f));
            }
            else
                break;

            yield return null;
        }

        Instantiate(destroyEnemyEffect, gameObject.transform.position,
            destroyEnemyEffect.transform.rotation);
        Destroy(gameObject);
    }

    IEnumerator PlayRandomEffect(int randomState, Vector3 position, float arcSpeed = 0.3f)
    {
        if (randomState == 0)
            Instantiate(firstEffect,
                position + Vector3.down * heightBelowEnemyCenter, firstEffect.transform.rotation);
        else if (randomState == 1)
        {
            GameObject instantiatedSecondEffect = Instantiate(secondEffect,
                position + Vector3.down * heightBelowEnemyCenter, secondEffect.transform.rotation);
            ParticleSystem instantiatedParticles = instantiatedSecondEffect.GetComponent<ParticleSystem>();
            ParticleSystem.ShapeModule shape = instantiatedParticles.shape;
            shape.arcSpeed = arcSpeed;
            yield return new WaitForSeconds(secondEffectPlayTime);
            Destroy(instantiatedSecondEffect);
        }
        else
            jumpOnPlayer.TriggerJump();

        print("Attack Played. Waiting for time: " + timeBetweenEffects);
        yield return new WaitForSeconds(timeBetweenEffects);
        print("Launching Next Attack");
    }
}
