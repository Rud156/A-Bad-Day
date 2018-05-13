using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlayerTillEffectComplete : MonoBehaviour
{

    public Rigidbody player;

    public void StopPlayerMovement()
    {
        PlayerData.stopPlayerMovement = true;
        this.player.useGravity = false;
        this.player.velocity = Vector3.zero;
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        PlayerData.stopPlayerMovement = false;
        if (this.player)
            this.player.useGravity = true;
    }
}
