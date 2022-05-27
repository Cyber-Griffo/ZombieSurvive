using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUpgrade : MonoBehaviour {

    [Header("Zombie")]

    [Header("Easy")]

    [Header("Costs")]

    public int healthCostEasy;
    public int healthRegenerationCostEasy;
    public int armorCostEasy;
    public int movementSpeedCostEasy;
    public int enduranceCostEasy;
    public int enduranceRegenerationCostEasy;

    [Header("Medium")]

    public int healthCostMedium;
    public int healthRegenerationCostMedium;
    public int armorCostMedium;
    public int movementSpeedCostMedium;
    public int enduranceCostMedium;
    public int enduranceRegenerationCostMedium;

    [Header("Hard")]
    public int healthCostHard;
    public int healthRegenerationCostHard;
    public int armorCostHard;
    public int movementSpeedCostHard;
    public int enduranceCostHard;
    public int enduranceRegenerationCostHard;

    [Header("Easy")]

    [Header("MaxCounts")]
    public int healthMaxUpgradeCountEasy;
    public int healthRegenerationMaxUpgradeCountEasy;
    public int armorMaxUpgradeCountEasy;
    public int movementSpeedMaxUpgradeCountEasy;
    public int enduranceMaxUpgradeCountEasy;
    public int enduranceRegenerationMaxUpgradeCountEasy;

    [Header("Medium")]

    public int healthMaxUpgradeCountMedium;
    public int healthRegenerationMaxUpgradeCountMedium;
    public int armorMaxUpgradeCountMedium;
    public int movementSpeedMaxUpgradeCountMedium;
    public int enduranceMaxUpgradeCountMedium;
    public int enduranceRegenerationMaxUpgradeCountMedium;

    [Header("Hard")]
    public int healthMaxUpgradeCountHard;
    public int healthRegenerationMaxUpgradeCountHard;
    public int armorMaxUpgradeCountHard;
    public int movementSpeedMaxUpgradeCountHard;
    public int enduranceMaxUpgradeCountHard;
    public int enduranceRegenerationMaxUpgradeCountHard;

    [Space(10f, order = 0)]

    public TMP_Text healthCostText;              
    public TMP_Text healthRegenerationCostText;    
    public TMP_Text armorCostText;                 
    public TMP_Text movementSpeedCostText;             
    public TMP_Text enduranceCostText;              
    public TMP_Text enduranceRegenerationCostText;

    public TMP_Text healthProgressionText;              
    public TMP_Text healthRegenerationProgressionText;  
    public TMP_Text armorProgressionText;                  
    public TMP_Text movementSpeedProgressionText;         
    public TMP_Text enduranceProgressionText;            
    public TMP_Text enduranceRegenerationProgressionText;

    public Slider healthCostSlider;
    public Slider healthRegenerationCostSlider;
    public Slider armorCostSlider;
    public Slider movementSpeedCostSlider;
    public Slider enduranceCostSlider;
    public Slider enduranceRegenerationCostSlider;

    [Header("WaterBomb")]

    [Header("Easy")]

    [Header("Costs")]

    public int dryCostEasy;
    public int dryRegenerationCostEasy;
    public int tankCostEasy;
    public int movementSpeedWaterBombCostEasy;
    public int enduranceWaterBombCostEasy;
    public int enduranceRegenerationWaterBombCostEasy;

    [Header("Medium")]
    public int dryCostMedium;
    public int dryRegenerationCostMedium;
    public int tankCostMedium;
    public int movementSpeedWaterBombCostMedium;
    public int enduranceWaterBombCostMedium;
    public int enduranceRegenerationWaterBombCostMedium;

    [Header("Hard")]
    public int dryCostHard;
    public int dryRegenerationCostHard;
    public int tankCostHard;
    public int movementSpeedWaterBombCostHard;
    public int enduranceWaterBombCostHard;
    public int enduranceRegenerationWaterBombCostHard;

    [Header("Easy")]

    [Header("MaxCounts")]
    public int dryMaxUpgradeCountEasy;
    public int dryRegenerationMaxUpgradeCountEasy;
    public int tankMaxUpgradeCountEasy;
    public int movementSpeedWaterBombMaxUpgradeCountEasy;
    public int enduranceWaterBombMaxUpgradeCountEasy;
    public int enduranceRegenerationWaterBombMaxUpgradeCountEasy;

    [Header("Medium")]
    public int dryMaxUpgradeCountMedium;
    public int dryRegenerationMaxUpgradeCountMedium;
    public int tankMaxUpgradeCountMedium;
    public int movementSpeedWaterBombMaxUpgradeCountMedium;
    public int enduranceWaterBombMaxUpgradeCountMedium;
    public int enduranceRegenerationWaterBombMaxUpgradeCountMedium;

    [Header("Hard")]
    public int dryMaxUpgradeCountHard;
    public int dryRegenerationMaxUpgradeCountHard;
    public int tankMaxUpgradeCountHard;
    public int movementSpeedWaterBombMaxUpgradeCountHard;
    public int enduranceWaterBombMaxUpgradeCountHard;
    public int enduranceRegenerationWaterBombMaxUpgradeCountHard;

    [Space(10f, order = 0)]

    public TMP_Text dryCostText;
    public TMP_Text dryRegenerationCostText;
    public TMP_Text tankCostText;
    public TMP_Text movementSpeedWaterBombCostText;
    public TMP_Text enduranceWaterBombCostText;
    public TMP_Text enduranceRegenerationWaterBombCostText;

    public TMP_Text dryProgressionText;
    public TMP_Text dryRegenerationProgressionText;
    public TMP_Text tankProgressionText;
    public TMP_Text movementSpeedWaterBombProgressionText;
    public TMP_Text enduranceWaterBombProgressionText;
    public TMP_Text enduranceRegenerationWaterBombProgressionText;

    public Slider dryCostSlider;
    public Slider dryRegenerationCostSlider;
    public Slider tankCostSlider;
    public Slider movementSpeedWaterBombCostSlider;
    public Slider enduranceWaterBombCostSlider;
    public Slider enduranceRegenerationWaterBombCostSlider;

    [System.NonSerialized]
    public int healthCost;
    [System.NonSerialized]
    public int healthRegenerationCost;
    [System.NonSerialized]
    public int armorCost;
    [System.NonSerialized]
    public int dryCost;
    [System.NonSerialized]
    public int dryRegenerationCost;
    [System.NonSerialized]
    public int tankCost;
    [System.NonSerialized]
    public int movementSpeedCost;
    [System.NonSerialized]
    public int enduranceCost;
    [System.NonSerialized]
    public int enduranceRegenerationCost;
    [System.NonSerialized]
    public int movementSpeedWaterBombCost;
    [System.NonSerialized]
    public int enduranceWaterBombCost;
    [System.NonSerialized]
    public int enduranceRegenerationWaterBombCost;

    [System.NonSerialized]
    public int healthMaxUpgradeCount;
    [System.NonSerialized]
    public int healthRegenerationMaxUpgradeCount;
    [System.NonSerialized]
    public int armorMaxUpgradeCount;
    [System.NonSerialized]
    public int dryMaxUpgradeCount;
    [System.NonSerialized]
    public int dryRegenerationMaxUpgradeCount;
    [System.NonSerialized]
    public int tankMaxUpgradeCount;
    [System.NonSerialized]
    public int movementSpeedMaxUpgradeCount;
    [System.NonSerialized]
    public int enduranceMaxUpgradeCount;
    [System.NonSerialized]
    public int enduranceRegenerationMaxUpgradeCount;
    [System.NonSerialized]
    public int movementSpeedWaterBombMaxUpgradeCount;
    [System.NonSerialized]
    public int enduranceWaterBombMaxUpgradeCount;
    [System.NonSerialized]
    public int enduranceRegenerationWaterBombMaxUpgradeCount;

    [System.NonSerialized]
    public int healthUpgradeCurrentCount;
    [System.NonSerialized]
    public int healthRegenerationUpgradeCurrentCount;
    [System.NonSerialized]
    public int armorUpgradeCurrentCount;
    [System.NonSerialized]
    public int dryUpgradeCurrentCount;
    [System.NonSerialized]
    public int dryRegenerationUpgradeCurrentCount;
    [System.NonSerialized]
    public int tankUpgradeCurrentCount;
    [System.NonSerialized]
    public int movementSpeedUpgradeCurrentCount;
    [System.NonSerialized]
    public int enduranceUpgradeCurrentCount;
    [System.NonSerialized]
    public int enduranceRegenerationUpgradeCurrentCount;
    [System.NonSerialized]
    public int movementSpeedWaterBombUpgradeCurrentCount;
    [System.NonSerialized]
    public int enduranceWaterBombUpgradeCurrentCount;
    [System.NonSerialized]
    public int enduranceRegenerationWaterBombUpgradeCurrentCount;

    [System.NonSerialized]
    public int coins;

    void Start()
    {

        SetValues();
        SetTexts();
    }

    void Update()
    {
        if (this.isActiveAndEnabled)
        {
            CheckForBuyPossibility();
        }
    }

    public void SetValues()
    {
        SaveDataDifficulty diffData = SaveSystem.LoadDataDifficultySave();
        int diff = diffData.difficultySave;

        switch (diff)
        {
            case 0:

                //Costs

                healthCost = healthCostEasy;
                healthRegenerationCost = healthRegenerationCostEasy;
                armorCost = armorCostEasy;
                dryCost = dryCostEasy;
                dryRegenerationCost = dryRegenerationCostEasy;
                tankCost = tankCostEasy;
                movementSpeedCost = movementSpeedCostEasy;
                enduranceCost = enduranceCostEasy;
                enduranceRegenerationCost = enduranceRegenerationCostEasy;
                movementSpeedWaterBombCost = movementSpeedWaterBombCostEasy;
                enduranceWaterBombCost = enduranceWaterBombCostEasy;
                enduranceRegenerationWaterBombCost = enduranceRegenerationWaterBombCostEasy;

                //MaxCounts
                healthMaxUpgradeCount = healthMaxUpgradeCountEasy;
                healthRegenerationMaxUpgradeCount = healthRegenerationMaxUpgradeCountEasy;
                armorMaxUpgradeCount = armorMaxUpgradeCountEasy;
                dryMaxUpgradeCount = dryMaxUpgradeCountEasy;
                dryRegenerationMaxUpgradeCount = dryRegenerationMaxUpgradeCountEasy;
                tankMaxUpgradeCount = tankMaxUpgradeCountEasy;
                movementSpeedMaxUpgradeCount = movementSpeedMaxUpgradeCountEasy;
                enduranceMaxUpgradeCount = enduranceMaxUpgradeCountEasy;
                enduranceRegenerationMaxUpgradeCount = enduranceRegenerationMaxUpgradeCountEasy;
                movementSpeedWaterBombMaxUpgradeCount = movementSpeedWaterBombMaxUpgradeCountEasy;
                enduranceWaterBombMaxUpgradeCount = enduranceWaterBombMaxUpgradeCountEasy;
                enduranceRegenerationWaterBombMaxUpgradeCount = enduranceRegenerationWaterBombMaxUpgradeCountEasy;

                break;
            case 1:

                //Costs

                healthCost = healthCostMedium;
                healthRegenerationCost = healthRegenerationCostMedium;
                armorCost = armorCostMedium;
                dryCost = dryCostMedium;
                dryRegenerationCost = dryRegenerationCostMedium;
                tankCost = tankCostMedium;
                movementSpeedCost = movementSpeedCostMedium;
                enduranceCost = enduranceCostMedium;
                enduranceRegenerationCost = enduranceRegenerationCostMedium;
                movementSpeedWaterBombCost = movementSpeedWaterBombCostMedium;
                enduranceWaterBombCost = enduranceWaterBombCostMedium;
                enduranceRegenerationWaterBombCost = enduranceRegenerationWaterBombCostMedium;

                //MaxCounts
                healthMaxUpgradeCount = healthMaxUpgradeCountMedium;
                healthRegenerationMaxUpgradeCount = healthRegenerationMaxUpgradeCountMedium;
                armorMaxUpgradeCount = armorMaxUpgradeCountMedium;
                dryMaxUpgradeCount = dryMaxUpgradeCountMedium;
                dryRegenerationMaxUpgradeCount = dryRegenerationMaxUpgradeCountMedium;
                tankMaxUpgradeCount = tankMaxUpgradeCountMedium;
                movementSpeedMaxUpgradeCount = movementSpeedMaxUpgradeCountMedium;
                enduranceMaxUpgradeCount = enduranceMaxUpgradeCountMedium;
                enduranceRegenerationMaxUpgradeCount = enduranceRegenerationMaxUpgradeCountMedium;
                movementSpeedWaterBombMaxUpgradeCount = movementSpeedWaterBombMaxUpgradeCountMedium;
                enduranceWaterBombMaxUpgradeCount = enduranceWaterBombMaxUpgradeCountMedium;
                enduranceRegenerationWaterBombMaxUpgradeCount = enduranceRegenerationWaterBombMaxUpgradeCountMedium;

                break;
            case 2:

                //Costs

                healthCost = healthCostHard;
                healthRegenerationCost = healthRegenerationCostHard;
                armorCost = armorCostHard;
                dryCost = dryCostHard;
                dryRegenerationCost = dryRegenerationCostHard;
                tankCost = tankCostHard;
                movementSpeedCost = movementSpeedCostHard;
                enduranceCost = enduranceCostHard;
                enduranceRegenerationCost = enduranceRegenerationCostHard;
                movementSpeedWaterBombCost = movementSpeedWaterBombCostHard;
                enduranceWaterBombCost = enduranceWaterBombCostHard;
                enduranceRegenerationWaterBombCost = enduranceRegenerationWaterBombCostHard;

                //MaxCounts
                healthMaxUpgradeCount = healthMaxUpgradeCountHard;
                healthRegenerationMaxUpgradeCount = healthRegenerationMaxUpgradeCountHard;
                armorMaxUpgradeCount = armorMaxUpgradeCountHard;
                dryMaxUpgradeCount = dryMaxUpgradeCountHard;
                dryRegenerationMaxUpgradeCount = dryRegenerationMaxUpgradeCountHard;
                tankMaxUpgradeCount = tankMaxUpgradeCountHard;
                movementSpeedMaxUpgradeCount = movementSpeedMaxUpgradeCountHard;
                enduranceMaxUpgradeCount = enduranceMaxUpgradeCountHard;
                enduranceRegenerationMaxUpgradeCount = enduranceRegenerationMaxUpgradeCountHard;
                movementSpeedWaterBombMaxUpgradeCount = movementSpeedWaterBombMaxUpgradeCountHard;
                enduranceWaterBombMaxUpgradeCount = enduranceWaterBombMaxUpgradeCountHard;
                enduranceRegenerationWaterBombMaxUpgradeCount = enduranceRegenerationWaterBombMaxUpgradeCountHard;

                break;
        }

        //Slider Values
        healthCostSlider.maxValue = healthMaxUpgradeCount;
        healthRegenerationCostSlider.maxValue = healthRegenerationMaxUpgradeCount;
        armorCostSlider.maxValue = armorMaxUpgradeCount;
        dryCostSlider.maxValue = dryMaxUpgradeCount;
        dryRegenerationCostSlider.maxValue = dryRegenerationMaxUpgradeCount;
        tankCostSlider.maxValue = tankMaxUpgradeCount;
        movementSpeedCostSlider.maxValue = movementSpeedMaxUpgradeCount;
        enduranceCostSlider.maxValue = enduranceMaxUpgradeCount;
        enduranceRegenerationCostSlider.maxValue = enduranceRegenerationMaxUpgradeCount;
        movementSpeedWaterBombCostSlider.maxValue = movementSpeedWaterBombMaxUpgradeCount;
        enduranceWaterBombCostSlider.maxValue = enduranceWaterBombMaxUpgradeCount;
        enduranceRegenerationWaterBombCostSlider.maxValue = enduranceRegenerationWaterBombMaxUpgradeCount;

    }

    public void SetTexts()
    {
        //ProgressionTexts
        healthProgressionText.text = "0 / " + healthMaxUpgradeCount;
        healthRegenerationProgressionText.text = "0 / " + healthRegenerationMaxUpgradeCount;
        armorProgressionText.text = "0 / " + armorMaxUpgradeCount;
        dryProgressionText.text = "0 / " + dryMaxUpgradeCount;
        dryRegenerationProgressionText.text = "0 / " + dryRegenerationMaxUpgradeCount;
        tankProgressionText.text = "0 / " + tankMaxUpgradeCount;
        movementSpeedProgressionText.text = "0 / " + movementSpeedMaxUpgradeCount;
        enduranceProgressionText.text = "0 / " + enduranceMaxUpgradeCount;
        enduranceRegenerationProgressionText.text = "0 / " + enduranceRegenerationMaxUpgradeCount;
        movementSpeedWaterBombProgressionText.text = "0 / " + movementSpeedWaterBombMaxUpgradeCount;
        enduranceWaterBombProgressionText.text = "0 / " + enduranceWaterBombMaxUpgradeCount;
        enduranceRegenerationWaterBombProgressionText.text = "0 / " + enduranceRegenerationWaterBombMaxUpgradeCount;

        //CostTexts
        healthCostText.text = healthCost + "";
        healthRegenerationCostText.text = healthRegenerationCost + "";
        armorCostText.text = armorCost + "";
        dryCostText.text = dryCost + "";
        dryRegenerationCostText.text = dryRegenerationCost + "";
        tankCostText.text = tankCost + "";
        movementSpeedCostText.text = movementSpeedCost + "";
        enduranceCostText.text = enduranceCost + "";
        enduranceRegenerationCostText.text = enduranceRegenerationCost + "";
        movementSpeedWaterBombCostText.text = movementSpeedWaterBombCost + "";
        enduranceWaterBombCostText.text = enduranceWaterBombCost + "";
        enduranceRegenerationWaterBombCostText.text = enduranceRegenerationWaterBombCost + "";
    }

    public void SetHealthCount(int current, int max)
    {
        healthProgressionText.text = current + " / " + max;
        healthCostSlider.value = current;
    }

    public void SetHealthRegenerationCount(int current, int max)
    {
        healthRegenerationProgressionText.text =  current + " / " + max;
        healthRegenerationCostSlider.value = current;
    }

    public void SetArmorCount(int current, int max)
    {
        armorProgressionText.text = current + " / " + max;
        armorCostSlider.value = current;
    }

    public void SetDryCount(int current, int max)
    {
        dryProgressionText.text = current + " / " + max;
        dryCostSlider.value = current;
    }

    public void SetDryRegenerationCount(int current, int max)
    {
        dryRegenerationProgressionText.text =  current + " / " + max;
        dryRegenerationCostSlider.value = current;
    }

    public void SetTankCount(int current, int max)
    {
        tankProgressionText.text = current + " / " + max;
        tankCostSlider.value = current;
    }

    public void SetMovementSpeedCount(int current, int max)
    {
        movementSpeedProgressionText.text = current + " / " + max;
        movementSpeedCostSlider.value = current;
    }

    public void SetEnduranceCount(int current, int max)
    {
        enduranceProgressionText.text = current + " / " + max;
        enduranceCostSlider.value = current;
    }

    public void SetEnduranceRegenerationCount(int current, int max)
    {
        enduranceRegenerationProgressionText.text = current + " / " + max;
        enduranceRegenerationCostSlider.value = current;
    }

    public void SetMovementSpeedWaterBombCount(int current, int max)
    {
        movementSpeedWaterBombProgressionText.text = current + " / " + max;
        movementSpeedWaterBombCostSlider.value = current;
    }

    public void SetEnduranceWaterBombCount(int current, int max)
    {
        enduranceWaterBombProgressionText.text = current + " / " + max;
        enduranceWaterBombCostSlider.value = current;
    }

    public void SetEnduranceRegenerationWaterBombCount(int current, int max)
    {
        enduranceRegenerationWaterBombProgressionText.text = current + " / " + max;
        enduranceRegenerationWaterBombCostSlider.value = current;
    }

    public void SetHealthCost(int cost)
    {
        healthCostText.text = cost + "";
        healthCost = cost;
    }

    public void SetHealthRegenerationCost(int cost)
    {
        healthRegenerationCostText.text = cost + "";
        healthRegenerationCost = cost;
    }

    public void SetArmorCost(int cost)
    {
        armorCostText.text = cost + "";
        armorCost = cost;
    }

    public void SetDryCost(int cost)
    {
        dryCostText.text = cost + "";
        dryCost = cost;
    }

    public void SetDryRegenerationCost(int cost)
    {
        dryRegenerationCostText.text = cost + "";
        dryRegenerationCost = cost;
    }

    public void SetTankCost(int cost)
    {
        tankCostText.text = cost + "";
        tankCost = cost;
    }

    public void SetMovementSpeedCost(int cost)
    {
        movementSpeedCostText.text = cost + "";
        movementSpeedCost = cost;
    }

    public void SetEnduranceCost(int cost)
    {
        enduranceCostText.text = cost + "";
        enduranceCost = cost;
    }

    public void SetEnduranceRegenerationCost(int cost)
    {
        enduranceRegenerationCostText.text = cost + "";
        enduranceRegenerationCost = cost;
    }

    public void SetMovementSpeedWaterBombCost(int cost)
    {
        movementSpeedWaterBombCostText.text = cost + "";
        movementSpeedWaterBombCost = cost;
    }

    public void SetEnduranceWaterBombCost(int cost)
    {
        enduranceWaterBombCostText.text = cost + "";
        enduranceWaterBombCost = cost;
    }

    public void SetEnduranceRegenerationWaterBombCost(int cost)
    {
        enduranceRegenerationWaterBombCostText.text = cost + "";
        enduranceRegenerationWaterBombCost = cost;
    }

    public void LockHealthButton(string text)
    {
        healthCostText.text = text;
    }

    public void LockHealthRegenerationButton(string text)
    {
        healthRegenerationCostText.text = text;
    }

    public void LockArmorButton(string text)
    {
        armorCostText.text = text;
    }

    public void LockDryButton(string text)
    {
        dryCostText.text = text;
    }

    public void LockDryRegenerationButton(string text)
    {
        dryRegenerationCostText.text = text;
    }

    public void LockTankButton(string text)
    {
        tankCostText.text = text;
    }

    public void LockMovementSpeedButton(string text)
    {
        movementSpeedCostText.text = text;
    }

    public void LockEnduranceButton(string text)
    {
        enduranceCostText.text = text;
    }

    public void LockEnduranceRegenerationButton(string text)
    {
        enduranceRegenerationCostText.text = text;
    }

    public void LockMovementSpeedWaterBombButton(string text)
    {
        movementSpeedWaterBombCostText.text = text;
    }

    public void LockEnduranceWaterBombButton(string text)
    {
        enduranceWaterBombCostText.text = text;
    }

    public void LockEnduranceRegenerationWaterBombButton(string text)
    {
        enduranceRegenerationWaterBombCostText.text = text;
    }

    public int GetNextCost(int oldCost, float multiplier, float max)
    {
        float newCost = 8 + Mathf.Pow(2.4f, (multiplier * oldCost)) + 3.5f;
        if ((oldCost + 1.6) > newCost)
        {
            newCost = newCost + 3;
        }
        if (newCost > max)
        {
            newCost = max;
        }

        return Mathf.RoundToInt(newCost);
    }

    public void CheckForBuyPossibility()
    {
        //Health
        if (coins >= healthCost)
        {
            SetHealthCost(healthCost);
        }
        else
        {
            LockHealthButton("LOCKED! " + healthCost);
        }
        if (healthUpgradeCurrentCount == healthMaxUpgradeCount)
        {
            LockHealthButton("FULL");
        }
        //HealthRegeneration
        if (coins >= healthRegenerationCost)
        {
            SetHealthRegenerationCost(healthRegenerationCost);
        }
        else
        {
            LockHealthRegenerationButton("LOCKED! " + healthRegenerationCost);
        }
        if (healthRegenerationUpgradeCurrentCount == healthRegenerationMaxUpgradeCount)
        {
            LockHealthRegenerationButton("FULL");
        }
        //Armor
        if (coins >= armorCost)
        {
            SetArmorCost(armorCost);
        }
        else
        {
            LockArmorButton("LOCKED! " + armorCost);
        }
        if (armorUpgradeCurrentCount == armorMaxUpgradeCount)
        {
            LockArmorButton("FULL");
        }
        //MovementSpeed
        if (coins >= movementSpeedCost)
        {
            SetMovementSpeedCost(movementSpeedCost);
        }
        else
        {
            LockMovementSpeedButton("LOCKED! " + movementSpeedCost);
        }
        if (movementSpeedUpgradeCurrentCount == movementSpeedMaxUpgradeCount)
        {
            LockMovementSpeedButton("FULL");
        }
        //Endurance
        if (coins >= enduranceCost)
        {
            SetEnduranceCost(enduranceCost);
        }
        else
        {
            LockEnduranceButton("LOCKED! " + enduranceCost);
        }
        if (enduranceUpgradeCurrentCount == enduranceMaxUpgradeCount)
        {
            LockEnduranceButton("FULL");
        }
        //EnduranceRegeneration
        if (coins >= enduranceRegenerationCost)
        {
            SetEnduranceRegenerationCost(enduranceRegenerationCost);
        }
        else
        {
            LockEnduranceRegenerationButton("LOCKED! " + enduranceRegenerationCost);
        }
        if (enduranceRegenerationUpgradeCurrentCount == enduranceRegenerationMaxUpgradeCount)
        {
            LockEnduranceRegenerationButton("FULL");
        }

        //Dry
        if (coins >= dryCost)
        {
            SetDryCost(dryCost);
        }
        else
        {
            LockDryButton("LOCKED! " + dryCost);
        }
        if (dryUpgradeCurrentCount == dryMaxUpgradeCount)
        {
            LockDryButton("FULL");
        }
        //DryRegeneration
        if (coins >= dryRegenerationCost)
        {
            SetDryRegenerationCost(dryRegenerationCost);
        }
        else
        {
            LockDryRegenerationButton("LOCKED! " + dryRegenerationCost);
        }
        if (dryRegenerationUpgradeCurrentCount == dryRegenerationMaxUpgradeCount)
        {
            LockDryRegenerationButton("FULL");
        }
        //Tank
        if (coins >= tankCost)
        {
            SetTankCost(tankCost);
        }
        else
        {
            LockTankButton("LOCKED! " + tankCost);
        }
        if (tankUpgradeCurrentCount == tankMaxUpgradeCount)
        {
            LockTankButton("FULL");
        }
        //MovementSpeedWaterBomb
        if (coins >= movementSpeedWaterBombCost)
        {
            SetMovementSpeedWaterBombCost(movementSpeedWaterBombCost);
        }
        else
        {
            LockMovementSpeedWaterBombButton("LOCKED! " + movementSpeedWaterBombCost);
        }
        if (movementSpeedWaterBombUpgradeCurrentCount == movementSpeedWaterBombMaxUpgradeCount)
        {
            LockMovementSpeedWaterBombButton("FULL");
        }
        //EnduranceWaterBomb
        if (coins >= enduranceWaterBombCost)
        {
            SetEnduranceWaterBombCost(enduranceWaterBombCost);
        }
        else
        {
            LockEnduranceWaterBombButton("LOCKED! " + enduranceWaterBombCost);
        }
        if (enduranceWaterBombUpgradeCurrentCount == enduranceWaterBombMaxUpgradeCount)
        {
            LockEnduranceWaterBombButton("FULL");
        }
        //EnduranceRegenerationWaterBomb
        if (coins >= enduranceRegenerationWaterBombCost)
        {
            SetEnduranceRegenerationWaterBombCost(enduranceRegenerationWaterBombCost);
        }
        else
        {
            LockEnduranceRegenerationWaterBombButton("LOCKED! " + enduranceRegenerationWaterBombCost);
        }
        if (enduranceRegenerationWaterBombUpgradeCurrentCount == enduranceRegenerationWaterBombMaxUpgradeCount)
        {
            LockEnduranceRegenerationWaterBombButton("FULL");
        }

    }
}
