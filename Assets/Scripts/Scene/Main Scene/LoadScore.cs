using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour
{
    [Header("Score")]
    public Text ScoreText;

    // Use this for initialization
    void Start()
    {
        int score;
        if (PlayerPrefs.HasKey(UITextConstants.playerPrefsString))
            score = PlayerPrefs.GetInt(UITextConstants.playerPrefsString);
        else
            score = 0;
        ScoreText.text = "Highest Score: " + score;
    }
}
