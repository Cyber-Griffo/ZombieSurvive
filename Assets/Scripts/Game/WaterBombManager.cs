using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBombManager : MonoBehaviour
{

    public int waterBombAnzahl = 3;
    public int waterBombSpawnPunkteAnzahl = 3;
    public float zeitZwischenWaterBombSpawns = 10f;
    public float startFollowingRadius = 50f;

    public WaterBomb waterBombScript;
    public GameObject waterBombGo;

    [System.NonSerialized]
    public List<GameObject> waterBombs = new List<GameObject>();
    [System.NonSerialized]
    public WaveManager wm;
    [System.NonSerialized]
    public int extraCapacity = 0;
    [System.NonSerialized]
    public int extraSpeedEasy;
    [System.NonSerialized]
    public int extraWaterDamageEasy;
    [System.NonSerialized]
    public int CapacityPerWaveEasy;

    [System.NonSerialized]
    public int extraSpeedMedium;
    [System.NonSerialized]
    public int extraWaterDamageMedium;
    [System.NonSerialized]
    public int CapacityPerWaveMedium;

    [System.NonSerialized]
    public int extraSpeedHard;
    [System.NonSerialized]
    public int extraWaterDamageHard;
    [System.NonSerialized]
    public int CapacityPerWaveHard;

    private int waterBombCount = 0;

    private void Awake()
    {
        wm = GetComponent<WaveManager>();

        extraWaterDamageEasy = wm.increasedWaterBombDamageEasy;
        extraSpeedEasy = wm.increasedWaterBombSpeedEasy;

        extraWaterDamageMedium = wm.increasedWaterBombDamageMedium;
        extraSpeedMedium = wm.increasedWaterBombSpeedMedium;

        extraWaterDamageHard = wm.increasedWaterBombDamageHard;
        extraSpeedHard = wm.increasedWaterBombSpeedHard;
    }

    public void SpawnWaterBomb(GameObject spawnPoint, Vector3 offset, Quaternion rotation, int diff, bool upgradeWave)
    {
        wm = GetComponent<WaveManager>();

        //Instantiate WaterBomb GameObject
        GameObject waterBomb = Instantiate(waterBombGo, spawnPoint.transform.position + offset, rotation);
        waterBomb.GetComponent<WaterBombAudioManager>().Play("Spawn");
        if (waterBomb != null)
        {
            switch (diff)
            {
                case 0:

                    //Setting WaterBomb Values
                    extraCapacity = wm.increasedWaterBombCapacityEasy * (wm.waveCount - 1);

                    if (upgradeWave)
                    {
                        waterBomb.GetComponent<WaterBomb>().speed += extraSpeedEasy;
                        waterBomb.GetComponent<WaterBomb>().waterDamage += extraWaterDamageEasy;
                    }

                    break;
                case 1:

                    //Setting WaterBomb Values
                    extraCapacity = wm.increasedWaterBombCapacityMedium * (wm.waveCount - 1);

                    if (upgradeWave)
                    {
                        waterBomb.GetComponent<WaterBomb>().speed += extraSpeedMedium;
                        waterBomb.GetComponent<WaterBomb>().waterDamage += extraWaterDamageMedium;
                    }

                    break;
                case 2:

                    //Setting WaterBomb Values
                    extraCapacity = wm.increasedWaterBombCapacityHard * (wm.waveCount - 1);

                    if (upgradeWave)
                    {
                        waterBomb.GetComponent<WaterBomb>().speed += extraSpeedHard;
                        waterBomb.GetComponent<WaterBomb>().waterDamage += extraWaterDamageHard;
                    }

                    break;
            }

            waterBomb.GetComponent<WaterBomb>().maxCapacity += extraCapacity;
            waterBomb.GetComponent<Target>().currentCapacity = 0;

            waterBomb.GetComponent<WaterBomb>().SetUpValues();

            //Adding WaterBomb to list
            waterBombs.Add(waterBomb);
            waterBombCount++;
        }
    }

    public bool IsAnyOneFollowingPlayer()
    {
        bool isAnyOneFollowing = false;

        foreach (GameObject waterBombGO in waterBombs)
        {
            Unit waterBomb = waterBombGO.GetComponent<Unit>();

            if (waterBomb.followingPath || isAnyOneFollowing)
            {
                isAnyOneFollowing = true;
            }
            else
            {
                isAnyOneFollowing = false;
            }
        }

        return isAnyOneFollowing;
    }

    public int WaterBombsOnMap
    {
        get
        {
            return waterBombCount;
        }
        set
        {
            waterBombCount = value;
        }
    }
}
