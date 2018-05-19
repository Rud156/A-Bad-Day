using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePedestalSwitch : MonoBehaviour
{

    [Header("Animator to Affect")]
    public Animator animator;

    private int numberInsideTrigger;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        numberInsideTrigger = 0;
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        numberInsideTrigger += 1;
        animator.SetBool("SwitchActive", true);
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        numberInsideTrigger -= 1;
        if (numberInsideTrigger > 0)
            return;

        animator.SetBool("SwitchActive", false);
    }
}
