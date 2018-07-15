using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{

    [Header("Score")]
    public Text scoreText;

    private int currentScore;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        currentScore = SecondScene.collectibleScore;
        scoreText.text = "Score: " + currentScore;
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        int updatedScore = SecondScene.collectibleScore;
        if (currentScore < updatedScore)
        {
            scoreText.text = "Score: " + currentScore;
            currentScore += 1;
        }
    }
}
