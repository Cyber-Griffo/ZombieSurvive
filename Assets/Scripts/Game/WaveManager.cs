using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour {

    public ZombieManager zombieManager;
    public WaterBombManager waterBombManager;
    public GameManager gameManager;
    public TMP_Text waveCountText;
    public TMP_Text scoreText;
    public TMP_Text coinsText;

    [Header("Update Difficulty")]

    [Header("Zombies")]
    public int waveCountToUpgradeZombiesEasy = 6;
    public int increasedZombieSpeedEasy = 2;
    public int increasedZombieDamageEasy = 2;
    public int increasedZombieSpawnPointsEasy = 1;

    public int waveCountToUpgradeZombiesMedium = 4;
    public int increasedZombieSpeedMedium = 2;
    public int increasedZombieDamageMedium = 2;
    public int increasedZombieSpawnPointsMedium = 1;

    public int waveCountToUpgradeZombiesHard = 2;
    public int increasedZombieSpeedHard = 2;
    public int increasedZombieDamageHard = 2;
    public int increasedZombieSpawnPointsHard = 1;

    [Header("Difficulty Per Wave")]
    public int increasedZombieHealthEasy = 2;

    public int increasedZombieHealthMedium = 5;

    public int increasedZombieHealthHard = 10;

    [Header("Points")]
    public int pointsPerZombieEasy = 5;
    
    public int pointsPerZombieMedium = 3;
    
    public int pointsPerZombieHard = 2;
    
    [Header("Coins")]
    public int coinsPerZombieEasy = 5;
    
    public int coinsPerZombieMedium = 3;
    
    public int coinsPerZombieHard = 2;
    

    [Header("Update Difficulty")]

    [Header("Water Bombs")]
    public int waveCountToUpgradeWaterBombsEasy = 6;
    public int increasedWaterBombSpeedEasy = 2;
    public int increasedWaterBombDamageEasy = 2;
    public int increasedWaterBombSpawnPointsEasy = 1;

    public int waveCountToUpgradeWaterBombsMedium = 4;
    public int increasedWaterBombSpeedMedium = 2;
    public int increasedWaterBombDamageMedium = 2;
    public int increasedWaterBombSpawnPointsMedium = 1;

    public int waveCountToUpgradeWaterBombsHard = 2;
    public int increasedWaterBombSpeedHard = 2;
    public int increasedWaterBombDamageHard = 2;
    public int increasedWaterBombSpawnPointsHard = 1;

    [Header("Difficulty Per Wave")]
    public int increasedWaterBombCapacityEasy = 2;

    public int increasedWaterBombCapacityMedium = 5;

    public int increasedWaterBombCapacityHard = 10;

    [Header("Points")]
    public int pointsPerWaterBombEasy = 5;

    public int pointsPerWaterBombMedium = 3;

    public int pointsPerWaterBombHard = 2;

    [Header("Coins")]
    public int coinsPerWaterBombEasy = 5;

    public int coinsPerWaterBombMedium = 3;

    public int coinsPerWaterBombHard = 2;

    [Header("Coins")]

    [Header("Global")]
    public int coinsPerWaveEasy = 10;
    public int coinsPerWaveMedium = 8;
    public int coinsPerWaveHard = 6;

    [Header("Points")]
    public int pointsPerWaveEasy = 10;
    public int pointsPerWaveMedium = 8;
    public int pointsPerWaveHard = 6;

    [System.NonSerialized]
    public int waveCount = 1;
    [System.NonSerialized]
    public bool isCurrentlyLoadingNextWave = false;
    [System.NonSerialized]
    public int score = 0;
    [System.NonSerialized]
    public int coins = 0;
    [System.NonSerialized]
    public Player player;

    public void LoadNextWaveZombies(int diff)
    {
        isCurrentlyLoadingNextWave = true;
        player = gameManager.player.GetComponent<Player>();

        //Increase WaveCount
        if (gameManager.sceneHasInitialized)
        {
            waveCount++;
        }

        switch (diff)
        {
            case 0:

                if (waveCount % waveCountToUpgradeZombiesEasy == 0)
                {
                    zombieManager.zombieSpawnPunkteAnzahl = zombieManager.zombieSpawnPunkteAnzahl + increasedZombieSpawnPointsEasy;

                    if (zombieManager.zombieSpawnPunkteAnzahl >= gameManager.modulesSpawned.Count)
                    {
                        zombieManager.zombieSpawnPunkteAnzahl = gameManager.modulesSpawned.Count;
                    }
                }

                //Updating Score
                if (waveCount != 1)
                {
                    IncreaseScore(pointsPerWaveEasy);
                    IncreaseCoins(coinsPerWaveEasy);
                }
                
                break;

            case 1:

                if (waveCount % waveCountToUpgradeZombiesMedium == 0)
                {
                    zombieManager.zombieSpawnPunkteAnzahl = zombieManager.zombieSpawnPunkteAnzahl + increasedZombieSpawnPointsMedium;

                    if (zombieManager.zombieSpawnPunkteAnzahl >= gameManager.modulesSpawned.Count)
                    {
                        zombieManager.zombieSpawnPunkteAnzahl = gameManager.modulesSpawned.Count;
                    }
                }

                //Updating Score
                if (waveCount != 1)
                {
                    IncreaseScore(pointsPerWaveMedium);
                    IncreaseCoins(coinsPerWaveMedium);
                }

                break;

            case 2:

                if (waveCount % waveCountToUpgradeZombiesHard == 0)
                {
                    zombieManager.zombieSpawnPunkteAnzahl = zombieManager.zombieSpawnPunkteAnzahl + increasedZombieSpawnPointsHard;

                    if (zombieManager.zombieSpawnPunkteAnzahl >= gameManager.modulesSpawned.Count)
                    {
                        zombieManager.zombieSpawnPunkteAnzahl = gameManager.modulesSpawned.Count;
                    }
                }

                //Updating Score
                if (waveCount != 1)
                {
                    IncreaseScore(pointsPerWaveHard);
                    IncreaseCoins(coinsPerWaveHard);
                }

                break;
        }

        //Initializing New Wave
        gameManager.UpdateZombieSpawnPoints(zombieManager.zombieSpawnPunkteAnzahl);
        StopCoroutine(gameManager.SpawnZombies(0));
        StartCoroutine(gameManager.SpawnZombies(zombieManager.zombieAnzahl));

        //IncreasingPlayerHealth
        if (gameManager.sceneHasInitialized)
        {
            player.Heal(player.healthRegeneration);
        }

        UpdateCoins();
        UpdateScore();
        UpdateWaveCount();

        isCurrentlyLoadingNextWave = false;
    }

    public void LoadNextWaveWaterBombs(int diff)
    {
        isCurrentlyLoadingNextWave = true;
        player = gameManager.player.GetComponent<Player>();

        print("loading new Wave");

        //Increase WaveCount
        if (gameManager.sceneHasInitialized)
        {
            waveCount++;
        }

        switch (diff)
        {
            case 0:

                if (waveCount % waveCountToUpgradeWaterBombsEasy == 0)
                {
                    waterBombManager.waterBombSpawnPunkteAnzahl = waterBombManager.waterBombSpawnPunkteAnzahl + increasedWaterBombSpawnPointsEasy;

                    if (waterBombManager.waterBombSpawnPunkteAnzahl >= gameManager.modulesSpawned.Count)
                    {
                        waterBombManager.waterBombSpawnPunkteAnzahl = gameManager.modulesSpawned.Count;
                    }
                }

                //Updating Score
                if (waveCount != 1)
                {
                    IncreaseScore(pointsPerWaveEasy);
                    IncreaseCoins(coinsPerWaveEasy);
                }
                
                break;

            case 1:

                if (waveCount % waveCountToUpgradeWaterBombsMedium == 0)
                {
                    waterBombManager.waterBombSpawnPunkteAnzahl = waterBombManager.waterBombSpawnPunkteAnzahl + increasedWaterBombSpawnPointsMedium;

                    if (waterBombManager.waterBombSpawnPunkteAnzahl >= gameManager.modulesSpawned.Count)
                    {
                        waterBombManager.waterBombSpawnPunkteAnzahl = gameManager.modulesSpawned.Count;
                    }
                }

                //Updating Score
                if (waveCount != 1)
                {
                    IncreaseScore(pointsPerWaveMedium);
                    IncreaseCoins(coinsPerWaveMedium);
                }

                break;

            case 2:

                if (waveCount % waveCountToUpgradeWaterBombsHard == 0)
                {
                    waterBombManager.waterBombSpawnPunkteAnzahl = waterBombManager.waterBombSpawnPunkteAnzahl + increasedWaterBombSpawnPointsHard;

                    if (waterBombManager.waterBombSpawnPunkteAnzahl >= gameManager.modulesSpawned.Count)
                    {
                        waterBombManager.waterBombSpawnPunkteAnzahl = gameManager.modulesSpawned.Count;
                    }
                }

                //Updating Score
                if (waveCount != 1)
                {
                    IncreaseScore(pointsPerWaveHard);
                    IncreaseCoins(coinsPerWaveHard);
                }

                break;
        }

        //Initializing New Wave
        gameManager.UpdateWaterBombSpawnPoints(waterBombManager.waterBombSpawnPunkteAnzahl);
        StopCoroutine(gameManager.SpawnWaterBombs(0));
        StartCoroutine(gameManager.SpawnWaterBombs(waterBombManager.waterBombAnzahl));

        //IncreasingPlayerHealth
        if (gameManager.sceneHasInitialized)
        {
            player.LooseWater(player.dryRegeneration);
        }

        UpdateCoins();
        UpdateScore();
        UpdateWaveCount();

        print("loading new Wave done");

        isCurrentlyLoadingNextWave = false;
    }

    public void UpdateWaveCount()
    {
        waveCountText.text = waveCount + "";
    }

    public void UpdateCoins()
    {
        coinsText.text = coins + "";
    }

    public void UpdateScore()
    {
        scoreText.text = score + "";
    }

    public void IncreaseScore(int value)
    {
        score += value;
    }

    public void IncreaseCoins(int value)
    {
        coins += value;
    }

    public void DecreaseCoins(int value)
    {
        coins -= value;
    }
}
