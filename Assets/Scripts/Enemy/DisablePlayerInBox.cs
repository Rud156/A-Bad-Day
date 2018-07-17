using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerInBox : MonoBehaviour
{

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        EnemyStats.playerInBox = false;
    }
}
