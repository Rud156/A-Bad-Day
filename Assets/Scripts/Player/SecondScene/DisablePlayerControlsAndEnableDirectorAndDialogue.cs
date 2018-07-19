using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DisablePlayerControlsAndEnableDirectorAndDialogue : MonoBehaviour
{

    [Header("Director Object")]
    public GameObject player;
    public PlayableDirector director;
    public bool deactivateObjectAfterComplete = true;

    [Header("Dialogue Component")]
    public GameObject dialogueStarter;

    private bool playStarted;
    private Rigidbody target;
    private bool onTriggerCalled;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        onTriggerCalled = false;
        playStarted = false;
        target = player.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (target.transform.parent == gameObject.transform.parent && !playStarted && onTriggerCalled)
        {
            target.isKinematic = true;
            director.Play();
            playStarted = true;
            dialogueStarter.SetActive(true);
        }

        if (director.state != PlayState.Playing && playStarted)
        {
            Core.stopPlayerMovement = false;
            target.isKinematic = false;

            if (deactivateObjectAfterComplete)
                gameObject.SetActive(false);
        }
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
        target.velocity = Vector3.zero;
        onTriggerCalled = true;
    }
}
