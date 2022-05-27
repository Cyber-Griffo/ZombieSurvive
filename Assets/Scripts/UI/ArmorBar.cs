using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArmorBar : MonoBehaviour
{

    public Slider slider;
    public Image fill;
    public TMP_Text armorbarText;
    public Gradient gradient;

    public void SetMaxArmor(int value)
    {
        slider.maxValue = value;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetArmor(int value)
    {
        slider.value = value;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetText(int currentArmor, int maxArmor)
    {
        string currentHealthText = currentArmor + " / " + maxArmor;
        armorbarText.text = currentHealthText;
    }
}
