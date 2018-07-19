using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Player")]
    public GameObject player;

    [Header("Text Details")]
    public Animator textHolderAnimator;
    public Text displaySmallText;
    public Text displayBigText;

    private int timeBetweenEffects;
    private JumpOnPlayer jumpOnPlayer;
    private Rigidbody target;
    private bool continueExecution;

    // Use this for initialization
    void Start()
    {
        timeBetweenEffects = 3;
        jumpOnPlayer = gameObject.GetComponent<JumpOnPlayer>();
        target = gameObject.GetComponent<Rigidbody>();

        target.isKinematic = true;
        StartCoroutine(StartEnemy());
    }

    IEnumerator StartEnemy()
    {
        while (true)
        {
            continueExecution = true;
            if (!EnemyStats.playerInBox || EnemyStats.isJumping)
                continueExecution = false;


            if (continueExecution)
            {
                float currentHealth = EnemyStats.health;
                Vector3 position = gameObject.transform.position;

                if (currentHealth >= 50)
                {
                    timeBetweenEffects = 3;
                    int randomState = Random.Range(0, 100) % 2;
                    yield return StartCoroutine(PlayRandomEffect(randomState, position));
                }
                else if (currentHealth >= 25 && currentHealth < 50)
                {
                    timeBetweenEffects = 2;
                    int randomState = Random.Range(0, 100) % 3;
                    yield return StartCoroutine(PlayRandomEffect(randomState, position, 0.7f));
                }
                else if (currentHealth > 0)
                {
                    timeBetweenEffects = 1;
                    int randomState = Random.Range(0, 100) % 2;
                    randomState += 1;
                    yield return StartCoroutine(PlayRandomEffect(randomState, position, 0.9f));
                }
                else
                    break;
            }
            yield return null;
        }

        if (EnemyStats.health <= 0)
        {
            Instantiate(destroyEnemyEffect, gameObject.transform.position,
                destroyEnemyEffect.transform.rotation);

            displayBigText.text = "Boom!";
            displayBigText.color = Color.green;
            displaySmallText.text = "Enemy defeated";
            textHolderAnimator.Play(UITextConstants.screenTextAnimationName);

            Destroy(gameObject);
        }
    }

    IEnumerator PlayRandomEffect(int randomState, Vector3 position, float arcSpeed = 0.5f)
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

        yield return new WaitForSeconds(timeBetweenEffects);
    }
}
