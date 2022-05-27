using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour {

    public Slider slider;
    public Image fill;
    public TMP_Text healthBarText;
    public Gradient gradient;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxCapacity(int capacity)
    {
        slider.maxValue = capacity;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetCapacity(int capacity)
    {
        slider.value = capacity;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetText(int currentHealth, int maxHealth)
    {
        string currentHealthText = currentHealth + " / " + maxHealth;
        healthBarText.text = currentHealthText;
    }
}
