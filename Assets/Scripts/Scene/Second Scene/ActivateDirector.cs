using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivateDirector : MonoBehaviour
{

    public PlayableDirector director;

    // Use this for initialization
    void Start()
    {
        director.Play();
    }
}
