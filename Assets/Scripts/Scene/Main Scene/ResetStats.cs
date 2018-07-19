using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStats : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        print("Resetting Stats");

        // Enemy Stats
        EnemyStats.state = -1;
        EnemyStats.playerInBox = false;
        EnemyStats.isJumping = false;
        EnemyStats.health = 100;

        // Player Stats
        Core.currentJumpCount = 0;
        Core.currentHealthLeft = 100;
        Core.wallBreakCollected = false;
        Core.stopPlayerMovement = false;
        Core.currentCheckPoint = new Vector3(-71.95f, 4f, 0.04f);
        Core.currentDashesLeft = 3;

        // Second Scene Specific
        SecondScene.currentFallCount = 0;
        SecondScene.collectedGlowingOrbs = 0;
        SecondScene.collectibleScore = 0;

        print("Stats Reset");
    }
}
