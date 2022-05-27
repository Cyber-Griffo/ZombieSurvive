using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponUpgrade : MonoBehaviour
{
    [Header("Gun")]

    [Header("Easy")]

    [Header("Costs")]
    public int magazineSizeCostEasy;
    public int reloadingTimeCostEasy;
    public int fireRateCostEasy;
    public int silencerCostEasy;
    public int damageCostEasy;
    public int criticalHitChanceCostEasy;

    [Header("Medium")]
    public int magazineSizeCostMedium;
    public int reloadingTimeCostMedium;
    public int fireRateCostMedium;
    public int silencerCostMedium;
    public int damageCostMedium;
    public int criticalHitChanceCostMedium;

    [Header("Hard")]
    public int magazineSizeCostHard;
    public int reloadingTimeCostHard;
    public int fireRateCostHard;
    public int silencerCostHard;
    public int damageCostHard;
    public int criticalHitChanceCostHard;


    [Header("Easy")]

    [Header("MaxCounts")]
    public int magazineSizeUpgradeMaxCountEasy;
    public int reloadingTimeUpgradeMaxCountEasy;
    public int fireRateUpgradeMaxCountEasy;
    public int silencerUpgradeMaxCountEasy;
    public int damageUpgradeMaxCountEasy;
    public int criticalHitChanceUpgradeMaxCountEasy;

    [Header("Medium")]
    public int magazineSizeUpgradeMaxCountMedium;
    public int reloadingTimeUpgradeMaxCountMedium;
    public int fireRateUpgradeMaxCountMedium;
    public int silencerUpgradeMaxCountMedium;
    public int damageUpgradeMaxCountMedium;
    public int criticalHitChanceUpgradeMaxCountMedium;

    [Header("Hard")]
    public int magazineSizeUpgradeMaxCountHard;
    public int reloadingTimeUpgradeMaxCountHard;
    public int fireRateUpgradeMaxCountHard;
    public int silencerUpgradeMaxCountHard;
    public int damageUpgradeMaxCountHard;
    public int criticalHitChanceUpgradeMaxCountHard;

    [Header("WaterGun")]

    [Header("Easy")]

    [Header("Costs")]
    public int tankSizeCostEasy;
    public int refillingTimeCostEasy;
    public int fireRateCostWaterGunEasy;
    public int waterFillCostEasy;
    public int doubleFillChanceCostEasy;

    [Header("Medium")]
    public int tankSizeCostMedium;
    public int refillingTimeCostMedium;
    public int fireRateCostWaterGunMedium;
    public int waterFillCostMedium;
    public int doubleFillChanceCostMedium;

    [Header("Hard")]
    public int tankSizeCostHard;
    public int refillingTimeCostHard;
    public int fireRateCostWaterGunHard;
    public int waterFillCostHard;
    public int doubleFillChanceCostHard;

    [Header("Easy")]

    [Header("MaxCounts")]
    public int tankSizeUpgradeMaxCountEasy;
    public int refillingTimeUpgradeMaxCountEasy;
    public int fireRateWaterGunUpgradeMaxCountEasy;
    public int waterFillUpgradeMaxCountEasy;
    public int doubleFillChanceUpgradeMaxCountEasy;

    [Header("Medium")]
    public int tankSizeUpgradeMaxCountMedium;
    public int refillingTimeUpgradeMaxCountMedium;
    public int fireRateWaterGunUpgradeMaxCountMedium;
    public int waterFillUpgradeMaxCountMedium;
    public int doubleFillChanceUpgradeMaxCountMedium;

    [Header("Hard")]
    public int tankSizeUpgradeMaxCountHard;
    public int refillingTimeUpgradeMaxCountHard;
    public int fireRateWaterGunUpgradeMaxCountHard;
    public int waterFillUpgradeMaxCountHard;
    public int doubleFillChanceUpgradeMaxCountHard;

    [Space(10f, order = 0)]

    public TMP_Text magzineSizeCostText;
    public TMP_Text reloadingTimeCostText;
    public TMP_Text fireRateCostText;
    public TMP_Text sliencerCostText;
    public TMP_Text damageCostText;
    public TMP_Text criticalHitChanceCostText;

    public TMP_Text magzineSizeProgressionText;
    public TMP_Text reloadingTimeProgressionText;
    public TMP_Text fireRateProgressionText;
    public TMP_Text sliencerProgressionText;
    public TMP_Text damageProgressionText;
    public TMP_Text criticalHitChanceProgressionText;

    public Slider magazineSizeCostSlider;
    public Slider reloadingTimeCostSlider;
    public Slider fireRateCostSlider;
    public Slider silencerCostSlider;
    public Slider damageCostSlider;
    public Slider criticalHitChanceCostSlider;

    public TMP_Text tankSizeCostText;
    public TMP_Text refillingTimeCostText;
    public TMP_Text fireRateWaterGunCostText;
    public TMP_Text waterFillCostText;
    public TMP_Text doubleFillChanceCostText;

    public TMP_Text tankSizeProgressionText;
    public TMP_Text refillingTimeProgressionText;
    public TMP_Text fireRateWaterGunProgressionText;
    public TMP_Text waterFillProgressionText;
    public TMP_Text doubleFillChanceProgressionText;

    public Slider tankSizeCostSlider;
    public Slider refillingTimeCostSlider;
    public Slider fireRateWaterGunCostSlider;
    public Slider waterFillCostSlider;
    public Slider doubleFillChanceCostSlider;

    [System.NonSerialized]
    public int magazineSizeCost;
    [System.NonSerialized]
    public int reloadingTimeCost;
    [System.NonSerialized]
    public int fireRateCost;
    [System.NonSerialized]
    public int silencerCost;
    [System.NonSerialized]
    public int damageCost;
    [System.NonSerialized]
    public int criticalHitChanceCost;

    [System.NonSerialized]
    public int magazineSizeUpgradeMaxCount;
    [System.NonSerialized]
    public int reloadingTimeUpgradeMaxCount;
    [System.NonSerialized]
    public int fireRateUpgradeMaxCount;
    [System.NonSerialized]
    public int silencerUpgradeMaxCount;
    [System.NonSerialized]
    public int damageUpgradeMaxCount;
    [System.NonSerialized]
    public int criticalHitChanceUpgradeMaxCount;

    [System.NonSerialized]
    public int magazineSizeUpgradeCurrentCount;
    [System.NonSerialized]
    public int reloadingTimeUpgradeCurrentCount;
    [System.NonSerialized]
    public int fireRateUpgradeCurrentCount;
    [System.NonSerialized]
    public int silencerUpgradeCurrentCount;
    [System.NonSerialized]
    public int damageUpgradeCurrentCount;
    [System.NonSerialized]
    public int criticalHitChanceUpgradeCurrentCount;

    [System.NonSerialized]
    public int tankSizeCost;
    [System.NonSerialized]
    public int refillingTimeCost;
    [System.NonSerialized]
    public int fireRateCostWaterGun;
    [System.NonSerialized]
    public int waterFillCost;
    [System.NonSerialized]
    public int doubleFillChanceCost;

    [System.NonSerialized]
    public int tankSizeUpgradeMaxCount;
    [System.NonSerialized]
    public int refillingTimeUpgradeMaxCount;
    [System.NonSerialized]
    public int fireRateWaterGunUpgradeMaxCount;
    [System.NonSerialized]
    public int waterFillUpgradeMaxCount;
    [System.NonSerialized]
    public int doubleFillChanceUpgradeMaxCount;

    [System.NonSerialized]
    public int tankSizeUpgradeCurrentCount;
    [System.NonSerialized]
    public int refillingTimeUpgradeCurrentCount;
    [System.NonSerialized]
    public int fireRateWaterGunUpgradeCurrentCount;
    [System.NonSerialized]
    public int waterFillUpgradeCurrentCount;
    [System.NonSerialized]
    public int doubleFillChanceUpgradeCurrentCount;

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

                //Gun
                //Costs
                magazineSizeCost = magazineSizeCostEasy;
                reloadingTimeCost = reloadingTimeCostEasy;
                fireRateCost = fireRateCostEasy;
                silencerCost = silencerCostEasy;
                damageCost = damageCostEasy;
                criticalHitChanceCost = criticalHitChanceCostEasy;

                //MaxCounts
                magazineSizeUpgradeMaxCount = magazineSizeUpgradeMaxCountEasy;
                reloadingTimeUpgradeMaxCount = reloadingTimeUpgradeMaxCountEasy;
                fireRateUpgradeMaxCount = fireRateUpgradeMaxCountEasy;
                silencerUpgradeMaxCount = silencerUpgradeMaxCountEasy;
                criticalHitChanceUpgradeMaxCount = criticalHitChanceUpgradeMaxCountEasy;
                damageUpgradeMaxCount = damageUpgradeMaxCountEasy;

                //WaterGun
                //Costs
                tankSizeCost = tankSizeCostEasy;
                refillingTimeCost = refillingTimeCostEasy;
                fireRateCostWaterGun = fireRateCostWaterGunEasy;
                waterFillCost = waterFillCostEasy;
                doubleFillChanceCost = doubleFillChanceCostEasy;

                //MaxCounts
                tankSizeUpgradeMaxCount = tankSizeUpgradeMaxCountEasy;
                refillingTimeUpgradeMaxCount = refillingTimeUpgradeMaxCountEasy;
                fireRateWaterGunUpgradeMaxCount = fireRateWaterGunUpgradeMaxCountEasy;
                doubleFillChanceUpgradeMaxCount = doubleFillChanceUpgradeMaxCountEasy;
                waterFillUpgradeMaxCount = waterFillUpgradeMaxCountEasy;

                break;
            case 1:

                //Gun
                //Costs
                magazineSizeCost = magazineSizeCostMedium;
                reloadingTimeCost = reloadingTimeCostMedium;
                fireRateCost = fireRateCostMedium;
                silencerCost = silencerCostMedium;
                damageCost = damageCostMedium;
                criticalHitChanceCost = criticalHitChanceCostMedium;

                //MaxCounts
                magazineSizeUpgradeMaxCount = magazineSizeUpgradeMaxCountMedium;
                reloadingTimeUpgradeMaxCount = reloadingTimeUpgradeMaxCountMedium;
                fireRateUpgradeMaxCount = fireRateUpgradeMaxCountMedium;
                silencerUpgradeMaxCount = silencerUpgradeMaxCountMedium;
                criticalHitChanceUpgradeMaxCount = criticalHitChanceUpgradeMaxCountMedium;
                damageUpgradeMaxCount = damageUpgradeMaxCountMedium;

                //WaterGun
                //Costs
                tankSizeCost = tankSizeCostMedium;
                refillingTimeCost = refillingTimeCostMedium;
                fireRateCostWaterGun = fireRateCostWaterGunMedium;
                waterFillCost = waterFillCostMedium;
                doubleFillChanceCost = doubleFillChanceCostMedium;

                //MaxCounts
                tankSizeUpgradeMaxCount = tankSizeUpgradeMaxCountMedium;
                refillingTimeUpgradeMaxCount = refillingTimeUpgradeMaxCountMedium;
                fireRateWaterGunUpgradeMaxCount = fireRateWaterGunUpgradeMaxCountMedium;
                doubleFillChanceUpgradeMaxCount = doubleFillChanceUpgradeMaxCountMedium;
                waterFillUpgradeMaxCount = waterFillUpgradeMaxCountMedium;

                break;
            case 2:

                //Gun
                //Costs
                magazineSizeCost = magazineSizeCostHard;
                reloadingTimeCost = reloadingTimeCostHard;
                fireRateCost = fireRateCostHard;
                silencerCost = silencerCostHard;
                damageCost = damageCostHard;
                criticalHitChanceCost = criticalHitChanceCostHard;

                //MaxCounts
                magazineSizeUpgradeMaxCount = magazineSizeUpgradeMaxCountHard;
                reloadingTimeUpgradeMaxCount = reloadingTimeUpgradeMaxCountHard;
                fireRateUpgradeMaxCount = fireRateUpgradeMaxCountHard;
                silencerUpgradeMaxCount = silencerUpgradeMaxCountHard;
                criticalHitChanceUpgradeMaxCount = criticalHitChanceUpgradeMaxCountHard;
                damageUpgradeMaxCount = damageUpgradeMaxCountHard;

                //WaterGun
                //Costs
                tankSizeCost = tankSizeCostHard;
                refillingTimeCost = refillingTimeCostHard;
                fireRateCostWaterGun = fireRateCostWaterGunHard;
                waterFillCost = waterFillCostHard;
                doubleFillChanceCost = doubleFillChanceCostHard;

                //MaxCounts
                tankSizeUpgradeMaxCount = tankSizeUpgradeMaxCountHard;
                refillingTimeUpgradeMaxCount = refillingTimeUpgradeMaxCountHard;
                fireRateWaterGunUpgradeMaxCount = fireRateWaterGunUpgradeMaxCountHard;
                doubleFillChanceUpgradeMaxCount = doubleFillChanceUpgradeMaxCountHard;
                waterFillUpgradeMaxCount = waterFillUpgradeMaxCountHard;

                break;
        }

        //Gun
        //Slider Values
        magazineSizeCostSlider.maxValue = magazineSizeUpgradeMaxCount;
        reloadingTimeCostSlider.maxValue = reloadingTimeUpgradeMaxCount;
        fireRateCostSlider.maxValue = fireRateUpgradeMaxCount;
        silencerCostSlider.maxValue = silencerUpgradeMaxCount;
        criticalHitChanceCostSlider.maxValue = criticalHitChanceUpgradeMaxCount;
        damageCostSlider.maxValue = damageUpgradeMaxCount;

        //WaterGun
        //Slider Values
        tankSizeCostSlider.maxValue = tankSizeUpgradeMaxCount;
        refillingTimeCostSlider.maxValue = refillingTimeUpgradeMaxCount;
        fireRateWaterGunCostSlider.maxValue = fireRateWaterGunUpgradeMaxCount;
        doubleFillChanceCostSlider.maxValue = doubleFillChanceUpgradeMaxCount;
        waterFillCostSlider.maxValue = waterFillUpgradeMaxCount;



    }

    public void SetTexts()
    {
        //Gun
        //ProgressionTexts
        magzineSizeProgressionText.text = "0 / " + magazineSizeUpgradeMaxCount;
        reloadingTimeProgressionText.text = "0 / " + reloadingTimeUpgradeMaxCount;
        fireRateProgressionText.text = "0 / " + fireRateUpgradeMaxCount;
        sliencerProgressionText.text = "0 / " + silencerUpgradeMaxCount;
        criticalHitChanceProgressionText.text = "0%";
        damageProgressionText.text = "0 / " + damageUpgradeMaxCount;

        //CostTexts
        magzineSizeCostText.text = magazineSizeCost + "";
        reloadingTimeCostText.text = reloadingTimeCost + "";
        fireRateCostText.text = fireRateCost + "";
        sliencerCostText.text = silencerCost + "";
        criticalHitChanceCostText.text = criticalHitChanceCost + "";
        damageCostText.text = damageCost + "";

        //WaterGun
        //ProgressionTexts
        tankSizeProgressionText.text = "0 / " + tankSizeUpgradeMaxCount;
        refillingTimeProgressionText.text = "0 / " + refillingTimeUpgradeMaxCount;
        fireRateWaterGunProgressionText.text = "0 / " + fireRateWaterGunUpgradeMaxCount;
        doubleFillChanceProgressionText.text = "0%";
        waterFillProgressionText.text = "0 / " + waterFillUpgradeMaxCount;

        //CostTexts
        tankSizeCostText.text = tankSizeCost + "";
        refillingTimeCostText.text = refillingTimeCost + "";
        fireRateWaterGunCostText.text = fireRateCostWaterGun + "";
        doubleFillChanceCostText.text = doubleFillChanceCost + "";
        waterFillCostText.text = waterFillCost + "";
    }

    public void SetMagazineSizeCount(int current, int max)
    {
        magzineSizeProgressionText.text = current + " / " + max;
        magazineSizeCostSlider.value = current;
    }

    public void SetReloadingTimeCount(int current, int max)
    {
        reloadingTimeProgressionText.text = current + " / " + max;
        reloadingTimeCostSlider.value = current;
    }

    public void SetFireRateCount(int current, int max)
    {
        fireRateProgressionText.text = current + " / " + max;
        fireRateCostSlider.value = current;
    }

    public void SetSilencerCount(int current, int max)
    {
        sliencerProgressionText.text = current + " / " + max;
        silencerCostSlider.value = current;
    }

    public void SetCriticalHitChanceCount(int current, int max)
    {
        if (current == 1 && current <= max)
            criticalHitChanceProgressionText.text = "25%";
        else if (current == 2 && current <= max)
            criticalHitChanceProgressionText.text = "50%";
        else if (current == 3 && current <= max)
            criticalHitChanceProgressionText.text = "75%";
        else if (current == 4 && current <= max)
            criticalHitChanceProgressionText.text = "100%";
        else
            criticalHitChanceProgressionText.text = "error accured " + current + " : current Value " + max + " : max Value";
        criticalHitChanceCostSlider.value = current;
    }
    public void SetDamageCount(int current, int max)
    {
        damageProgressionText.text = current + " / " + max;
        damageCostSlider.value = current;
    }

    public void SetTankSizeCount(int current, int max)
    {
        tankSizeProgressionText.text = current + " / " + max;
        tankSizeCostSlider.value = current;
    }

    public void SetRefillingTimeCount(int current, int max)
    {
        refillingTimeProgressionText.text = current + " / " + max;
        refillingTimeCostSlider.value = current;
    }

    public void SetFireRateWaterGunCount(int current, int max)
    {
        fireRateWaterGunProgressionText.text = current + " / " + max;
        fireRateWaterGunCostSlider.value = current;
    }

    public void SetDoubleFillChanceCount(int current, int max)
    {
        if (current == 1 && current <= max)
            doubleFillChanceProgressionText.text = "25%";
        else if (current == 2 && current <= max)
            doubleFillChanceProgressionText.text = "50%";
        else if (current == 3 && current <= max)
            doubleFillChanceProgressionText.text = "75%";
        else if (current == 4 && current <= max)
            doubleFillChanceProgressionText.text = "100%";
        else
            doubleFillChanceProgressionText.text = "error accured " + current + " : current Value " + max + " : max Value";
        doubleFillChanceCostSlider.value = current;
    }
    public void SetWaterFillCount(int current, int max)
    {
        waterFillProgressionText.text = current + " / " + max;
        waterFillCostSlider.value = current;
    }

    public void SetMagazineSizeCost(int cost)
    {
        magzineSizeCostText.text = cost + "";
        magazineSizeCost = cost;
    }

    public void SetReloadingTimeCost(int cost)
    {
        reloadingTimeCostText.text = cost + "";
        reloadingTimeCost = cost;
    }

    public void SetFireRateCost(int cost)
    {
        fireRateCostText.text = cost + "";
        fireRateCost = cost;
    }

    public void SetSilencerCost(int cost)
    {
        sliencerCostText.text = cost + "";
        silencerCost = cost;
    }

    public void SetCriticalHitChanceCost(int cost)
    {
        criticalHitChanceCostText.text = cost + "";
        criticalHitChanceCost = cost;
    }

    public void SetDamageCost(int cost)
    {
        damageCostText.text = cost + "";
        damageCost = cost;
    }

    public void SetTankSizeCost(int cost)
    {
        tankSizeCostText.text = cost + "";
        tankSizeCost = cost;
    }

    public void SetRefillingTimeCost(int cost)
    {
        refillingTimeCostText.text = cost + "";
        refillingTimeCost = cost;
    }

    public void SetFireRateWaterGunCost(int cost)
    {
        fireRateWaterGunCostText.text = cost + "";
        fireRateCostWaterGun = cost;
    }

    public void SetDoubleFillChanceCost(int cost)
    {
        doubleFillChanceCostText.text = cost + "";
        doubleFillChanceCost = cost;
    }

    public void SetWaterFillCost(int cost)
    {
        waterFillCostText.text = cost + "";
        waterFillCost = cost;
    }

    public void LockMagazineSizeButton(string text)
    {
        magzineSizeCostText.text = text;
    }

    public void LockReloadingTimeButton(string text)
    {
        reloadingTimeCostText.text = text;
    }

    public void LockFireRateButton(string text)
    {
        fireRateCostText.text = text;
    }

    public void LockSilencerButton(string text)
    {
        sliencerCostText.text = text;
    }

    public void LockCriticalHitChanceButton(string text)
    {
        criticalHitChanceCostText.text = text;
    }

    public void LockDamageButton(string text)
    {
        damageCostText.text = text;
    }

    public void LockTankSizeButton(string text)
    {
        tankSizeCostText.text = text;
    }

    public void LockRefillingTimeButton(string text)
    {
        refillingTimeCostText.text = text;
    }

    public void LockFireRateWaterGunButton(string text)
    {
        fireRateWaterGunCostText.text = text;
    }

    public void LockDoubleFillChanceButton(string text)
    {
        doubleFillChanceCostText.text = text;
    }

    public void LockWaterFillButton(string text)
    {
        waterFillCostText.text = text;
    }

    public int GetNextCost(int oldCost, float multiplier, float max)
    {
        float newCost = oldCost + Mathf.Pow(2.5f, (multiplier * oldCost)) + 3.5f;
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
        //MagazineSize
        if (coins >= magazineSizeCost)
        {
            SetMagazineSizeCost(magazineSizeCost);
        }
        else
        {
            LockMagazineSizeButton("LOCKED! " + magazineSizeCost);
        }
        if (magazineSizeUpgradeCurrentCount == magazineSizeUpgradeMaxCount)
        {
            LockMagazineSizeButton("FULL");
        }
        //ReloadingTime
        if (coins >= reloadingTimeCost)
        {
            SetReloadingTimeCost(reloadingTimeCost);
        }
        else
        {
            LockReloadingTimeButton("LOCKED! " + reloadingTimeCost);
        }
        if (reloadingTimeUpgradeCurrentCount == reloadingTimeUpgradeMaxCount)
        {
            LockReloadingTimeButton("FULL");
        }
        //FireRate
        if (coins >= fireRateCost)
        {
            SetFireRateCost(fireRateCost);
        }
        else
        {
            LockFireRateButton("LOCKED! " + fireRateCost);
        }
        if (fireRateUpgradeCurrentCount == fireRateUpgradeMaxCount)
        {
            LockFireRateButton("FULL");
        }
        //Silencer
        if (coins >= silencerCost)
        {
            SetSilencerCost(silencerCost);
        }
        else
        {
            LockSilencerButton("LOCKED! " + silencerCost);
        }
        if (silencerUpgradeCurrentCount == silencerUpgradeMaxCount)
        {
            LockSilencerButton("FULL");
        }
        //CriticalHitChance
        if(coins >= criticalHitChanceCost)
        {
            SetCriticalHitChanceCost(criticalHitChanceCost);
        }
        else
        {
            LockCriticalHitChanceButton("LOCKED! " + criticalHitChanceCost);
        }
        if(criticalHitChanceUpgradeCurrentCount == criticalHitChanceUpgradeMaxCount)
        {
            LockCriticalHitChanceButton("FULL");
        }
        //Damage
        if(coins >= damageCost)
        {
            SetDamageCost(damageCost);
        }
        else
        {
            LockDamageButton("LOCKED! " + damageCost);
        }
        if(damageUpgradeCurrentCount == damageUpgradeMaxCount)
        {
            LockDamageButton("FULL");
        }
        //TankSize
        if (coins >= tankSizeCost)
        {
            SetTankSizeCost(tankSizeCost);
        }
        else
        {
            LockTankSizeButton("LOCKED! " + tankSizeCost);
        }
        if (tankSizeUpgradeCurrentCount == tankSizeUpgradeMaxCount)
        {
            LockTankSizeButton("FULL");
        }
        //RefillingTime
        if (coins >= refillingTimeCost)
        {
            SetRefillingTimeCost(refillingTimeCost);
        }
        else
        {
            LockRefillingTimeButton("LOCKED! " + refillingTimeCost);
        }
        if (refillingTimeUpgradeCurrentCount == refillingTimeUpgradeMaxCount)
        {
            LockRefillingTimeButton("FULL");
        }
        //FireRateWaterGun
        if (coins >= fireRateCostWaterGun)
        {
            SetFireRateWaterGunCost(fireRateCostWaterGun);
        }
        else
        {
            LockFireRateWaterGunButton("LOCKED! " + fireRateCostWaterGun);
        }
        if (fireRateWaterGunUpgradeCurrentCount == fireRateWaterGunUpgradeMaxCount)
        {
            LockFireRateWaterGunButton("FULL");
        }
        //DoubleFill
        if (coins >= doubleFillChanceCost)
        {
            SetDoubleFillChanceCost(doubleFillChanceCost);
        }
        else
        {
            LockDoubleFillChanceButton("LOCKED! " + doubleFillChanceCost);
        }
        if (doubleFillChanceUpgradeCurrentCount == doubleFillChanceUpgradeMaxCount)
        {
            LockDoubleFillChanceButton("FULL");
        }
        //WaterFill
        if (coins >= waterFillCost)
        {
            SetWaterFillCost(waterFillCost);
        }
        else
        {
            LockWaterFillButton("LOCKED! " + waterFillCost);
        }
        if (waterFillUpgradeCurrentCount == waterFillUpgradeMaxCount)
        {
            LockWaterFillButton("FULL");
        }
    }
}
