using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOnContact : MonoBehaviour
{
    [Range(0, 1)]
    public float damageAmount = 0.5f;

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        Rigidbody target = other.gameObject.GetComponent<Rigidbody>();
        if (!target || !other.gameObject.CompareTag("Player"))
            return;

        Core.currentHealthLeft -= damageAmount;
    }
}
