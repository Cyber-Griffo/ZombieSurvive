using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour {

    [Header("ShopSites")]
    public GameObject playerUpgrade_GO;
    public GameObject weaponUpgrade_GO;
    public GameObject playerUpgradeWaterGun_GO;
    public GameObject weaponUpgradeWaterGun_GO;

    [Header("Player")]
    public PlayerUpgrade playerUpgrade;

    [Header("Easy")]
    public int maxHealthIncreasingRateEasy = 25;
    public int maxDryIncreasingRateEasy = 25;
    public float movementSpeedIncreasingRateEasy = 2;
    public float endruanceIncreasingRateEasy = 1f;
    public float enduranceRegenerationIncreasingRateEasy = 1f;
    public float movementSpeedWaterBombIncreasingRateEasy = 2;
    public float endruanceWaterBombIncreasingRateEasy = 1f;
    public float enduranceRegenerationWaterBombIncreasingRateEasy = 1f;
    public int maxArmorIncreasingRateEasy = 15;
    public int healthRegenerationIncreasingRateEasy = 5;
    public int maxTankIncreasingRateEasy = 15;
    public int dryRegenerationIncreasingRateEasy = 5;

    [Header("Medium")]
    public int maxHealthIncreasingRateMedium = 25;
    public int maxDryIncreasingRateMedium = 25;
    public float movementSpeedIncreasingRateMedium = 2;
    public float endruanceIncreasingRateMedium = 1f;
    public float enduranceRegenerationIncreasingRateMedium = 1f;
    public float movementSpeedWaterBombIncreasingRateMedium = 2;
    public float endruanceWaterBombIncreasingRateMedium = 1f;
    public float enduranceRegenerationWaterBombIncreasingRateMedium = 1f;
    public int maxArmorIncreasingRateMedium = 15;
    public int healthRegenerationIncreasingRateMedium = 5;
    public int maxTankIncreasingRateMedium = 15;
    public int dryRegenerationIncreasingRateMedium = 5;

    [Header("Hard")]
    public int maxHealthIncreasingRateHard = 25;
    public int maxDryIncreasingRateHard = 25;
    public float movementSpeedIncreasingRateHard = 2;
    public float endruanceIncreasingRateHard = 1f;
    public float enduranceRegenerationIncreasingRateHard = 1f;
    public float movementSpeedWaterBombIncreasingRateHard = 2;
    public float endruanceWaterBombIncreasingRateHard = 1f;
    public float enduranceRegenerationWaterBombIncreasingRateHard = 1f;
    public int maxArmorIncreasingRateHard = 15;
    public int healthRegenerationIncreasingRateHard = 5;
    public int maxTankIncreasingRateHard = 15;
    public int dryRegenerationIncreasingRateHard = 5;

    [Header("Weapons")]
    public WeaponUpgrade weaponUpgrade;

    [Header("Easy")]
    public int magazineSizeIncreasingRateEasy = 5;
    public float reloadingTimeDecreasingRateEasy = 0.1f;
    public float fireRateIncreasingRateEasy = 2f;
    public float damageIncreasingRateEasy = 2.5f;
    public int criticalHitChanceIncreasingRateEasy = 25;
    public int tankSizeIncreasingRateEasy = 5;
    public float refillingTimeDecreasingRateEasy = 0.1f;
    public float fireRateWaterGunIncreasingRateEasy = 2f;
    public float waterFillIncreasingRateEasy = 2.5f;
    public int doubleFillChanceIncreasingRateEasy = 25;

    [Header("Medium")]
    public int magazineSizeIncreasingRateMedium = 5;
    public float reloadingTimeDecreasingRateMedium = 0.1f;
    public float fireRateIncreasingRateMedium = 2f;
    public float damageIncreasingRateMedium = 2.5f;
    public int criticalHitChanceIncreasingRateMedium = 25;
    public int tankSizeIncreasingRateMedium = 5;
    public float refillingTimeDecreasingRateMedium = 0.1f;
    public float fireRateWaterGunIncreasingRateMedium = 2f;
    public float waterFillIncreasingRateMedium = 2.5f;
    public int doubleFillChanceIncreasingRateMedium = 25;

    [Header("Hard")]
    public int magazineSizeIncreasingRateHard = 5;
    public float reloadingTimeDecreasingRateHard = 0.1f;
    public float fireRateIncreasingRateHard = 2f;
    public float damageIncreasingRateHard = 2.5f;
    public int criticalHitChanceIncreasingRateHard = 25;
    public int tankSizeIncreasingRateHard = 5;
    public float refillingTimeDecreasingRateHard = 0.1f;
    public float fireRateWaterGunIncreasingRateHard = 2f;
    public float waterFillIncreasingRateHard = 2.5f;
    public int doubleFillChanceIncreasingRateHard = 25;

    [Header("Easy")]

    [Header("WaterGun")]

    [Header("Player")]

    [Header("Multipliers")]
    public float pEasy = 0.12f;
    public float pMedium = 0.125f;
    public float pHard = 0.13f;

    [Header("Weapon")]
    public float wEasy = 0.1f;
    public float wMedium = 0.1f;
    public float wHard = 0.1f;

    [Header("Player")]

    [Header("MaxCost")]
    public float mCpEasy = 100f;
    public float mCpMedium = 100f;
    public float mCpHard = 100f;

    [Header("Weapon")]
    public float mCwEasy = 100f;
    public float mCwMedium = 100f;
    public float mCwHard = 100f;

    [System.NonSerialized]
    public Player player;
    [System.NonSerialized]
    public PlayerMovement pm;
    [System.NonSerialized]
    public Glock glock;
    [System.NonSerialized]
    public WaterGun waterGun;
    [System.NonSerialized]
    public GameManager gameManager;
    [System.NonSerialized]
    public int diff;

    int gameMode;

	public void Awake()
    {
        gameMode = SaveSystem.LoadDataGameMode().gameModeSave;

        player = GameObject.Find("Player").GetComponent<Player>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pm = player.GetComponent<PlayerMovement>();

        switch (gameMode)
        {
            case 0:

                waterGun = GameObject.Find("WaterGun").GetComponent<WaterGun>();

                playerUpgrade_GO.SetActive(false);
                weaponUpgrade_GO.SetActive(false);
                playerUpgradeWaterGun_GO.SetActive(true);
                weaponUpgradeWaterGun_GO.SetActive(true);


                break;
            case 1:

                glock = GameObject.Find("glock18").GetComponent<Glock>();

                playerUpgrade_GO.SetActive(true);
                weaponUpgrade_GO.SetActive(true);
                playerUpgradeWaterGun_GO.SetActive(false);
                weaponUpgradeWaterGun_GO.SetActive(false);

                break;
        }

        SaveDataDifficulty diffData = SaveSystem.LoadDataDifficultySave();
        diff = diffData.difficultySave;
    }

    void Update()
    {
        playerUpgrade.coins = gameManager.waveManager.coins;
        weaponUpgrade.coins = gameManager.waveManager.coins;
    }

    public void IncreaseMaxHealt()
    {
        if ((playerUpgrade.healthUpgradeCurrentCount < playerUpgrade.healthMaxUpgradeCount) && (gameManager.waveManager.coins >= playerUpgrade.healthCost))
        {

            gameManager.waveManager.coins -= playerUpgrade.healthCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    player.maxHealth += maxHealthIncreasingRateEasy;
                    player.hb.SetMaxHealth(Mathf.RoundToInt(player.maxHealth));
                    player.hb.SetText(Mathf.RoundToInt(player.currentHealth), Mathf.RoundToInt(player.maxHealth));

                    playerUpgrade.SetHealthCost(playerUpgrade.GetNextCost(playerUpgrade.healthCost, pEasy, mCpEasy));

                    break;
                case 1:

                    player.maxHealth += maxHealthIncreasingRateMedium;
                    player.hb.SetMaxHealth(Mathf.RoundToInt(player.maxHealth));
                    player.hb.SetText(Mathf.RoundToInt(player.currentHealth), Mathf.RoundToInt(player.maxHealth));

                    playerUpgrade.SetHealthCost(playerUpgrade.GetNextCost(playerUpgrade.healthCost, pMedium, mCpMedium));

                    break;
                case 2:

                    player.maxHealth += maxHealthIncreasingRateHard;
                    player.hb.SetMaxHealth(Mathf.RoundToInt(player.maxHealth));
                    player.hb.SetText(Mathf.RoundToInt(player.currentHealth), Mathf.RoundToInt(player.maxHealth));

                    playerUpgrade.SetHealthCost(playerUpgrade.GetNextCost(playerUpgrade.healthCost, pHard, mCpHard));

                    break;

            }

            playerUpgrade.healthUpgradeCurrentCount++;
            playerUpgrade.SetHealthCount(playerUpgrade.healthUpgradeCurrentCount, playerUpgrade.healthMaxUpgradeCount);

        }
    }

    public void IncreaseMaxDry()
    {
        if ((playerUpgrade.dryUpgradeCurrentCount < playerUpgrade.dryMaxUpgradeCount) && (gameManager.waveManager.coins >= playerUpgrade.dryCost))
        {

            gameManager.waveManager.coins -= playerUpgrade.dryCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    player.maxDry += maxDryIncreasingRateEasy;
                    player.hb.SetMaxCapacity(Mathf.RoundToInt(player.maxDry));
                    player.hb.SetText(Mathf.RoundToInt(player.currentDry), Mathf.RoundToInt(player.maxDry));

                    playerUpgrade.SetDryCost(playerUpgrade.GetNextCost(playerUpgrade.dryCost, pEasy, mCpEasy));

                    break;
                case 1:

                    player.maxDry += maxDryIncreasingRateMedium;
                    player.hb.SetMaxCapacity(Mathf.RoundToInt(player.maxDry));
                    player.hb.SetText(Mathf.RoundToInt(player.currentDry), Mathf.RoundToInt(player.maxDry));

                    playerUpgrade.SetDryCost(playerUpgrade.GetNextCost(playerUpgrade.dryCost, pMedium, mCpMedium));

                    break;
                case 2:

                    player.maxDry += maxDryIncreasingRateHard;
                    player.hb.SetMaxCapacity(Mathf.RoundToInt(player.maxDry));
                    player.hb.SetText(Mathf.RoundToInt(player.currentDry), Mathf.RoundToInt(player.maxDry));

                    playerUpgrade.SetDryCost(playerUpgrade.GetNextCost(playerUpgrade.dryCost, pHard, mCpHard));

                    break;

            }

            playerUpgrade.dryUpgradeCurrentCount++;
            playerUpgrade.SetDryCount(playerUpgrade.dryUpgradeCurrentCount, playerUpgrade.dryMaxUpgradeCount);

        }
    }

    public void IncreaseDryRegeneration()
    {
        if ((playerUpgrade.dryRegenerationUpgradeCurrentCount < playerUpgrade.dryRegenerationMaxUpgradeCount) && (gameManager.waveManager.coins >= playerUpgrade.dryRegenerationCost))
        {

            gameManager.waveManager.coins -= playerUpgrade.dryRegenerationCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    player.dryRegeneration += dryRegenerationIncreasingRateEasy;

                    playerUpgrade.SetDryRegenerationCost(playerUpgrade.GetNextCost(playerUpgrade.dryRegenerationCost, pEasy, mCpEasy));

                    break;
                case 1:

                    player.dryRegeneration += dryRegenerationIncreasingRateMedium;

                    playerUpgrade.SetDryRegenerationCost(playerUpgrade.GetNextCost(playerUpgrade.dryRegenerationCost, pMedium, mCpMedium));

                    break;
                case 2:

                    player.dryRegeneration += dryRegenerationIncreasingRateHard;

                    playerUpgrade.SetDryRegenerationCost(playerUpgrade.GetNextCost(playerUpgrade.dryRegenerationCost, pHard, mCpHard));

                    break;

            }

            playerUpgrade.dryRegenerationUpgradeCurrentCount++;
            playerUpgrade.SetDryRegenerationCount(playerUpgrade.dryRegenerationUpgradeCurrentCount, playerUpgrade.dryRegenerationMaxUpgradeCount);

        }
    }

    public void IncreaseHealthRegeneration()
    {
        if ((playerUpgrade.healthRegenerationUpgradeCurrentCount < playerUpgrade.healthRegenerationMaxUpgradeCount) && (gameManager.waveManager.coins >= playerUpgrade.healthRegenerationCost))
        {

            gameManager.waveManager.coins -= playerUpgrade.healthRegenerationCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    player.healthRegeneration += healthRegenerationIncreasingRateEasy;

                    playerUpgrade.SetHealthRegenerationCost(playerUpgrade.GetNextCost(playerUpgrade.healthRegenerationCost, pEasy, mCpEasy));

                    break;
                case 1:

                    player.healthRegeneration += healthRegenerationIncreasingRateMedium;

                    playerUpgrade.SetHealthRegenerationCost(playerUpgrade.GetNextCost(playerUpgrade.healthRegenerationCost, pMedium, mCpMedium));

                    break;
                case 2:

                    player.healthRegeneration += healthRegenerationIncreasingRateHard;

                    playerUpgrade.SetHealthRegenerationCost(playerUpgrade.GetNextCost(playerUpgrade.healthRegenerationCost, pHard, mCpHard));

                    break;

            }

            playerUpgrade.healthRegenerationUpgradeCurrentCount++;
            playerUpgrade.SetHealthRegenerationCount(playerUpgrade.healthRegenerationUpgradeCurrentCount, playerUpgrade.healthRegenerationMaxUpgradeCount);

        }
    }

    public void IncreaseArmor()
    {
        if ((playerUpgrade.armorUpgradeCurrentCount < playerUpgrade.armorMaxUpgradeCount) && (gameManager.waveManager.coins >= playerUpgrade.armorCost))
        {

            gameManager.waveManager.coins -= playerUpgrade.armorCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    player.maxArmor += maxArmorIncreasingRateEasy;
                    player.ab.SetMaxArmor(Mathf.RoundToInt(player.maxArmor));
                    player.ab.SetText(Mathf.RoundToInt(player.currentArmor), Mathf.RoundToInt(player.maxArmor));

                    playerUpgrade.SetArmorCost(playerUpgrade.GetNextCost(playerUpgrade.armorCost, pEasy, mCpEasy));

                    break;
                case 1:

                    player.maxArmor += maxArmorIncreasingRateMedium;
                    player.ab.SetMaxArmor(Mathf.RoundToInt(player.maxArmor));
                    player.ab.SetText(Mathf.RoundToInt(player.currentArmor), Mathf.RoundToInt(player.maxArmor));

                    playerUpgrade.SetArmorCost(playerUpgrade.GetNextCost(playerUpgrade.armorCost, pMedium, mCpMedium));

                    break;
                case 2:

                    player.maxArmor += maxArmorIncreasingRateHard;
                    player.ab.SetMaxArmor(Mathf.RoundToInt(player.maxArmor));
                    player.ab.SetText(Mathf.RoundToInt(player.currentArmor), Mathf.RoundToInt(player.maxArmor));

                    playerUpgrade.SetArmorCost(playerUpgrade.GetNextCost(playerUpgrade.armorCost, pHard, mCpHard));

                    break;

            }

            playerUpgrade.armorUpgradeCurrentCount++;
            playerUpgrade.SetArmorCount(playerUpgrade.armorUpgradeCurrentCount, playerUpgrade.armorMaxUpgradeCount);

        }
    }

    public void IncreaseTank()
    {
        if ((playerUpgrade.tankUpgradeCurrentCount < playerUpgrade.tankMaxUpgradeCount) && (gameManager.waveManager.coins >= playerUpgrade.tankCost))
        {

            gameManager.waveManager.coins -= playerUpgrade.tankCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    player.maxTank += maxTankIncreasingRateEasy;
                    player.tb.SetMaxTank(Mathf.RoundToInt(player.maxTank));
                    player.tb.SetText(Mathf.RoundToInt(player.currentTank), Mathf.RoundToInt(player.maxTank));

                    playerUpgrade.SetTankCost(playerUpgrade.GetNextCost(playerUpgrade.tankCost, pEasy, mCpEasy));

                    break;
                case 1:

                    player.maxTank += maxTankIncreasingRateMedium;
                    player.tb.SetMaxTank(Mathf.RoundToInt(player.maxTank));
                    player.tb.SetText(Mathf.RoundToInt(player.currentTank), Mathf.RoundToInt(player.maxTank));

                    playerUpgrade.SetTankCost(playerUpgrade.GetNextCost(playerUpgrade.tankCost, pMedium, mCpMedium));

                    break;
                case 2:

                    player.maxTank += maxTankIncreasingRateHard;
                    player.tb.SetMaxTank(Mathf.RoundToInt(player.maxArmor));
                    player.tb.SetText(Mathf.RoundToInt(player.currentTank), Mathf.RoundToInt(player.maxArmor));

                    playerUpgrade.SetTankCost(playerUpgrade.GetNextCost(playerUpgrade.tankCost, pHard, mCpHard));

                    break;

            }

            playerUpgrade.tankUpgradeCurrentCount++;
            playerUpgrade.SetTankCount(playerUpgrade.tankUpgradeCurrentCount, playerUpgrade.tankMaxUpgradeCount);

        }
    }

    public void IncreaseMovementSpeed()
    {
        if((playerUpgrade.movementSpeedUpgradeCurrentCount < playerUpgrade.movementSpeedMaxUpgradeCount) && (gameManager.waveManager.coins >= playerUpgrade.movementSpeedCost))
        {

            gameManager.waveManager.coins -= playerUpgrade.movementSpeedCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    pm.standard += movementSpeedIncreasingRateEasy / 2;
                    pm.sprint += movementSpeedIncreasingRateEasy;

                    playerUpgrade.SetMovementSpeedCost(playerUpgrade.GetNextCost(playerUpgrade.movementSpeedCost, pEasy, mCpEasy));

                    break;
                case 1:

                    pm.standard += movementSpeedIncreasingRateMedium / 2;
                    pm.sprint += movementSpeedIncreasingRateMedium;

                    playerUpgrade.SetMovementSpeedCost(playerUpgrade.GetNextCost(playerUpgrade.movementSpeedCost, pMedium, mCpMedium));

                    break;
                case 2:

                    pm.standard += movementSpeedIncreasingRateHard / 2;
                    pm.sprint += movementSpeedIncreasingRateHard;

                    playerUpgrade.SetMovementSpeedCost(playerUpgrade.GetNextCost(playerUpgrade.movementSpeedCost, pHard, mCpHard));

                    break;

            }

            playerUpgrade.movementSpeedUpgradeCurrentCount++;
            playerUpgrade.SetMovementSpeedCount(playerUpgrade.movementSpeedUpgradeCurrentCount, playerUpgrade.movementSpeedMaxUpgradeCount);

        }
    }

    public void IncreaseMovementSpeedWaterBomb()
    {
        if((playerUpgrade.movementSpeedWaterBombUpgradeCurrentCount < playerUpgrade.movementSpeedWaterBombMaxUpgradeCount) && (gameManager.waveManager.coins >= playerUpgrade.movementSpeedWaterBombCost))
        {

            gameManager.waveManager.coins -= playerUpgrade.movementSpeedWaterBombCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    pm.standard += movementSpeedWaterBombIncreasingRateEasy / 2;
                    pm.sprint += movementSpeedWaterBombIncreasingRateEasy;

                    playerUpgrade.SetMovementSpeedWaterBombCost(playerUpgrade.GetNextCost(playerUpgrade.movementSpeedWaterBombCost, pEasy, mCpEasy));

                    break;
                case 1:

                    pm.standard += movementSpeedWaterBombIncreasingRateMedium / 2;
                    pm.sprint += movementSpeedWaterBombIncreasingRateMedium;

                    playerUpgrade.SetMovementSpeedWaterBombCost(playerUpgrade.GetNextCost(playerUpgrade.movementSpeedWaterBombCost, pMedium, mCpMedium));

                    break;
                case 2:

                    pm.standard += movementSpeedWaterBombIncreasingRateHard / 2;
                    pm.sprint += movementSpeedWaterBombIncreasingRateHard;

                    playerUpgrade.SetMovementSpeedWaterBombCost(playerUpgrade.GetNextCost(playerUpgrade.movementSpeedWaterBombCost, pHard, mCpHard));

                    break;

            }

            playerUpgrade.movementSpeedWaterBombUpgradeCurrentCount++;
            playerUpgrade.SetMovementSpeedWaterBombCount(playerUpgrade.movementSpeedWaterBombUpgradeCurrentCount, playerUpgrade.movementSpeedWaterBombMaxUpgradeCount);

        }
    }

    public void IncreaseEndurance()
    {
        if((playerUpgrade.enduranceUpgradeCurrentCount < playerUpgrade.enduranceMaxUpgradeCount) && (gameManager.waveManager.coins >= playerUpgrade.enduranceCost))
        {

            gameManager.waveManager.coins -= playerUpgrade.enduranceCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    pm.SetMaxEndurance(pm.maxEndurance += endruanceIncreasingRateEasy);

                    playerUpgrade.SetEnduranceCost(playerUpgrade.GetNextCost(playerUpgrade.enduranceCost, pEasy, mCpEasy));

                    break;
                case 1:

                    pm.SetMaxEndurance(pm.maxEndurance += endruanceIncreasingRateMedium);

                    playerUpgrade.SetEnduranceCost(playerUpgrade.GetNextCost(playerUpgrade.enduranceCost, pMedium, mCpMedium));

                    break;
                case 2:

                    pm.SetMaxEndurance(pm.maxEndurance += endruanceIncreasingRateHard);

                    playerUpgrade.SetEnduranceCost(playerUpgrade.GetNextCost(playerUpgrade.enduranceCost, pHard, mCpHard));

                    break;

            }

            playerUpgrade.enduranceUpgradeCurrentCount++;
            playerUpgrade.SetEnduranceCount(playerUpgrade.enduranceUpgradeCurrentCount, playerUpgrade.enduranceMaxUpgradeCount);

        }
    }

    public void IncreaseEnduranceWaterBomb()
    {
        if((playerUpgrade.enduranceWaterBombUpgradeCurrentCount < playerUpgrade.enduranceWaterBombMaxUpgradeCount) && (gameManager.waveManager.coins >= playerUpgrade.enduranceWaterBombCost))
        {

            gameManager.waveManager.coins -= playerUpgrade.enduranceWaterBombCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    pm.SetMaxEndurance(pm.maxEndurance += endruanceWaterBombIncreasingRateEasy);

                    playerUpgrade.SetEnduranceWaterBombCost(playerUpgrade.GetNextCost(playerUpgrade.enduranceWaterBombCost, pEasy, mCpEasy));

                    break;
                case 1:

                    pm.SetMaxEndurance(pm.maxEndurance += endruanceWaterBombIncreasingRateMedium);

                    playerUpgrade.SetEnduranceWaterBombCost(playerUpgrade.GetNextCost(playerUpgrade.enduranceWaterBombCost, pMedium, mCpMedium));

                    break;
                case 2:

                    pm.SetMaxEndurance(pm.maxEndurance += endruanceWaterBombIncreasingRateHard);

                    playerUpgrade.SetEnduranceWaterBombCost(playerUpgrade.GetNextCost(playerUpgrade.enduranceWaterBombCost, pHard, mCpHard));

                    break;

            }

            playerUpgrade.enduranceWaterBombUpgradeCurrentCount++;
            playerUpgrade.SetEnduranceWaterBombCount(playerUpgrade.enduranceWaterBombUpgradeCurrentCount, playerUpgrade.enduranceWaterBombMaxUpgradeCount);

        }
    }
    
    public void IncreaseEnduranceRegeneration()
    {
        if((playerUpgrade.enduranceRegenerationUpgradeCurrentCount < playerUpgrade.enduranceRegenerationMaxUpgradeCount) && (gameManager.waveManager.coins >= playerUpgrade.enduranceRegenerationCost))
        {

            gameManager.waveManager.coins -= playerUpgrade.enduranceRegenerationCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    pm.enduranceRegeneration += enduranceRegenerationIncreasingRateEasy;

                    playerUpgrade.SetEnduranceRegenerationCost(playerUpgrade.GetNextCost(playerUpgrade.enduranceRegenerationCost, pEasy, mCpEasy));

                    break;
                case 1:

                    pm.enduranceRegeneration += enduranceRegenerationIncreasingRateMedium;

                    playerUpgrade.SetEnduranceRegenerationCost(playerUpgrade.GetNextCost(playerUpgrade.enduranceRegenerationCost, pMedium, mCpMedium));

                    break;
                case 2:

                    pm.enduranceRegeneration += enduranceRegenerationIncreasingRateHard;

                    playerUpgrade.SetEnduranceRegenerationCost(playerUpgrade.GetNextCost(playerUpgrade.enduranceRegenerationCost, pHard, mCpHard));

                    break;

            }

            playerUpgrade.enduranceRegenerationUpgradeCurrentCount++;
            playerUpgrade.SetEnduranceRegenerationCount(playerUpgrade.enduranceRegenerationUpgradeCurrentCount, playerUpgrade.enduranceRegenerationMaxUpgradeCount);

        }
    }

    public void IncreaseEnduranceRegenerationWaterBomb()
    {
        if((playerUpgrade.enduranceRegenerationWaterBombUpgradeCurrentCount < playerUpgrade.enduranceRegenerationWaterBombMaxUpgradeCount) && (gameManager.waveManager.coins >= playerUpgrade.enduranceRegenerationWaterBombCost))
        {

            gameManager.waveManager.coins -= playerUpgrade.enduranceRegenerationWaterBombCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    pm.enduranceRegeneration += enduranceRegenerationWaterBombIncreasingRateEasy;

                    playerUpgrade.SetEnduranceRegenerationWaterBombCost(playerUpgrade.GetNextCost(playerUpgrade.enduranceRegenerationWaterBombCost, pEasy, mCpEasy));

                    break;
                case 1:

                    pm.enduranceRegeneration += enduranceRegenerationWaterBombIncreasingRateMedium;

                    playerUpgrade.SetEnduranceRegenerationWaterBombCost(playerUpgrade.GetNextCost(playerUpgrade.enduranceRegenerationWaterBombCost, pMedium, mCpMedium));

                    break;
                case 2:

                    pm.enduranceRegeneration += enduranceRegenerationWaterBombIncreasingRateHard;

                    playerUpgrade.SetEnduranceRegenerationWaterBombCost(playerUpgrade.GetNextCost(playerUpgrade.enduranceRegenerationWaterBombCost, pHard, mCpHard));

                    break;

            }

            playerUpgrade.enduranceRegenerationWaterBombUpgradeCurrentCount++;
            playerUpgrade.SetEnduranceRegenerationWaterBombCount(playerUpgrade.enduranceRegenerationWaterBombUpgradeCurrentCount, playerUpgrade.enduranceRegenerationWaterBombMaxUpgradeCount);

        }
    }

    public void IncreaseMagazineSize()
    {
        if ((weaponUpgrade.magazineSizeUpgradeCurrentCount < weaponUpgrade.magazineSizeUpgradeMaxCount) && (gameManager.waveManager.coins >= weaponUpgrade.magazineSizeCost))
        {

            gameManager.waveManager.coins -= weaponUpgrade.magazineSizeCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    glock.maxAmmo += magazineSizeIncreasingRateEasy;

                    weaponUpgrade.SetMagazineSizeCost(weaponUpgrade.GetNextCost(weaponUpgrade.magazineSizeCost, wEasy, mCwEasy));

                    break;
                case 1:

                    glock.maxAmmo += magazineSizeIncreasingRateMedium;

                    weaponUpgrade.SetMagazineSizeCost(weaponUpgrade.GetNextCost(weaponUpgrade.magazineSizeCost, wMedium, mCwMedium));

                    break;
                case 2:

                    glock.maxAmmo += magazineSizeIncreasingRateHard;

                    weaponUpgrade.SetMagazineSizeCost(weaponUpgrade.GetNextCost(weaponUpgrade.magazineSizeCost, wHard, mCwHard));

                    break;

            }

            weaponUpgrade.magazineSizeUpgradeCurrentCount++;
            weaponUpgrade.SetMagazineSizeCount(weaponUpgrade.magazineSizeUpgradeCurrentCount, weaponUpgrade.magazineSizeUpgradeMaxCount);

        }
    }

    public void DecreaseReloadingTime()
    {
        if ((weaponUpgrade.reloadingTimeUpgradeCurrentCount < weaponUpgrade.reloadingTimeUpgradeMaxCount) && (gameManager.waveManager.coins >= weaponUpgrade.reloadingTimeCost))
        {

            gameManager.waveManager.coins -= weaponUpgrade.reloadingTimeCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    glock.reloadingTime -= reloadingTimeDecreasingRateEasy;

                    weaponUpgrade.SetReloadingTimeCost(weaponUpgrade.GetNextCost(weaponUpgrade.reloadingTimeCost, wEasy, mCwEasy));

                    break;
                case 1:

                    glock.reloadingTime -= reloadingTimeDecreasingRateMedium;

                    weaponUpgrade.SetReloadingTimeCost(weaponUpgrade.GetNextCost(weaponUpgrade.reloadingTimeCost, wMedium, mCwMedium));

                    break;
                case 2:

                    glock.reloadingTime -= reloadingTimeDecreasingRateHard;

                    weaponUpgrade.SetReloadingTimeCost(weaponUpgrade.GetNextCost(weaponUpgrade.reloadingTimeCost, wHard, mCwHard));

                    break;

            }

            weaponUpgrade.reloadingTimeUpgradeCurrentCount++;
            weaponUpgrade.SetReloadingTimeCount(weaponUpgrade.reloadingTimeUpgradeCurrentCount, weaponUpgrade.reloadingTimeUpgradeMaxCount);

        }
    }

    public void IncreaseFireRate()
    {
        if ((weaponUpgrade.fireRateUpgradeCurrentCount < weaponUpgrade.fireRateUpgradeMaxCount) && (gameManager.waveManager.coins >= weaponUpgrade.fireRateCost))
        {

            gameManager.waveManager.coins -= weaponUpgrade.fireRateCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    glock.fireRate += fireRateIncreasingRateEasy;

                    weaponUpgrade.SetFireRateCost(weaponUpgrade.GetNextCost(weaponUpgrade.fireRateCost, wEasy, mCwEasy));

                    break;
                case 1:

                    glock.fireRate += fireRateIncreasingRateMedium;

                    weaponUpgrade.SetFireRateCost(weaponUpgrade.GetNextCost(weaponUpgrade.fireRateCost, wMedium, mCwMedium));

                    break;
                case 2:

                    glock.fireRate += fireRateIncreasingRateHard;

                    weaponUpgrade.SetFireRateCost(weaponUpgrade.GetNextCost(weaponUpgrade.fireRateCost, wHard, mCwHard));

                    break;

            }

            weaponUpgrade.fireRateUpgradeCurrentCount++;
            weaponUpgrade.SetFireRateCount(weaponUpgrade.fireRateUpgradeCurrentCount, weaponUpgrade.fireRateUpgradeMaxCount);

        }
    }

    public void IncreaseDamage()
    {
        if ((weaponUpgrade.damageUpgradeCurrentCount < weaponUpgrade.damageUpgradeMaxCount) && (gameManager.waveManager.coins >= weaponUpgrade.damageCost))
        {

            gameManager.waveManager.coins -= weaponUpgrade.damageCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    glock.damage += damageIncreasingRateEasy;

                    weaponUpgrade.SetDamageCost(weaponUpgrade.GetNextCost(weaponUpgrade.damageCost, wEasy, mCwEasy));

                    break;
                case 1:

                    glock.damage += damageIncreasingRateMedium;

                    weaponUpgrade.SetDamageCost(weaponUpgrade.GetNextCost(weaponUpgrade.damageCost, wMedium, mCwMedium));

                    break;
                case 2:

                    glock.damage += damageIncreasingRateHard;

                    weaponUpgrade.SetDamageCost(weaponUpgrade.GetNextCost(weaponUpgrade.damageCost, wHard, mCwHard));

                    break;

            }

            weaponUpgrade.damageUpgradeCurrentCount++;
            weaponUpgrade.SetDamageCount(weaponUpgrade.damageUpgradeCurrentCount, weaponUpgrade.damageUpgradeMaxCount);

        }
    }

    public void IncreaseCriticalHitChance()
    {
        if ((weaponUpgrade.criticalHitChanceUpgradeCurrentCount < weaponUpgrade.criticalHitChanceUpgradeMaxCount) && (gameManager.waveManager.coins >= weaponUpgrade.criticalHitChanceCost))
        {
            glock.critchance += criticalHitChanceIncreasingRateEasy;

            gameManager.waveManager.coins -= weaponUpgrade.criticalHitChanceCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    weaponUpgrade.SetCriticalHitChanceCost(weaponUpgrade.GetNextCost(weaponUpgrade.criticalHitChanceCost, wEasy, mCwEasy));

                    break;
                case 1:

                    weaponUpgrade.SetCriticalHitChanceCost(weaponUpgrade.GetNextCost(weaponUpgrade.criticalHitChanceCost, wMedium, mCwMedium));

                    break;
                case 2:

                    weaponUpgrade.SetCriticalHitChanceCost(weaponUpgrade.GetNextCost(weaponUpgrade.criticalHitChanceCost, wHard, mCwHard));

                    break;

            }

            weaponUpgrade.criticalHitChanceUpgradeCurrentCount++;
            weaponUpgrade.SetCriticalHitChanceCount(weaponUpgrade.criticalHitChanceUpgradeCurrentCount, weaponUpgrade.criticalHitChanceUpgradeMaxCount);

        }
    }

    public void IncreaseTankSize()
    {
        if ((weaponUpgrade.tankSizeUpgradeCurrentCount < weaponUpgrade.tankSizeUpgradeMaxCount) && (gameManager.waveManager.coins >= weaponUpgrade.tankSizeCost))
        {

            gameManager.waveManager.coins -= weaponUpgrade.tankSizeCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    waterGun.maxTank += tankSizeIncreasingRateEasy;

                    weaponUpgrade.SetTankSizeCost(weaponUpgrade.GetNextCost(weaponUpgrade.tankSizeCost, wEasy, mCwEasy));

                    break;
                case 1:

                    waterGun.maxTank += tankSizeIncreasingRateMedium;

                    weaponUpgrade.SetTankSizeCost(weaponUpgrade.GetNextCost(weaponUpgrade.tankSizeCost, wMedium, mCwMedium));

                    break;
                case 2:

                    waterGun.maxTank += tankSizeIncreasingRateHard;

                    weaponUpgrade.SetTankSizeCost(weaponUpgrade.GetNextCost(weaponUpgrade.tankSizeCost, wHard, mCwHard));

                    break;

            }

            weaponUpgrade.tankSizeUpgradeCurrentCount++;
            weaponUpgrade.SetTankSizeCount(weaponUpgrade.tankSizeUpgradeCurrentCount, weaponUpgrade.tankSizeUpgradeMaxCount);

        }
    }

    public void DecreaseRefillingTime()
    {
        if ((weaponUpgrade.refillingTimeUpgradeCurrentCount < weaponUpgrade.refillingTimeUpgradeMaxCount) && (gameManager.waveManager.coins >= weaponUpgrade.refillingTimeCost))
        {

            gameManager.waveManager.coins -= weaponUpgrade.refillingTimeCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    waterGun.refillingTime -= refillingTimeDecreasingRateEasy;

                    weaponUpgrade.SetRefillingTimeCost(weaponUpgrade.GetNextCost(weaponUpgrade.refillingTimeCost, wEasy, mCwEasy));

                    break;
                case 1:

                    waterGun.refillingTime -= refillingTimeDecreasingRateMedium;

                    weaponUpgrade.SetRefillingTimeCost(weaponUpgrade.GetNextCost(weaponUpgrade.refillingTimeCost, wMedium, mCwMedium));

                    break;
                case 2:

                    waterGun.refillingTime -= refillingTimeDecreasingRateHard;

                    weaponUpgrade.SetRefillingTimeCost(weaponUpgrade.GetNextCost(weaponUpgrade.refillingTimeCost, wHard, mCwHard));

                    break;

            }

            weaponUpgrade.refillingTimeUpgradeCurrentCount++;
            weaponUpgrade.SetRefillingTimeCount(weaponUpgrade.refillingTimeUpgradeCurrentCount, weaponUpgrade.refillingTimeUpgradeMaxCount);

        }
    }

    public void IncreaseFireRateWaterGun()
    {
        if ((weaponUpgrade.fireRateWaterGunUpgradeCurrentCount < weaponUpgrade.fireRateWaterGunUpgradeMaxCount) && (gameManager.waveManager.coins >= weaponUpgrade.fireRateCostWaterGun))
        {

            gameManager.waveManager.coins -= weaponUpgrade.fireRateCostWaterGun;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    waterGun.fireRate += fireRateWaterGunIncreasingRateEasy;

                    weaponUpgrade.SetFireRateWaterGunCost(weaponUpgrade.GetNextCost(weaponUpgrade.fireRateCostWaterGun, wEasy, mCwEasy));

                    break;
                case 1:

                    waterGun.fireRate += fireRateWaterGunIncreasingRateMedium;

                    weaponUpgrade.SetFireRateWaterGunCost(weaponUpgrade.GetNextCost(weaponUpgrade.fireRateCostWaterGun, wMedium, mCwMedium));

                    break;
                case 2:

                    waterGun.fireRate += fireRateWaterGunIncreasingRateHard;

                    weaponUpgrade.SetFireRateWaterGunCost(weaponUpgrade.GetNextCost(weaponUpgrade.fireRateCostWaterGun, wHard, mCwHard));

                    break;

            }

            weaponUpgrade.fireRateWaterGunUpgradeCurrentCount++;
            weaponUpgrade.SetFireRateWaterGunCount(weaponUpgrade.fireRateWaterGunUpgradeCurrentCount, weaponUpgrade.fireRateWaterGunUpgradeMaxCount);

        }
    }

    public void IncreaseWaterFill()
    {
        if ((weaponUpgrade.waterFillUpgradeCurrentCount < weaponUpgrade.waterFillUpgradeMaxCount) && (gameManager.waveManager.coins >= weaponUpgrade.waterFillCost))
        {

            gameManager.waveManager.coins -= weaponUpgrade.waterFillCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    waterGun.waterFill += waterFillIncreasingRateEasy;

                    weaponUpgrade.SetWaterFillCost(weaponUpgrade.GetNextCost(weaponUpgrade.waterFillCost, wEasy, mCwEasy));

                    break;
                case 1:

                    waterGun.waterFill += waterFillIncreasingRateMedium;

                    weaponUpgrade.SetWaterFillCost(weaponUpgrade.GetNextCost(weaponUpgrade.waterFillCost, wMedium, mCwMedium));

                    break;
                case 2:

                    waterGun.waterFill += waterFillIncreasingRateHard;

                    weaponUpgrade.SetWaterFillCost(weaponUpgrade.GetNextCost(weaponUpgrade.waterFillCost, wHard, mCwHard));

                    break;

            }

            weaponUpgrade.waterFillUpgradeCurrentCount++;
            weaponUpgrade.SetWaterFillCount(weaponUpgrade.waterFillUpgradeCurrentCount, weaponUpgrade.waterFillUpgradeMaxCount);

        }
    }

    public void IncreaseDoubleFillChance()
    {
        if ((weaponUpgrade.doubleFillChanceUpgradeCurrentCount < weaponUpgrade.doubleFillChanceUpgradeMaxCount) && (gameManager.waveManager.coins >= weaponUpgrade.doubleFillChanceCost))
        {
            waterGun.doubleFillChance += doubleFillChanceIncreasingRateEasy;

            gameManager.waveManager.coins -= weaponUpgrade.doubleFillChanceCost;
            gameManager.waveManager.UpdateCoins();

            switch (diff)
            {
                case 0:

                    weaponUpgrade.SetDoubleFillChanceCost(weaponUpgrade.GetNextCost(weaponUpgrade.doubleFillChanceCost, wEasy, mCwEasy));

                    break;
                case 1:

                    weaponUpgrade.SetDoubleFillChanceCost(weaponUpgrade.GetNextCost(weaponUpgrade.doubleFillChanceCost, wMedium, mCwMedium));

                    break;
                case 2:

                    weaponUpgrade.SetDoubleFillChanceCost(weaponUpgrade.GetNextCost(weaponUpgrade.doubleFillChanceCost, wHard, mCwHard));

                    break;

            }

            weaponUpgrade.doubleFillChanceUpgradeCurrentCount++;
            weaponUpgrade.SetDoubleFillChanceCount(weaponUpgrade.doubleFillChanceUpgradeCurrentCount, weaponUpgrade.doubleFillChanceUpgradeMaxCount);

        }
    }

    public void ActivateSilencer()
    {
        if ((weaponUpgrade.silencerUpgradeCurrentCount < weaponUpgrade.silencerUpgradeMaxCount) && (gameManager.waveManager.coins >= weaponUpgrade.silencerCost))
        {
            glock.hasSilencer = true;

            weaponUpgrade.silencerUpgradeCurrentCount++;
            weaponUpgrade.SetSilencerCount(weaponUpgrade.silencerUpgradeCurrentCount, weaponUpgrade.silencerUpgradeMaxCount);

            gameManager.waveManager.coins -= weaponUpgrade.silencerCost;
            gameManager.waveManager.UpdateCoins();
        }
    }
}
