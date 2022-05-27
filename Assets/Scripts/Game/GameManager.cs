using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [Header("Lists")]
    public List<GameObject> placeHoldersMainMenu;
    public List<GameObject> mainMenuModules;
    public List<GameObject> mainMenuModulesWaterBombs;
    public List<GameObject> placeHoldersInsideGrid;
    public List<GameObject> zombieSpawnModules;
    public List<GameObject> WaterBombsSpawnModules;
    public List<GameObject> placeHoldersOutsideGrid;
    public List<GameObject> surroundingModules;
    public List<GameObject> surroundingModulesWaterBombs;
    public List<GameObject> playerSpawnModules;
    public List<GameObject> playerSpawnModulesWaterBombs;
    public List<GameObject> zombieSpawnHäuschenObjects;
    public List<GameObject> WaterBombsSpawnHäuschenObjects;

    [Header("LayerMasks")]
    public LayerMask groundMask;

    [Header("GameObjects")]
    public GameObject player;
    public Grid grid;
    public Mouselook mouseLook;
    public GameObject center;
    public ZombieManager zombieManager;
    public WaterBombManager waterBombManager;
    public WaveManager waveManager;
    public Glock glock;
    public WaterGun waterGun;
    public LevelLoader levelLoader;

    [Header("UI Elements")]
    public TMP_Text deathText;
    public TMP_Text scoreTextEndScreen;
    public Statistics statistics;
    public GameObject waitingScreen;

    [Header("Variables")]
    public Vector3 offsetZombie = Vector3.zero;
    public Vector3 offsetWaterBomb = Vector3.zero;

    [Header("SaveSystem")]
    SavesDataStatistics dataStatistics;

    [Header("Skyboxes")]
    public Material zombieSkybox;
    public Material waterBombSkybox;

    [System.NonSerialized]
    public List<GameObject> modulesSpawned = new List<GameObject>();
    [System.NonSerialized]
    public List<GameObject> modulesSpawned_MainMenu = new List<GameObject>();
    [System.NonSerialized]
    public List<GameObject> zombieSpawnPoints = new List<GameObject>();
    [System.NonSerialized]
    public List<GameObject> waterBombSpawnPoints = new List<GameObject>();
    [System.NonSerialized]
    public GameObject spawnModule;
    [System.NonSerialized]
    public GameObject ui;
    [System.NonSerialized]
    public bool sceneHasInitialized = false;
    [System.NonSerialized]
    public bool allZombiesSpawned = false;
    [System.NonSerialized]
    public bool allWaterBombsSpawned = false;
    [System.NonSerialized]
    public bool gameIsCurrentlyEnded = false;
    [System.NonSerialized]
    public int highScore;
    [System.NonSerialized]
    public int highScoreMedium;
    [System.NonSerialized]
    public int highScoreHard;
    [System.NonSerialized]
    public int highScoreWaterBombs;
    [System.NonSerialized]
    public int highScoreWaterBombsMedium;
    [System.NonSerialized]
    public int highScoreWaterBombsHard;
    [System.NonSerialized]
    public int totalZombiesKilled;
    [System.NonSerialized]
    public int totalZombiesKilledMedium;
    [System.NonSerialized]
    public int totalZombiesKilledHard;
    [System.NonSerialized]
    public int totalWaterBombsExploded;
    [System.NonSerialized]
    public int totalWaterBombsExplodedMedium;
    [System.NonSerialized]
    public int totalWaterBombsExplodedHard;
    [System.NonSerialized]
    public int maxWave;
    [System.NonSerialized]
    public int maxWaveMedium;
    [System.NonSerialized]
    public int maxWaveHard;
    [System.NonSerialized]
    public int maxWaveWaterBombs;
    [System.NonSerialized]
    public int maxWaveWaterBombsMedium;
    [System.NonSerialized]
    public int maxWaveWaterBombsHard;
    [System.NonSerialized]
    public bool newHighscore = false;
    [System.NonSerialized]
    public AudioManager audioManager;
    [System.NonSerialized]
    public bool nextWaveIsUpgradeWave = false;
    [System.NonSerialized]
    public int diff;
    [System.NonSerialized]
    public int gameMode;
    [System.NonSerialized]
    public bool modulesCleared;
    [System.NonSerialized]
    public bool buttonPressed = false;

    private bool spawnModuleSpwaned = false;
    private string deadText;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(StartGameSetUp());
    }

    IEnumerator StartGameSetUp()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        SaveDataGameMode dataGameMode = SaveSystem.LoadDataGameMode();
        SaveDataDifficulty dataDifficulty = SaveSystem.LoadDataDifficultySave();

        if(dataGameMode == null)
        {
            gameMode = 1;
        }
        else
        {
            gameMode = dataGameMode.gameModeSave;
        }

        if(dataDifficulty == null)
        {
            diff = 0;
        }
        else
        {
            diff = dataDifficulty.difficultySave;
        }

        if (gameMode == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                waitingScreen.SetActive(true);

                ui = GameObject.FindGameObjectWithTag("UI");
                glock.gameObject.SetActive(true);
                waterGun.gameObject.SetActive(false);

                scoreTextEndScreen.text = "Your Score: ";

                SetUpSceneZombies();
                SpawnPlayer();
                mouseLook.ToggleCursorMode();
                mouseLook.LookAtPoint(center.transform);
                gameIsCurrentlyEnded = false;

                mouseLook.SetUpGuns(gameMode);

                waitingScreen.SetActive(false);

                sceneHasInitialized = true;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                audioManager.Play("MainMenuBackgroundZombie");
                SetEnviornmentSettingsZombie();
                SetUpMainMenuBackGroundZombies();
            }
        }
        else if (gameMode == 0)
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                waitingScreen.SetActive(true);

                ui = GameObject.FindGameObjectWithTag("UI");
                glock.gameObject.SetActive(false);
                waterGun.gameObject.SetActive(true);

                scoreTextEndScreen.text = "Your Score: ";

                SetUpSceneWaterbombs();
                SpawnPlayer();
                mouseLook.ToggleCursorMode();
                mouseLook.LookAtPoint(center.transform);
                gameIsCurrentlyEnded = false;

                mouseLook.SetUpGuns(gameMode);

                waitingScreen.SetActive(false);

                sceneHasInitialized = true;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                audioManager.Play("MainMenuBackgroundWaterBomb");
                SetEnviornmentSettingsWaterBomb();
                SetUpMainMenuBackGroundWaterBombs();
            }
        }

        dataStatistics = SaveSystem.LoadDataStatistics();

        if (dataStatistics != null)
        {
            LoadSavedDataHighScore(dataStatistics);
        }
        else
        {
            LoadDefaultValues();
        }
        statistics.SetScores(highScore, highScoreWaterBombs, totalZombiesKilled, totalZombiesKilledMedium, totalZombiesKilledHard, totalWaterBombsExploded,
                             totalWaterBombsExplodedMedium, totalWaterBombsExplodedHard, maxWave, maxWaveWaterBombs, highScoreMedium, highScoreHard, highScoreWaterBombsMedium,
                             highScoreWaterBombsHard, maxWaveMedium, maxWaveHard, maxWaveWaterBombsMedium, maxWaveWaterBombsHard);

        yield return null;
    }

    void Update()
    {
        if (gameMode == 1)
        {
            if (SceneManager.GetActiveScene().name != "MainMenu" && zombieManager.ZombiesOnMap == 0 && sceneHasInitialized && !waveManager.isCurrentlyLoadingNextWave)
            {
                print("Zombies On Map, load Next Wave: " + zombieManager.ZombiesOnMap);
                waveManager.LoadNextWaveZombies(diff);
            }
        }
        else if(gameMode == 0)
        {
            if(SceneManager.GetActiveScene().name != "MainMenu" && !waveManager.isCurrentlyLoadingNextWave && waterBombManager.WaterBombsOnMap == 0 && sceneHasInitialized)
            {
                print("Waterbombs On Map, load Next Wave " + waterBombManager.WaterBombsOnMap);
                waveManager.LoadNextWaveWaterBombs(diff);
            }
        }
    }

    void SetUpSceneZombies()
    {
        SetEnviornmentSettingsZombie();

        SpawnSurroundingsZombies();

        ReplacePlaceHoldersZombies();

        SetUpGrid();

        waveManager.LoadNextWaveZombies(diff);
    }

    void SetUpSceneWaterbombs()
    {
        SetEnviornmentSettingsWaterBomb();

        SpawnSurroundingsWaterBombs();

        ReplacePlaceHoldersWaterBombs();

        SetUpGrid();

        waveManager.LoadNextWaveWaterBombs(diff);
    }

    void SetEnviornmentSettingsWaterBomb()
    {
        RenderSettings.skybox = waterBombSkybox;

        RenderSettings.ambientIntensity = 3.3f;
    }

    void SetEnviornmentSettingsZombie()
    {
        RenderSettings.skybox = zombieSkybox;

        RenderSettings.ambientIntensity = 1.2f;
    }

    void SetUpGrid()
    {
        grid.SetUp();
        grid.CreateGrid();
    }

    public void ButtonPressed()
    {
        buttonPressed = true;
    }

    public void ChangeMainMenuBackGround(int index)
    {
        if (buttonPressed && Time.timeSinceLevelLoad > 1f)
        {
            StopCoroutine(ReplaceModules(index));
            StartCoroutine(ReplaceModules(index));
        }
    }

    IEnumerator ReplaceModules(int index)
    {
        GameObject.Find("Menu").GetComponent<Settings>().gameModeDropdown.enabled = false;
        StopCoroutine(ClearModules());
        StartCoroutine(ClearModules());

        yield return new WaitForSeconds(1f);

        while (!modulesCleared)
        {
            yield return new WaitForSeconds(1f);
        }

        switch (index)
        {
            case 0:

                StopSounds();
                audioManager.Play("MainMenuBackgroundWaterBomb");

                SetEnviornmentSettingsWaterBomb();
                StartCoroutine(SetUpMainMenuBackGroundWaterBombsCoroutine());

                break;
            case 1:

                StopSounds();
                audioManager.Play("MainMenuBackgroundZombie");

                SetEnviornmentSettingsZombie();
                StartCoroutine(SetUpMainMenuBackGroundZombiesCoroutine());

                break;
        }
        yield return null;
    }

    IEnumerator ClearModules()
    {
        modulesCleared = false;

        GameObject[] hilfArray = modulesSpawned_MainMenu.ToArray();

        for(int i = 0; i < hilfArray.Length; i++)
        {
            Destroy(hilfArray[i]);

            yield return new WaitForSeconds(0.005f);
        }

        modulesSpawned_MainMenu.Clear();

        modulesCleared = true;
    }

    void SetUpMainMenuBackGroundZombies()
    {
        foreach (GameObject g in placeHoldersMainMenu)
        {
            GameObject gm = null;

            int random = Random.Range(0, 4);
            int degrees = GetDegrees(random);

            if (!(Random.Range(0, 50) == 1))
            {
                gm = Instantiate(mainMenuModules[Random.Range(0, mainMenuModules.Count)], g.transform.position, Quaternion.Euler(0, degrees, 0));
                gm.transform.parent = GameObject.Find("BackGroundModules").transform;
                modulesSpawned_MainMenu.Add(gm);
            }
        }
    }

    void SetUpMainMenuBackGroundWaterBombs()
    {
        foreach (GameObject g in placeHoldersMainMenu)
        {
            GameObject gm = null;

            int random = Random.Range(0, 4);
            int degrees = GetDegrees(random);

            if (!(Random.Range(0, 50) == 1))
            {
                gm = Instantiate(mainMenuModulesWaterBombs[Random.Range(0, mainMenuModulesWaterBombs.Count)], g.transform.position, Quaternion.Euler(0, degrees, 0));
                gm.transform.parent = GameObject.Find("BackGroundModules").transform;
                modulesSpawned_MainMenu.Add(gm);
            }
        }
    }

    IEnumerator SetUpMainMenuBackGroundZombiesCoroutine()
    {
        foreach (GameObject g in placeHoldersMainMenu)
        {
            GameObject gm = null;

            int random = Random.Range(0, 4);
            int degrees = GetDegrees(random);

            if (!(Random.Range(0, 50) == 1))
            {
                gm = Instantiate(mainMenuModules[Random.Range(0, mainMenuModules.Count)], g.transform.position, Quaternion.Euler(0, degrees, 0));
                gm.transform.parent = GameObject.Find("BackGroundModules").transform;
                modulesSpawned_MainMenu.Add(gm);
            }

            yield return new WaitForSeconds(0.005f);
        }

        GameObject.Find("Menu").GetComponent<Settings>().gameModeDropdown.enabled = true;
        buttonPressed = false;
    }

    IEnumerator SetUpMainMenuBackGroundWaterBombsCoroutine()
    {
        foreach (GameObject g in placeHoldersMainMenu)
        {
            GameObject gm = null;

            int random = Random.Range(0, 4);
            int degrees = GetDegrees(random);

            if (!(Random.Range(0, 50) == 1))
            {
                gm = Instantiate(mainMenuModulesWaterBombs[Random.Range(0, mainMenuModulesWaterBombs.Count)], g.transform.position, Quaternion.Euler(0, degrees, 0));
                gm.transform.parent = GameObject.Find("BackGroundModules").transform;
                modulesSpawned_MainMenu.Add(gm);
            }

            yield return new WaitForSeconds(0.005f);
        }

        GameObject.Find("Menu").GetComponent<Settings>().gameModeDropdown.enabled = true;
        buttonPressed = false;
    }

    void SpawnSurroundingsZombies()
    {
        foreach(GameObject g in placeHoldersOutsideGrid)
        {
            GameObject gm = null;

            int random = Random.Range(0, 4);
            int degrees = GetDegrees(random);
            gm = Instantiate(surroundingModules[Random.Range(0, surroundingModules.Count)], g.transform.position, Quaternion.Euler(0, degrees, 0));
            gm.transform.parent = GameObject.Find("PlaceHoldersOutsideGrid").transform;
        }
    }

    void SpawnSurroundingsWaterBombs()
    {
        foreach(GameObject g in placeHoldersOutsideGrid)
        {
            GameObject gm = null;

            int random = Random.Range(0, 4);
            int degrees = GetDegrees(random);
            gm = Instantiate(surroundingModulesWaterBombs[Random.Range(0, surroundingModulesWaterBombs.Count)], g.transform.position, Quaternion.Euler(0, degrees, 0));
            gm.transform.parent = GameObject.Find("PlaceHoldersOutsideGrid").transform;
        }
    }

    void ReplacePlaceHoldersZombies()
    {
        int count = placeHoldersInsideGrid.Count;

        foreach (GameObject g in placeHoldersInsideGrid)
        {
            GameObject gm = null;

            int random = Random.Range(0, 4);
            int degrees = GetDegrees(random);

            if (!(Random.Range(0, 50) == 1))
            {
                if (spawnModuleSpwaned)
                {
                    gm = Instantiate(zombieSpawnModules[Random.Range(0, zombieSpawnModules.Count)], g.transform.position, Quaternion.Euler(0, degrees, 0));
                    modulesSpawned.Add(gm);
                }
                else
                {
                    if ((Random.Range(0, 30) == 1) && count >= 2)
                    {
                        Instantiate(playerSpawnModules[Random.Range(0, playerSpawnModules.Count)], g.transform.position, Quaternion.Euler(0, degrees, 0)).transform.parent = GameObject.Find("PlayerSpawnModule").transform;
                        spawnModuleSpwaned = true;
                    }
                    else if (count < 2)
                    {
                        Instantiate(playerSpawnModules[Random.Range(0, playerSpawnModules.Count)], g.transform.position, Quaternion.Euler(0, degrees, 0)).transform.parent = GameObject.Find("PlayerSpawnModule").transform;
                        spawnModuleSpwaned = true;
                    }
                    else
                    {
                        gm = Instantiate(zombieSpawnModules[Random.Range(0, zombieSpawnModules.Count)], g.transform.position, Quaternion.Euler(0, degrees, 0));
                        modulesSpawned.Add(gm);
                    }
                }
                if(gm != null)
                    gm.transform.parent = GameObject.Find("ZombieSpawnModules").transform;
            }
            count--;
        }
    }

    void ReplacePlaceHoldersWaterBombs()
    {
        int count = placeHoldersInsideGrid.Count;

        foreach (GameObject g in placeHoldersInsideGrid)
        {
            GameObject gm = null;

            int random = Random.Range(0, 4);
            int degrees = GetDegrees(random);

            if (!(Random.Range(0, 50) == 1))
            {
                if (spawnModuleSpwaned)
                {
                    gm = Instantiate(WaterBombsSpawnModules[Random.Range(0, WaterBombsSpawnModules.Count)], g.transform.position, Quaternion.Euler(0, degrees, 0));
                    modulesSpawned.Add(gm);
                }
                else
                {
                    if ((Random.Range(0, 30) == 1) && count >= 2)
                    {
                        Instantiate(playerSpawnModulesWaterBombs[Random.Range(0, playerSpawnModulesWaterBombs.Count)], g.transform.position, Quaternion.Euler(0, degrees, 0)).transform.parent = GameObject.Find("PlayerSpawnModule").transform;
                        spawnModuleSpwaned = true;
                    }
                    else if (count < 2)
                    {
                        Instantiate(playerSpawnModulesWaterBombs[Random.Range(0, playerSpawnModulesWaterBombs.Count)], g.transform.position, Quaternion.Euler(0, degrees, 0)).transform.parent = GameObject.Find("PlayerSpawnModule").transform;
                        spawnModuleSpwaned = true;
                    }
                    else
                    {
                        gm = Instantiate(WaterBombsSpawnModules[Random.Range(0, WaterBombsSpawnModules.Count)], g.transform.position, Quaternion.Euler(0, degrees, 0));
                        modulesSpawned.Add(gm);
                    }
                }
                if(gm != null)
                    gm.transform.parent = GameObject.Find("WaterBombSpawnModules").transform;
            }
            count--;
        }
    }

    void SpawnPlayer()
    {
        spawnModule = GameObject.FindGameObjectWithTag("SpawnModule");
        Vector3 playerSpawnPoint = GameObject.Find("PlayerSpawnPoint").transform.position;
        playerSpawnPoint.y += player.transform.localScale.y * 2;
        SetPlayerPos(playerSpawnPoint);
    }

    void SetPlayerPos(Vector3 newPos)
    {
        player.transform.position = newPos;
    }

    int GetDegrees(int random)
    {
        if (random == 0)
        {
            return 0;
        }
        else if (random == 1)
        {
            return 90;
        }
        else if (random == 2)
        {
            return 180;
        }
        else if (random == 3)
        {
            return 270;
        }
        else
        {
            print("this can be real: " + random);
            return 1;
        }
    }

    public void EndGame()
    {
        GameOver();
        ui.GetComponent<Animator>().SetTrigger("gameOver");
    }

    void GameOver()
    {
        //Show Statistic, Retry Button, Main Menu Button, Exit Button
        print("Game Over...");
        print("gameMode: " + gameMode);
        print("Difficutly: " + diff);

        gameIsCurrentlyEnded = true;

        switch (gameMode)
        {
            case 0:

                audioManager.Play("PlayerDeath_waterBomb");

                switch (diff)
                {
                    case 0:

                        if (highScoreWaterBombs < waveManager.score)
                        {
                            highScoreWaterBombs = waveManager.score;
                            newHighscore = true;
                        }
                        else
                        {
                            newHighscore = false;
                        }
                        if (maxWaveWaterBombs < waveManager.waveCount)
                        {
                            maxWaveWaterBombs = waveManager.waveCount;
                        }

                        break;
                    case 1:

                        if (highScoreWaterBombsMedium < waveManager.score)
                        {
                            highScoreWaterBombsMedium = waveManager.score;
                            newHighscore = true;
                        }
                        else
                        {
                            newHighscore = false;
                        }
                        if (maxWaveWaterBombsMedium < waveManager.waveCount)
                        {
                            maxWaveWaterBombsMedium = waveManager.waveCount;
                        }

                        break;
                    case 2:

                        if (highScoreWaterBombsHard < waveManager.score)
                        {
                            highScoreWaterBombsHard = waveManager.score;
                            newHighscore = true;
                        }
                        else
                        {
                            newHighscore = false;
                        }
                        if (maxWaveWaterBombsHard < waveManager.waveCount)
                        {
                            maxWaveWaterBombsHard = waveManager.waveCount;
                        }

                        break;
                }
                waterGun.ToggleCanShoot();

                break;
            case 1:

                audioManager.Play("PlayerDeath");

                switch (diff)
                {
                    case 0:

                        if (highScore < waveManager.score)
                        {
                            highScore = waveManager.score;
                            newHighscore = true;
                        }
                        else
                        {
                            newHighscore = false;
                        }
                        if (maxWave < waveManager.waveCount)
                        {
                            maxWave = waveManager.waveCount;
                        }

                        break;
                    case 1:

                        if (highScoreMedium < waveManager.score)
                        {
                            highScoreMedium = waveManager.score;
                            newHighscore = true;
                        }
                        else
                        {
                            newHighscore = false;
                        }
                        if (maxWaveMedium < waveManager.waveCount)
                        {
                            maxWaveMedium = waveManager.waveCount;
                        }

                        break;
                    case 2:

                        if (highScoreHard < waveManager.score)
                        {
                            highScoreHard = waveManager.score;
                            newHighscore = true;
                        }
                        else
                        {
                            newHighscore = false;
                        }
                        if (maxWaveHard < waveManager.waveCount)
                        {
                            maxWaveHard = waveManager.waveCount;
                        }

                        break;
                }
                glock.ToggleCanShoot();

                break;
        }

        Time.timeScale = 0f;

        statistics.SetScores(highScore, highScoreWaterBombs, totalZombiesKilled, totalZombiesKilledMedium, totalZombiesKilledHard, totalWaterBombsExploded,
                             totalWaterBombsExplodedMedium, totalWaterBombsExplodedHard, maxWave, maxWaveWaterBombs, highScoreMedium, highScoreHard, highScoreWaterBombsMedium,
                             highScoreWaterBombsHard, maxWaveMedium, maxWaveHard, maxWaveWaterBombsMedium, maxWaveWaterBombsHard);
        SaveData();
        SetUI();
        mouseLook.ToggleCursorMode();
    }
    
    public void StartGame()
    {
        levelLoader.SetLoadingScreenActive(true);
        levelLoader.LoadLevel("MainScene");

        StopSounds();

        switch (gameMode)
        {
            case 0:

                audioManager.Play("InGameBackgroundWaterBomb");

                break;
            case 1:

                audioManager.Play("InGameBackgroundZombie");

                break;
        }

    }

    void SetUI()
    {
        deathText.text = deadText + "";
        if (newHighscore)
        {
            scoreTextEndScreen.text += waveManager.score + "\n NEW HIGHSCORE!";
        }
        else
        {
            scoreTextEndScreen.text += waveManager.score;
        }
    }

    public void SetText(string text)
    {
        if(text != null)
        {
            deadText = text;
        }
    }

    public IEnumerator SpawnZombies(int count)
    {
        allZombiesSpawned = false;
        int zombiesSpawned = 0;
        while (zombiesSpawned < count)
        {

            foreach (GameObject g in zombieSpawnPoints)
            {
                zombieManager.SpawnZombie(g, offsetZombie, Quaternion.identity, diff, nextWaveIsUpgradeWave);

                float ms = Time.deltaTime;
                while (ms <= zombieManager.zeitZwischenZombieSpawns)
                {
                    ms += Time.deltaTime;
                    yield return null;
                }
            }
            zombiesSpawned++;
        }
        allZombiesSpawned = true;
    }

    public IEnumerator SpawnWaterBombs(int count)
    {
        print("spawning Water Bombs");

        allWaterBombsSpawned = false;
        int waterBombsSpawned = 0;
        while (waterBombsSpawned < count)
        {

            foreach (GameObject g in waterBombSpawnPoints)
            {
                waterBombManager.SpawnWaterBomb(g, offsetWaterBomb, Quaternion.identity, diff, nextWaveIsUpgradeWave);

                float ms = Time.deltaTime;
                while (ms <= waterBombManager.zeitZwischenWaterBombSpawns)
                {
                    ms += Time.deltaTime;
                    yield return null;
                }
            }
            waterBombsSpawned++;
        }

        print("all Water Bombs spawned");

        allWaterBombsSpawned = true;
    }

    public void UpdateZombieSpawnPoints(int zSHcount)
    {
        if (zombieSpawnPoints.Count != 0)
        {
            DeleteSpawnHäuschchen();
        }
        GameObject gm = null;
        int count = modulesSpawned.Count;
        int zombiesToSpawn = 0;

        foreach(GameObject g in modulesSpawned)
        {
            if (zombiesToSpawn < zSHcount)
            {
                if (Random.Range(0, 50) == 1 && count > zSHcount)
                {
                    gm = Instantiate(zombieSpawnHäuschenObjects[Random.Range(0, zombieSpawnHäuschenObjects.Count)], g.transform.Find("ZombieSpawnPoint").position + offsetZombie, Quaternion.identity);
                    zombieSpawnPoints.Add(gm);
                    zombiesToSpawn++;
                }
                else
                {
                    if (count <= zSHcount)
                    {
                        gm = Instantiate(zombieSpawnHäuschenObjects[Random.Range(0, zombieSpawnHäuschenObjects.Count)], g.transform.Find("ZombieSpawnPoint").position + offsetZombie, Quaternion.identity);
                        zombieSpawnPoints.Add(gm);
                        zombiesToSpawn++;
                    }
                }
            }
            count--;
        }
    }

    public void UpdateWaterBombSpawnPoints(int wBSHcount)
    {
        if (waterBombSpawnPoints.Count != 0)
        {
            DeleteSpawnHäuschchenWaterBomb();
        }
        GameObject gm = null;
        int count = modulesSpawned.Count;
        int waterBombsToSpawn = 0;

        foreach(GameObject g in modulesSpawned)
        {
            if (waterBombsToSpawn < wBSHcount)
            {
                if (Random.Range(0, 50) == 1 && count > wBSHcount)
                {
                    gm = Instantiate(WaterBombsSpawnHäuschenObjects[Random.Range(0, WaterBombsSpawnHäuschenObjects.Count)], g.transform.Find("WaterBombSpawnPoint").position + offsetWaterBomb, Quaternion.identity);
                    waterBombSpawnPoints.Add(gm);
                    waterBombsToSpawn++;
                }
                else
                {
                    if (count <= wBSHcount)
                    {
                        gm = Instantiate(WaterBombsSpawnHäuschenObjects[Random.Range(0, WaterBombsSpawnHäuschenObjects.Count)], g.transform.Find("WaterBombSpawnPoint").position + offsetWaterBomb, Quaternion.identity);
                        waterBombSpawnPoints.Add(gm);
                        waterBombsToSpawn++;
                    }
                }
            }
            count--;
        }
    }

    void DeleteSpawnHäuschchen()
    {
        foreach(GameObject spawnHäusschen in zombieSpawnPoints)
        {
            Destroy(spawnHäusschen);
        }

        zombieSpawnPoints.Clear();
    }

    void DeleteSpawnHäuschchenWaterBomb()
    {
        foreach(GameObject spawnHäusschen in waterBombSpawnPoints)
        {
            Destroy(spawnHäusschen);
        }

        waterBombSpawnPoints.Clear();
    }

    public void LoadScene(string name, int index)
    {
        if(name != null)
        {
            SceneManager.LoadScene(name);
        }
        else
        {
            SceneManager.LoadScene(index);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SaveData()
    {
        print("Saving Data...");
        SaveSystem.SaveDataStatistics(highScore, highScoreWaterBombs, totalZombiesKilled, totalZombiesKilledMedium, totalZombiesKilledHard, totalWaterBombsExploded,
                                      totalWaterBombsExplodedMedium, totalWaterBombsExplodedHard, maxWave, maxWaveWaterBombs, highScoreMedium, highScoreHard, highScoreWaterBombsMedium,
                                      highScoreWaterBombsHard, maxWaveMedium, maxWaveHard, maxWaveWaterBombsMedium, maxWaveWaterBombsHard);
    }

    void LoadSavedDataHighScore(SavesDataStatistics data)
    {
        highScore = data.highScore;
        totalZombiesKilled = data.totalZombiesKilled;
        totalZombiesKilledMedium = data.totalZombiesKilledMedium;
        totalZombiesKilledHard = data.totalZombiesKilledHard;
        maxWave = data.maxWave;
        highScoreWaterBombs = data.highScoreWaterBombs;
        totalWaterBombsExploded = data.totalWaterBombsExploded;
        totalWaterBombsExplodedMedium = data.totalWaterBombsExplodedMedium;
        totalWaterBombsExplodedHard = data.totalWaterBombsExplodedHard;
        maxWaveWaterBombs = data.maxWaveWaterBombs;
        highScoreMedium = data.highscoreMedium;
        highScoreHard = data.highscoreHard;
        highScoreWaterBombsMedium = data.highscoreWaterBombsMedium;
        highScoreWaterBombsHard = data.highscoreWaterBombsHard;
        maxWaveMedium = data.maxWaveMedium;
        maxWaveHard = data.maxWaveHard;
        maxWaveWaterBombsMedium = data.maxWaveWaterBombsMedium;
        maxWaveWaterBombsHard = data.maxWaveWaterBombsHard;
    }

    void LoadDefaultValues()
    {
        highScore = 0;
        totalZombiesKilled = 0;
        totalZombiesKilledMedium = 0;
        totalZombiesKilledHard = 0;
        maxWave = 0;
        highScoreWaterBombs = 0;
        totalWaterBombsExploded = 0;
        totalWaterBombsExplodedMedium = 0;
        totalWaterBombsExplodedHard = 0;
        maxWaveWaterBombs = 0;
        highScoreMedium = 0;
        highScoreHard = 0;
        highScoreWaterBombsMedium = 0;
        highScoreWaterBombsHard = 0;
        maxWaveMedium = 0;
        maxWaveHard = 0;
        maxWaveWaterBombsMedium = 0;
        maxWaveWaterBombsHard = 0;
    }

    public void QuitApplication()
    {
        print("Quit");
        Application.Quit();
    }

    public void UpdateTotalZombieKills()
    {
        statistics.UpdateTotalZombieKills(totalZombiesKilled);
    }

    public void UpdateTotalZombieKillsMedium()
    {
        statistics.UpdateTotalZombieKills(totalZombiesKilledMedium);
    }

    public void UpdateTotalZombieKillsHard()
    {
        statistics.UpdateTotalZombieKills(totalZombiesKilledHard);
    }

    public void UpdateTotalWaterBombsExploded()
    {
        statistics.UpdateTotalWaterBombsExploded(totalWaterBombsExploded);
    }

    public void UpdateTotalWaterBombsExplodedMedium()
    {
        statistics.UpdateTotalWaterBombsExploded(totalWaterBombsExplodedMedium);
    }

    public void UpdateTotalWaterBombsExplodedHard()
    {
        statistics.UpdateTotalWaterBombsExploded(totalWaterBombsExplodedHard);
    }

    public void StopSounds()
    {
        audioManager.Stop("InGameBackgroundZombie");
        audioManager.Stop("InGameBackgroundWaterBomb");
        audioManager.Stop("MainMenuBackgroundZombie");
        audioManager.Stop("MainMenuBackgroundWaterBomb");
    }
}
