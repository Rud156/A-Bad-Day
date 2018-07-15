using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCollectibles : MonoBehaviour
{

    [Header("Collectible Stats")]
    public int collectibleScore = 20;
    public GameObject collectibleCollectEffect;

    [Header("Destory Parent Also")]
    public bool destroyParent = false;


    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (!target || !other.CompareTag("Player"))
            return;

        Instantiate(collectibleCollectEffect, other.transform.position,
            collectibleCollectEffect.transform.rotation);

        if (destroyParent)
            Destroy(gameObject.transform.parent.gameObject);
        else
            Destroy(gameObject);
    }

}
