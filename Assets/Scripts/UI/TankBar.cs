using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TankBar : MonoBehaviour
{

    public Slider slider;
    public Image fill;
    public TMP_Text tankbarText;
    public Gradient gradient;

    public void SetMaxTank(int value)
    {
        slider.maxValue = value;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetTank(int value)
    {
        slider.value = value;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetText(int currentTank, int maxTank)
    {
        string currentTankText = currentTank + " / " + maxTank;
        tankbarText.text = currentTankText;
    }
}
