using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DisablePlayerControlsAndEnableDirector : MonoBehaviour
{

    public PlayableDirector director;

    private bool playStarted;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        playStarted = false;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (director.state == PlayState.Playing)
            playStarted = true;

        if (director.state != PlayState.Playing && playStarted)
            Core.stopPlayerMovement = false;
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (!target || !other.CompareTag("Player"))
            return;

        Core.stopPlayerMovement = true;
        director.Play();
    }
}
