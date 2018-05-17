using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
	public static int maxJumpCount = 2;
	public static int currentJumpCount = 0;

	public static int maxHealth = 3;
	public static int currentHealthLeft = 3;
	public static int healthPortalsCollected = 0;
	public static int maxHealthPortalsForIncrease =  2;

	public static int maxDashes = 3;
	public static float currentDashesLeft = 3;
	public static int dashPortalsCollected = 0;
	public static int maxDashPortalsForIncrease = 2;
	public static float dashIncreaseRate = 0.01f;
	public static float dashUseRate = 1f;

	public static bool stopPlayerMovement = false;
	public static Vector3 currentCheckPoint = new Vector3(3f, 4f, -11f);
}
