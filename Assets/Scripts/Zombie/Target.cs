using UnityEngine;

public class Target : MonoBehaviour {

    public float maxHealth;
    public float maxCapacity;

    public ParticleSystem death;

    [System.NonSerialized]
    public float currentHealth;
    [System.NonSerialized]
    public float currentCapacity;
    [System.NonSerialized]
    public bool isCurrentlyDying = false;
    [System.NonSerialized]
    public int gameMode;

    private Zombie zombie;
    private WaterBomb waterBomb;

    void Start()
    {
        gameMode = SaveSystem.LoadDataGameMode().gameModeSave;

        if (gameMode == 0)
        {
            waterBomb = GetComponent<WaterBomb>();

            currentCapacity = 0;
        }
        else if (gameMode == 1)
        {
            zombie = GetComponent<Zombie>();

            currentHealth = zombie.maxHealth;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        GetComponent<ZombieAudioManager>().Play("OnHit");
        if (currentHealth <= 0 && !isCurrentlyDying)
        {
            Die();
        }
        if (!zombie.hasTakenDamage) zombie.hasTakenDamage = !zombie.hasTakenDamage;
    }

    public void FillWater(float amount)
    {
        currentCapacity += amount;
        GetComponent<WaterBombAudioManager>().Play("OnHit");
        if (currentCapacity >= waterBomb.maxCapacity && !isCurrentlyDying)
        {
            WaterBombExplode();
        }
        if (!waterBomb.hasTakenDamage) waterBomb.hasTakenDamage = !waterBomb.hasTakenDamage;
    }

    void Die()
    {
        isCurrentlyDying = true;

        SaveDataDifficulty diffData = SaveSystem.LoadDataDifficultySave();
        int diff = diffData.difficultySave;

        WaveManager wm;

        wm = GetComponent<Unit>().zombieManager.GetComponent<WaveManager>();
        ZombieManager zm = GameObject.Find("GameManager").GetComponent<ZombieManager>();

        GetComponent<ZombieAudioManager>().Play("Death");

        zm.ZombiesOnMap--;
        zm.zombies.Remove(this.gameObject);

        switch (diff)
        {
            case 0:

                wm.IncreaseScore(wm.pointsPerZombieEasy);
                wm.IncreaseCoins(wm.coinsPerZombieEasy);

                GameObject.Find("GameManager").GetComponent<GameManager>().totalZombiesKilled++;
                GameObject.Find("GameManager").GetComponent<GameManager>().UpdateTotalZombieKills();

                break;
            case 1:

                wm.IncreaseScore(wm.pointsPerZombieMedium);
                wm.IncreaseCoins(wm.coinsPerZombieMedium);

                GameObject.Find("GameManager").GetComponent<GameManager>().totalZombiesKilledMedium++;
                GameObject.Find("GameManager").GetComponent<GameManager>().UpdateTotalZombieKillsMedium();

                break;
            case 2:

                wm.IncreaseScore(wm.pointsPerZombieHard);
                wm.IncreaseCoins(wm.coinsPerZombieHard);

                GameObject.Find("GameManager").GetComponent<GameManager>().totalZombiesKilledHard++;
                GameObject.Find("GameManager").GetComponent<GameManager>().UpdateTotalZombieKillsHard();

                break;

        }

        wm.UpdateScore();
        wm.UpdateCoins();

        death.Play();

        gameObject.transform.Find("Character").gameObject.SetActive(false);
        gameObject.transform.Find("Canvas").gameObject.SetActive(false);
        GetComponent<Unit>().StopCoroutine("FollowPath");
        GetComponent<Unit>().StopCoroutine("UpdatePath");
        GetComponent<Zombie>().active = false;
        Destroy(gameObject, GetComponent<ZombieAudioManager>().Length("Death"));
    }

    void WaterBombExplode()
    {
        isCurrentlyDying = true;

        SaveDataDifficulty diffData = SaveSystem.LoadDataDifficultySave();
        int diff = diffData.difficultySave;

        WaveManager wm;

        wm = GetComponent<Unit>().waterBombManager.GetComponent<WaveManager>();
        WaterBombManager wBm = GameObject.Find("GameManager").GetComponent<WaterBombManager>();

        GetComponent<WaterBombAudioManager>().Play("Death");

        wBm.WaterBombsOnMap--;
        wBm.waterBombs.Remove(this.gameObject);

        death.Play();

        switch (diff)
        {
            case 0:

                wm.IncreaseScore(wm.pointsPerWaterBombEasy);
                wm.IncreaseCoins(wm.coinsPerWaterBombEasy);

                GameObject.Find("GameManager").GetComponent<GameManager>().totalWaterBombsExploded++;
                GameObject.Find("GameManager").GetComponent<GameManager>().UpdateTotalWaterBombsExploded();

                break;
            case 1:

                wm.IncreaseScore(wm.pointsPerWaterBombMedium);
                wm.IncreaseCoins(wm.coinsPerWaterBombMedium);

                GameObject.Find("GameManager").GetComponent<GameManager>().totalWaterBombsExplodedMedium++;
                GameObject.Find("GameManager").GetComponent<GameManager>().UpdateTotalWaterBombsExplodedMedium();

                break;
            case 2:

                wm.IncreaseScore(wm.pointsPerWaterBombHard);
                wm.IncreaseCoins(wm.coinsPerWaterBombHard);

                GameObject.Find("GameManager").GetComponent<GameManager>().totalWaterBombsExplodedHard++;
                GameObject.Find("GameManager").GetComponent<GameManager>().UpdateTotalWaterBombsExplodedHard();

                break;

        }

        wm.UpdateScore();
        wm.UpdateCoins();

        gameObject.transform.Find("Character").gameObject.SetActive(false);
        gameObject.transform.Find("Canvas").gameObject.SetActive(false);
        GetComponent<Unit>().StopCoroutine("FollowPath");
        GetComponent<Unit>().StopCoroutine("UpdatePath");
        GetComponent<WaterBomb>().active = false;
        Destroy(gameObject, GetComponent<WaterBombAudioManager>().Length("Death"));
    }

    public float max
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }

    public float maxCapa
    {
        get
        {
            return maxCapacity;
        }
        set
        {
            maxCapacity = value;
        }
    }

    public float health
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }

    public float capa
    {
        get
        {
            return currentCapacity;
        }
        set
        {
            currentCapacity = value;
        }
    }

}
