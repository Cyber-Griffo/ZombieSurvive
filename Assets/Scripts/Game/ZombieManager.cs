using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour {

    public int zombieAnzahl = 3;
    public int zombieSpawnPunkteAnzahl = 3;
    public float zeitZwischenZombieSpawns = 10f;
    public float wakeUpRadius = 50f;

    public Zombie zombieScript;
    public GameObject zombieGo;

    [System.NonSerialized]
    public List<GameObject> zombies = new List<GameObject>();
    [System.NonSerialized]
    public WaveManager wm;

    [System.NonSerialized]
    public int extraHealth = 0;
    [System.NonSerialized]
    public int extraSpeedEasy;
    [System.NonSerialized]
    public int extraDamageEasy;
    [System.NonSerialized]
    public int healthPerWaveEasy;

    [System.NonSerialized]
    public int extraSpeedMedium;
    [System.NonSerialized]
    public int extraDamageMedium;
    [System.NonSerialized]
    public int healthPerWaveMedium;

    [System.NonSerialized]
    public int extraSpeedHard;
    [System.NonSerialized]
    public int extraDamageHard;
    [System.NonSerialized]
    public int healthPerWaveHard;

    private int zombieCount = 0;

    private void Awake()
    {
        wm = GetComponent<WaveManager>();

        extraDamageEasy = wm.increasedZombieDamageEasy;
        extraSpeedEasy = wm.increasedZombieSpeedEasy;

        extraDamageMedium = wm.increasedZombieDamageMedium;
        extraSpeedMedium = wm.increasedZombieSpeedMedium;

        extraDamageHard = wm.increasedZombieDamageHard;
        extraSpeedHard = wm.increasedZombieSpeedHard;
    }

    public void SpawnZombie(GameObject spawnPoint, Vector3 offset, Quaternion rotation, int diff, bool upgradeWave)
    {
        wm = GetComponent<WaveManager>();

        //Instantiate Zombie GameObject
        GameObject zombie = Instantiate(zombieGo, spawnPoint.transform.position + offset, rotation);
        zombie.GetComponent<ZombieAudioManager>().Play("Spawn");

        switch (diff)
        {
            case 0:

                //Setting Zombie Values
                extraHealth = wm.increasedZombieHealthEasy * (wm.waveCount - 1);
                
                if (upgradeWave)
                {
                    zombie.GetComponent<Zombie>().speed += extraSpeedEasy;
                    zombie.GetComponent<Zombie>().damage += extraDamageEasy;
                }

                break;
            case 1:

                //Setting Zombie Values
                extraHealth = wm.increasedZombieHealthMedium * (wm.waveCount - 1);

                if (upgradeWave)
                {
                    zombie.GetComponent<Zombie>().speed += extraSpeedMedium;
                    zombie.GetComponent<Zombie>().damage += extraDamageMedium;
                }

                break;
            case 2:

                //Setting Zombie Values
                extraHealth = wm.increasedZombieHealthHard * (wm.waveCount - 1);

                if (upgradeWave)
                {
                    zombie.GetComponent<Zombie>().speed += extraSpeedHard;
                    zombie.GetComponent<Zombie>().damage += extraDamageHard;
                }

                break;
        }

        zombie.GetComponent<Zombie>().maxHealth += extraHealth;
        zombie.GetComponent<Target>().currentHealth = zombie.GetComponent<Zombie>().maxHealth;

        zombie.GetComponent<Zombie>().SetUpValues();

        //Adding zombie to list
        zombies.Add(zombie);
        zombieCount++;
    }

    public bool IsAnyOneFollowingPlayer()
    {
        bool isAnyOneFollowing = false;

        foreach (GameObject zombieGO in zombies)
        {
            Unit zombie = zombieGO.GetComponent<Unit>();

            if (zombie.followingPath || isAnyOneFollowing)
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

    public int ZombiesOnMap
    {
        get
        {
            return zombieCount;
        }
        set
        {
            zombieCount = value;
        }
    }
}
