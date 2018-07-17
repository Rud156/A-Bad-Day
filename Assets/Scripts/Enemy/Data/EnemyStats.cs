using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public static int state = -1; // -1 =  Do Nothing
    public static bool isJumping = false;
    public static bool playerInBox = false;

    public static float maxEnemyHealth = 100;
    public static float health = 100;

    public static string orb = "Orb";
    public static float minOrbDamage = 3f;
    public static float maxOrbDamage = 10f;
}
