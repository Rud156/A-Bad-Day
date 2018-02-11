using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticleEffect : MonoBehaviour
{

    [Header("Required Attributes")]
    public GameObject dropParticles;
    public float heightDistance = 0.25f;


    // Use this for initialization
    void Start()
    {
        GameObject particles = Instantiate(
                dropParticles,
                gameObject.transform.position - Vector3.up * heightDistance,
                dropParticles.transform.rotation
            ) as GameObject;
        particles.transform.SetParent(gameObject.transform.parent);
        particles.transform.localScale = Vector3.one * 2;
    }

}
