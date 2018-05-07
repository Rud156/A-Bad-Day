using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParticlesColor : MonoBehaviour
{

    public GameObject player;
    public ParticleSystem dashParent;
    public ParticleSystem dashChild;

    // Use this for initialization
    void Start()
    {
        Material playerMaterial = player.GetComponent<Renderer>().material;
        Color color = playerMaterial.color;

        ParticleSystem.MainModule parentMain = dashParent.main;
        parentMain.startColor = color;

        ParticleSystem.MainModule childMain = dashChild.main;
        childMain.startColor = color;

    }
}
