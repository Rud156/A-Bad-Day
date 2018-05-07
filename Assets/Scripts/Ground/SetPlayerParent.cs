using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerParent : MonoBehaviour
{

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        GameObject player = other.gameObject;
        Rigidbody target = player.GetComponent<Rigidbody>();
        if (!target || !player.CompareTag("Player"))
        {
            return;
        }

        player.transform.SetParent(gameObject.transform);
    }
}
