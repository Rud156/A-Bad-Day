using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayOrbsCollected : MonoBehaviour
{

    [Header("Orb Data")]
    public int maxOrbsToCollect = 5;

    [Header("Orb")]
    public Text orbText;
    public Slider orbSlider;
    public Image orbFiller;
    public Color minOrbColor;
    public Color halfOrbColor;
    public Color maxOrbColor;

    /// <summary>
	/// LateUpdate is called every frame, if the Behaviour is enabled.
	/// It is called after all Update functions have been called.
	/// </summary>
	void LateUpdate()
    {
        int collectedOrbs = SecondScene.collectedGlowingOrbs;
        orbText.text = "Orbs " + " (" + collectedOrbs + "/" + maxOrbsToCollect + ")";
        float orbRatio = (float)collectedOrbs / maxOrbsToCollect;
        if (orbRatio <= 0.5)
            orbFiller.color = Color.Lerp(minOrbColor, halfOrbColor, orbRatio * 2);
        else
            orbFiller.color = Color.Lerp(halfOrbColor, maxOrbColor, (orbRatio - 0.5f) * 2);
        orbSlider.value = orbRatio;
    }
}
