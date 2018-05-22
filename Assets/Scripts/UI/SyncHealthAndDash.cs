using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncHealthAndDash : MonoBehaviour
{

    [Header("Health")]
    public Slider healthSlider;
    public Image healthFiller;
    public Color minHealthColor = Color.red;
    public Color halfHealthColor = Color.yellow;
    public Color maxHealthColor = Color.green;

    [Header("Dash")]
    public Slider dashSlider;
    public Image dashFiller;
    public Color minDashColor;
    public Color halfDashColor;
    public Color maxDashColor;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        StartCoroutine(IncreaseDashCount());
    }

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        int maxHealth = Core.maxHealth;
        float currentHealthLeft = Core.currentHealthLeft;
        float healthRatio = (float)currentHealthLeft / maxHealth;
        if (healthRatio <= 0.5)
            healthFiller.color = Color.Lerp(minHealthColor, halfHealthColor, healthRatio * 2);
        else
            healthFiller.color = Color.Lerp(halfHealthColor, maxHealthColor, (healthRatio - 0.5f) * 2);
        healthSlider.value = healthRatio;

        int maxDashes = Core.maxDashes;
        float currentDashesLeft = Core.currentDashesLeft;
        float dashesRatio = (float)currentDashesLeft / maxDashes;
        if (dashesRatio <= 0.5)
            dashFiller.color = Color.Lerp(minDashColor, halfDashColor, dashesRatio * 2);
        else
            dashFiller.color = Color.Lerp(halfDashColor, maxDashColor, (dashesRatio - 0.5f) * 2);
        dashSlider.value = dashesRatio;
    }



    IEnumerator IncreaseDashCount()
    {
        while (true)
        {
            float currentDashes = Core.currentDashesLeft;
            float dashIncreaseRate = Core.dashIncreaseRate;
            int maxDashes = Core.maxDashes;
            if (currentDashes + dashIncreaseRate <= maxDashes)
                Core.currentDashesLeft += dashIncreaseRate;

            yield return null;
        }
    }
}
