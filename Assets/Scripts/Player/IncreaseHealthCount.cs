using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealthCount : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("HealthCollectible"))
            return;
    }
}
