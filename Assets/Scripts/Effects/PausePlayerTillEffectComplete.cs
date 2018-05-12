using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlayerTillEffectComplete : MonoBehaviour
{

    private Rigidbody player;

    public void SetPlayerRigidBody(Rigidbody player)
    {
        this.player = player;
        StaticPlayerData.stopPlayerMovement = true;
        this.player.useGravity = false;
        this.player.velocity = Vector3.zero;
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        StaticPlayerData.stopPlayerMovement = false;
        if (this.player)
            this.player.useGravity = true;
    }
}
