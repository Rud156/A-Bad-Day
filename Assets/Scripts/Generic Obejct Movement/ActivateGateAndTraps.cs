using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGateAndTraps : MonoBehaviour
{
    [System.Serializable]
    public struct AnimationNameAndAnimator
    {
        public Animator animator;
        public string animationNameActive;
        public string animationNameInactive;
    }


    public Animator gateAnimator;
    public string gateActiveAnimation;
    public string gateInactiveAnimation;
    public List<AnimationNameAndAnimator> trapAnimationsToActivate;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (!target || !other.CompareTag("Player"))
            return;

        gateAnimator.Play(gateActiveAnimation);
        CancelInvoke("DeactivateTraps");

        foreach (var item in trapAnimationsToActivate)
            item.animator.Play(item.animationNameActive);
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (!target || !other.CompareTag("Player"))
            return;

        gateAnimator.Play(gateInactiveAnimation);
        Invoke("DeactivateTraps", 8.9f);
    }

    void DeactivateTraps()
    {
        foreach (var item in trapAnimationsToActivate)
            item.animator.Play(item.animationNameInactive);
    }
}
