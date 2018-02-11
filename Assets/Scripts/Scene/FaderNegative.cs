using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FaderNegative : MonoBehaviour
{

    [Header("Canvas Elements")]
    public Image faderImage;

    [Header("Required Stats")]
    public float reductionRate = 5;
    public float startAlpha = 0;
    public float endAlpha = 255;

    private float currentReductionRate;

    void Start()
    {
        currentReductionRate = 1;
    }


    void Update()
    {
        if (currentReductionRate >= endAlpha)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gameObject.GetComponent<FaderNegative>().enabled = false;
        }

        faderImage.color = new Color(1, 1, 1, (startAlpha + currentReductionRate) / 255);
        currentReductionRate += reductionRate * Time.deltaTime;
    }
}
