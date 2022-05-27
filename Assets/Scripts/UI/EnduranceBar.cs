using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnduranceBar : MonoBehaviour
{

    public Slider slider;
    public Image fill;
    public Gradient gradient;

    public void SetMaxEndurance(float value)
    {
        slider.maxValue = value;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetEndurance(float value)
    {
        slider.value = value;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
