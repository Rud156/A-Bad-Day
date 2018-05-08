using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParticleChildColor : MonoBehaviour
{

    public Color color;

    private int childCount;
    private int currentCount;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        childCount = gameObject.transform.childCount;
        currentCount = 0;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (currentCount >= childCount)
            return;

        ParticleSystem particle = gameObject.transform.GetChild(currentCount).GetComponent<ParticleSystem>();
        ParticleSystem.MainModule mainModule = particle.main;
        mainModule.startColor = color;

        currentCount += 1;
    }


}
