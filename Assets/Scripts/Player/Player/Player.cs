using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Health")]

    [Header("Zombie")]
    public float maxHealthEasy;
    public float maxHealthMedium;
    public float maxHealthHard;

    [Header("HealthRegeneration")]
    public float healthRegenerationEasy;
    public float healthRegenerationMedium;
    public float healthRegenerationHard;

    [Header("Armor")]
    public float maxArmorEasy;
    public float maxArmorMedium;
    public float maxArmorHard;

    [Header("Dry")]

    [Header("Waterbomb")]
    public float maxDryEasy;
    public float maxDryMedium;
    public float maxDryHard;

    [Header("DryRegeneration")]
    public float dryRegenerationEasy;
    public float dryRegenerationMedium;
    public float dryRegenerationHard;

    [Header("Tank")]
    public float maxTankEasy;
    public float maxTankMedium;
    public float maxTankHard;

    [Space (10, order = 0)]

    public GameObject ui;

    [System.NonSerialized]
    public HealthBar hb;
    [System.NonSerialized]
    public ArmorBar ab;
    [System.NonSerialized]
    public TankBar tb;
    [System.NonSerialized]
    public float currentHealth;
    [System.NonSerialized]
    public float currentArmor;
    [System.NonSerialized]
    public float currentDry;
    [System.NonSerialized]
    public float currentTank;
    [System.NonSerialized]
    public GameManager gm;
    [System.NonSerialized]
    public AudioManager am;
    [System.NonSerialized]
    public float maxHealth;
    [System.NonSerialized]
    public float healthRegeneration;
    [System.NonSerialized]
    public float maxArmor;
    [System.NonSerialized]
    public float maxDry;
    [System.NonSerialized]
    public float dryRegeneration;
    [System.NonSerialized]
    public float maxTank;

    int gameMode;

    private void Start()
    {
        gameMode = SaveSystem.LoadDataGameMode().gameModeSave;

        SetValues();

        switch (gameMode)
        {
            case 0:

                currentDry = 0;
                currentTank = 0;

                GetComponentsWaterBomb();

                hb.SetMaxCapacity(Mathf.RoundToInt(maxDry));
                tb.SetMaxTank(Mathf.RoundToInt(maxTank));

                UpdateUIWaterBomb();   

                break;
            case 1:

                currentHealth = maxHealth;
                currentArmor = maxArmor;

                GetComponents();

                hb.SetMaxHealth(Mathf.RoundToInt(maxHealth));
                ab.SetMaxArmor(Mathf.RoundToInt(maxArmor));

                UpdateUI();

                break;
        }
    }

    private void SetValues()
    {
        switch (SaveSystem.LoadDataDifficultySave().difficultySave)
        {
            case 0:

                //Zombie
                maxHealth = maxHealthEasy;
                healthRegeneration = healthRegenerationEasy;
                maxArmor = maxArmorEasy;
                //Water Bomb
                maxDry = maxDryEasy;
                dryRegeneration = dryRegenerationEasy;
                maxTank = maxTankEasy;

                break;
            case 1:

                //Zombie
                maxHealth = maxHealthMedium;
                healthRegeneration = healthRegenerationMedium;
                maxArmor = maxArmorMedium;
                //Water Bomb
                maxDry = maxDryMedium;
                dryRegeneration = dryRegenerationMedium;
                maxTank = maxTankMedium;

                break;
            case 2:

                //Zombie
                maxHealth = maxHealthHard;
                healthRegeneration = healthRegenerationHard;
                maxArmor = maxArmorHard;
                //Water Bomb
                maxDry = maxDryHard;
                dryRegeneration = dryRegenerationHard;
                maxTank = maxTankHard;

                break;
        }
    }

    public void TakeDamage(float value)
    {
        currentArmor -= value;

        if (currentArmor <= 0)
        {
            float remainingDamage = currentArmor * -1;
            currentArmor = 0;

            currentHealth -= remainingDamage;
            if(currentHealth <= 0)
            {
                currentHealth = 0;

                if (!gm.gameIsCurrentlyEnded)
                {
                    gm.SetText("No more Health");
                    gm.EndGame();
                }
            }
        }

        UpdateUI();
    }

    public void Heal(float value)
    {
        currentHealth += value;
        if(currentHealth > maxHealth)
        {
            float remainingHealt = currentHealth - maxHealth;
            currentHealth = maxHealth;

            currentArmor += remainingHealt;
            if(currentArmor > maxArmor)
            {
                currentArmor = maxArmor;
            }
        }

        UpdateUI();
    }

    public void FillWater(float amount)
    {
        currentDry += amount;
        if (currentDry > maxDry)
        {
            float remainingWater = currentDry - maxDry;
            currentDry = maxDry;

            currentTank += remainingWater;
            if (currentTank >= maxTank)
            {
                currentTank = maxTank;

                if (!gm.gameIsCurrentlyEnded)
                {
                    gm.SetText("Too much Water! \n you DROWNED");
                    gm.EndGame();
                }
            }
        }

        UpdateUIWaterBomb();
    }

    public void LooseWater(float amount)
    {
        currentTank -= amount;

        if (currentTank <= 0)
        {
            float remainingDry = currentTank * -1;
            currentTank = 0;

            currentDry -= remainingDry;
            if (currentDry <= 0)
            {
                currentDry = 0;
            }
        }

        UpdateUIWaterBomb();
    }

    private void UpdateUI()
    {
        hb.SetHealth(Mathf.RoundToInt(currentHealth));
        hb.SetText(Mathf.RoundToInt(currentHealth), Mathf.RoundToInt(maxHealth));

        ab.SetArmor(Mathf.RoundToInt(currentArmor));
        ab.SetText(Mathf.RoundToInt(currentArmor), Mathf.RoundToInt(maxArmor));
    }

    void GetComponents()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        hb = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        ab = GameObject.FindGameObjectWithTag("ArmorBar").GetComponent<ArmorBar>();
        am = gm.audioManager;
    }

    private void UpdateUIWaterBomb()
    {
        hb.SetCapacity(Mathf.RoundToInt(currentDry));
        hb.SetText(Mathf.RoundToInt(currentDry), Mathf.RoundToInt(maxDry));

        tb.SetTank(Mathf.RoundToInt(currentTank));
        tb.SetText(Mathf.RoundToInt(currentTank), Mathf.RoundToInt(maxTank));
    }

    void GetComponentsWaterBomb()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        hb = GameObject.FindGameObjectWithTag("DryBar").GetComponent<HealthBar>();
        tb = GameObject.FindGameObjectWithTag("TankBar").GetComponent<TankBar>();
        am = gm.audioManager;
    }
}
