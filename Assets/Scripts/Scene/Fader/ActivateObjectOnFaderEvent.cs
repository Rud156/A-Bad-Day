using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectOnFaderEvent : MonoBehaviour
{

    public GameObject objectToSetActive;

    void ActivateObject()
    {
        objectToSetActive.SetActive(true);
    }

}
