using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDashCount : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag("DashCollectible"))
            return;
    }
}
