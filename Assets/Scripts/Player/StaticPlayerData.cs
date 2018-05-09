using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPlayerData : MonoBehaviour
{
	public static int maxJumpCount = 2;
	public static int currentJumpCount = 0;

	public static int maxLives = 3;
	public static int currentLives = 3;
	public static int healthPortalsCollected = 0;
	public static int maxHealthPortalsForIncrease =  2;

	public static int maxDashes = 3;
	public static int currentDashes = 0;
	public static int dashPortalsCollected = 0;
	public static int maxDashPortalsForIncrease = 2;

	public static bool stopPlayerMovement = false;
}
