using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Linq;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour{

    public float volumeSave;
    public int qualitySave;
    public int resolutionsIndexSave;
    public bool fullScreenSave;
    public float mausSensitivitySave;
    public float renderDistanceSave;
    public int difficultySave;
    public int gameModeSave;

    [Header("Rendering")]
    public float minRenderDistance = 50;
    public float maxRenderDistance = 500;

    public Slider volumeSlider;
    public AudioMixer mainMixer;
    public Toggle fullScreenToggle;
    public TMP_Dropdown qualityDropdown;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown gameModeDropdown;
    public TMP_Dropdown difficultyDropdown;
    public Slider mausSensitivitySlider;
    public TMP_InputField mausSensitivityText;
    public Slider renderDistanceSlider;
    public TMP_InputField renderDistanceText;

    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public Mouselook mouselook;

    public GameObject ammo;
    public GameObject tank_weapon;
    public GameObject tank_player;
    public GameObject dry_player;
    public GameObject health;
    public GameObject armor;

    [System.NonSerialized]
    public ObjectActivator objectActivator;
    [System.NonSerialized]
    public bool gameModeLoaded = false;

    Resolution[] sortedRes;

    void Start()
    {
        objectActivator = GameObject.Find("ObjectActivator").GetComponent<ObjectActivator>();

        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            LoadSettings();
        }
        else if(SceneManager.GetActiveScene().name == "MainScene")
        {
            LoadGameModeSave();
            LoadVolumeSave();
            LoadMausSensitivitySave();
            LoadRenderDistanceSave();
            SetUpHUD();
        }
    }

    public void LoadSettings()
    {
        sortedRes = FilterRes(SortRes(Screen.resolutions));

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < sortedRes.Length; i++)
        {

            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(ResToString(sortedRes[i])));

            if (sortedRes[i].width == Screen.currentResolution.width && sortedRes[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
                resolutionsIndexSave = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;

        LoadVolumeSave();
        LoadResolutionSave();
        LoadQualitySave();
        LoadDifficultySave();
        LoadGameModeSave();
        gameModeLoaded = true;
        LoadFullscreenSave();
        LoadMausSensitivitySave();
        LoadRenderDistanceSave();

        RefreshUI();
    }

    void SetUpHUD()
    {
        switch (SaveSystem.LoadDataGameMode().gameModeSave)
        {
            case 0:

                ammo.SetActive(false);
                tank_weapon.SetActive(true);
                tank_player.SetActive(true);
                dry_player.SetActive(true);
                health.SetActive(false);
                armor.SetActive(false);

                break;
            case 1:

                ammo.SetActive(true);
                tank_weapon.SetActive(false);
                tank_player.SetActive(false);
                dry_player.SetActive(false);
                health.SetActive(true);
                armor.SetActive(true);

                break;
        }
    }

    public void LoadVolumeSave()
    {
        SavesDataVolumeSave data = SaveSystem.LoadDataVolumeSave();

        if(data != null)
        {
            volumeSlider.value = data.volumeSave;
            mainMixer.SetFloat("volume", data.volumeSave);
            volumeSave = data.volumeSave;
        }
        else
        {
            print("nix volume");
            volumeSlider.value = 0;
            mainMixer.SetFloat("volume", 0);
            volumeSave = 0f;
            SaveVolumeSave();
        }
    }

    void LoadRenderDistanceSave()
    {
        SavesDataRenderDistanceSave data = SaveSystem.LoadDataRenderDistanceSave();

        if (data != null)
        {
            if (data.renderDistanceSave < minRenderDistance)
                renderDistanceSave = minRenderDistance;
            else if (data.renderDistanceSave > maxRenderDistance)
                renderDistanceSave = Mathf.Infinity;
            else
                renderDistanceSave = data.renderDistanceSave;

            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                renderDistanceSlider.minValue = minRenderDistance;
                renderDistanceSlider.maxValue = maxRenderDistance;

                if (renderDistanceSave == Mathf.Infinity)
                    renderDistanceText.text = "infinte";
                else
                    renderDistanceText.text = renderDistanceSave.ToString();

                renderDistanceSlider.value = renderDistanceSave;
            }

            objectActivator.renderDistance = renderDistanceSave;
        }
        else
        {
            print("nix RenderDistanceSave");
            renderDistanceSave = 250;
            objectActivator.renderDistance = 250f;
            SaveRenderDistanceSave();

            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                renderDistanceSlider.value = 250;
                renderDistanceText.text = 250f.ToString();
            }
        }
    }

    void LoadQualitySave()
    {
        SavesDataQualitySave data = SaveSystem.LoadDataQualitySave();

        if (data != null)
        {
            qualityDropdown.value = data.qualitySave;
            UpdateUI();
            QualitySettings.SetQualityLevel(data.qualitySave);
            qualitySave = data.qualitySave;
        }
        else
        {
            print("nix quality");
            qualityDropdown.value = 3;
            QualitySettings.SetQualityLevel(3);
            qualitySave = 3;
            SaveQualitySave();
        }
    }

    void LoadDifficultySave()
    {
        SaveDataDifficulty data = SaveSystem.LoadDataDifficultySave();

        if (data != null)
        {
            difficultyDropdown.value = data.difficultySave;
            UpdateUI();
            difficultySave = data.difficultySave;
            GameObject.Find("GameManager").GetComponent<GameManager>().diff = difficultySave;
        }
        else
        {
            print("nix difficulty");
            difficultyDropdown.value = 0;
            difficultySave = 0;
            GameObject.Find("GameManager").GetComponent<GameManager>().diff = difficultySave;
            SaveDifficultySave();
        }
    }

    public void LoadGameModeSave()
    {
        SaveDataGameMode data = SaveSystem.LoadDataGameMode();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (data != null)
            {
                gameModeDropdown.value = data.gameModeSave;
                UpdateUI();
                gameModeSave = data.gameModeSave;
                GameObject.Find("GameManager").GetComponent<GameManager>().gameMode = gameModeSave;
            }
            else
            {
                print("nix gameMode");
                gameModeDropdown.value = 1;
                gameModeSave = 1;
                GameObject.Find("GameManager").GetComponent<GameManager>().gameMode = gameModeSave;
                SaveGameModeSave();
            }
        }
        else if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if(data != null)
            {
                gameModeSave = data.gameModeSave;
                GameObject.Find("GameManager").GetComponent<GameManager>().gameMode = gameModeSave;
            }
            else
            {
                print("nix gameMode");
                gameModeSave = 1;
                GameObject.Find("GameManager").GetComponent<GameManager>().gameMode = gameModeSave;
                SaveGameModeSave();
            }
        }
    }

    void LoadResolutionSave()
    {
        SavesDataResolutionSave data = SaveSystem.LoadDataResolutionSave();

        if (data != null)
        {
            resolutionDropdown.value = data.resolutionsIndexSave;
            UpdateUI();
            Screen.SetResolution(sortedRes[data.resolutionsIndexSave].width, sortedRes[data.resolutionsIndexSave].height, Screen.fullScreen);
            resolutionsIndexSave = data.resolutionsIndexSave;
        }
        else
        {
            print("nix resolution");
            resolutionDropdown.value = sortedRes.Length - 1;
            Screen.SetResolution(sortedRes[sortedRes.Length - 1].width, sortedRes[sortedRes.Length - 1].height, Screen.fullScreen);
            resolutionsIndexSave = sortedRes.Length - 1;
            SaveResolutionSave();
        }
    }
    void LoadFullscreenSave()
    {
        SavesDataFullscreenSave data = SaveSystem.LoadDataFullscreenSave();

        if (data != null)
        {
            fullScreenToggle.isOn = data.fullscreenSave;
            Screen.fullScreen = data.fullscreenSave;
            fullScreenSave = data.fullscreenSave;
        }
        else
        {
            print("nix fullscreen");
            fullScreenToggle.isOn = true;
            Screen.fullScreen = true;
            fullScreenSave = true;
            SaveFullscreenSave();
        }
    }

    void LoadMausSensitivitySave()
    {
        SavesDataMausSensitivitySave data = SaveSystem.LoadDataMausSensitivitySave();

        if (data != null && SceneManager.GetActiveScene().name == "MainScene")
        {
            if (data.mausSensitivitySave <= mausSensitivitySlider.minValue)
            {
                mausSensitivitySave = mausSensitivitySlider.minValue;
                print(mausSensitivitySlider.minValue + " min");
            }
            else if (data.mausSensitivitySave >= mausSensitivitySlider.maxValue)
            {
                mausSensitivitySave = mausSensitivitySlider.maxValue;
                print(mausSensitivitySlider.maxValue + " max");
            }
            else
            {
                mausSensitivitySave = data.mausSensitivitySave;
            }
            mausSensitivitySlider.value = mausSensitivitySave;
            mausSensitivityText.text = mausSensitivitySave.ToString();
            mouselook.mouseSensitivity = mausSensitivitySave;
        }
        else if(data == null && SceneManager.GetActiveScene().name == "MainScene")
        {
            print("nix mausSensitivity");
            mausSensitivitySlider.value = 100f;
            mausSensitivityText.text = 100f.ToString();
            mausSensitivitySave = 100;
            mouselook.mouseSensitivity = 100f;
            SaveFullscreenSave();
        }
        else if (data != null && SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (data.mausSensitivitySave <= mausSensitivitySlider.minValue)
            {
                mausSensitivitySave = mausSensitivitySlider.minValue;
            }
            else if (data.mausSensitivitySave >= mausSensitivitySlider.maxValue)
            {
                mausSensitivitySave = mausSensitivitySlider.maxValue;
            }
            else
            {
                mausSensitivitySave = data.mausSensitivitySave;
            }
            mausSensitivitySlider.value = mausSensitivitySave;
            mausSensitivityText.text = mausSensitivitySave.ToString();
        }
        else if (data == null && SceneManager.GetActiveScene().name == "MainMenu")
        {
            print("nix mausSensitivity");
            mausSensitivitySlider.value = 100f;
            mausSensitivityText.text = 100f.ToString();
            mausSensitivitySave = 100;
            SaveFullscreenSave();
        }
    }

    void SaveVolumeSave()
    {
        SaveSystem.SaveDataVolumeSave(volumeSave);
        print("Saved Volume: " + SaveSystem.LoadDataVolumeSave().volumeSave);
    }

    void SaveMausSensitivitySave()
    {
        SaveSystem.SaveDataMausSensitivitySave(mausSensitivitySave);
        print("Saved MausSensi: " + SaveSystem.LoadDataMausSensitivitySave().mausSensitivitySave);
    }

    void SaveQualitySave()
    {
        SaveSystem.SaveDataQualitySave(qualitySave);
        print("Saved Quality: " + SaveSystem.LoadDataQualitySave().qualitySave);
    }

    void SaveResolutionSave()
    {
        SaveSystem.SaveDataResolutionSave(resolutionsIndexSave);
        print("Saved Resolution: " + SaveSystem.LoadDataResolutionSave().resolutionsIndexSave);
    }

    void SaveFullscreenSave()
    {
        SaveSystem.SaveDataFullscreenSave(fullScreenSave);
        print("Saved FullScreen: " + SaveSystem.LoadDataFullscreenSave().fullscreenSave);
    }

    void SaveRenderDistanceSave()
    {
        SaveSystem.SaveDataRenderDistanceSave(renderDistanceSave);
        print("Saved RenderDistance: " + SaveSystem.LoadDataRenderDistanceSave().renderDistanceSave);
    }

    void SaveDifficultySave()
    {
        SaveSystem.SaveDataDifficultySave(difficultySave);
        print("Saved Difficulty: " + SaveSystem.LoadDataDifficultySave().difficultySave);
    }

    void SaveGameModeSave()
    {
        SaveSystem.SaveDataGameMode(gameModeSave);
        print("Saved Difficulty: " + SaveSystem.LoadDataDifficultySave().difficultySave);
    }

    string ResToString(Resolution res)
    {
        return res.width + " x " + res.height + " @ " + res.refreshRate + " Hz";
    }

    public Resolution[] FilterRes(Resolution[] res)
    {
        List<Resolution> sortedResList = new List<Resolution>();

        for(int i = 0; i < res.Length - 1; i++)
        {
            if(!((res[i].height == res[i + 1].height) && (res[i].width == res[i + 1].width)))
            {
                sortedResList.Add(res[i]);
            }
            if((i + 1) == res.Length - 1)
            {
                sortedResList.Add(res[i + 1]);
            }
        }

        return sortedResList.ToArray();
    }

    public Resolution[] SortRes(Resolution[] unsortedRes)
    {
        int grenzeUnten = 0;

        //Sort by Height
        for (int i = 0; i <= unsortedRes.Length - 2; i++)
        {
            for (int j = 0; j <= unsortedRes.Length - 2; j++)
            {
                if (unsortedRes[j].height > unsortedRes[j + 1].height)
                {
                    Resolution temp = unsortedRes[j + 1];
                    unsortedRes[j + 1] = unsortedRes[j];
                    unsortedRes[j] = temp;
                }
            }
        }

        //Sort by Width in Groups with the same Height
        for (int i = 0; i < unsortedRes.Length - 1; i++)
        {
            if (unsortedRes[i].height != unsortedRes[i + 1].height)
            {
                for (int y = grenzeUnten; y < i + 1; y++)
                {
                    for (int j = grenzeUnten; j < i; j++)
                    {
                        if (unsortedRes[j].width > unsortedRes[j + 1].width)
                        {
                            Resolution temp = unsortedRes[j + 1];
                            unsortedRes[j + 1] = unsortedRes[j];
                            unsortedRes[j] = temp;
                        }
                    }
                }
                grenzeUnten = i + 1;
            }
            else if((i + 1) == unsortedRes.Length - 1)
            {
                for (int y = grenzeUnten; y <= i + 1; y++)
                {
                    for (int j = grenzeUnten; j <= i; j++)
                    {
                        if (unsortedRes[j].width > unsortedRes[j + 1].width)
                        {
                            Resolution temp = unsortedRes[j + 1];
                            unsortedRes[j + 1] = unsortedRes[j];
                            unsortedRes[j] = temp;
                        }
                    }
                }
            }
        }
        grenzeUnten = 0;

        //Sort by Refresh Rate in Groups with the same Height
        for (int i = 0; i < unsortedRes.Length - 1; i++)
        {
            if (unsortedRes[i].height != unsortedRes[i + 1].height ||
                unsortedRes[i].width != unsortedRes[i + 1].width)
            {
                for (int y = grenzeUnten; y < i + 1; y++)
                {
                    for (int j = grenzeUnten; j < i; j++)
                    {
                        if (unsortedRes[j].refreshRate > unsortedRes[j + 1].refreshRate)
                        {
                            Resolution temp = unsortedRes[j + 1];
                            unsortedRes[j + 1] = unsortedRes[j];
                            unsortedRes[j] = temp;
                        }
                    }
                }
                grenzeUnten = i + 1;
            }
        }

        return unsortedRes;
    }

    public void SetVolume(float value)
    {
        volumeSlider.value = value;
        mainMixer.SetFloat("volume", value);
        volumeSave = value;
        SaveVolumeSave();
    }

    public void SetMausSensitivityFloat(float _value)
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            float value = (float)Mathf.Round(_value * 100f) / 100f;
            if (value < mausSensitivitySlider.minValue)
            {
                value = mausSensitivitySlider.minValue;
            }
            else if (value > mausSensitivitySlider.maxValue)
            {
                value = mausSensitivitySlider.maxValue;
            }
            mausSensitivitySlider.value = value;
            mausSensitivityText.text = value.ToString();
            mausSensitivitySave = value;
            SaveMausSensitivitySave();
        }
        else if (SceneManager.GetActiveScene().name == "MainScene")
        {
            float value = (float)Mathf.Round(_value * 100f) / 100f;
            if (value < mausSensitivitySlider.minValue)
            {
                value = mausSensitivitySlider.minValue;
            }
            else if (value > mausSensitivitySlider.maxValue)
            {
                value = mausSensitivitySlider.maxValue;
            }
            mausSensitivitySlider.value = value;
            mausSensitivityText.text = value.ToString();
            mouselook.mouseSensitivity = value;
            mausSensitivitySave = value;
            SaveMausSensitivitySave();
        }
    }

    public void SetMausSensitivityString(string _value)
    {
        if (SceneManager.GetActiveScene().name == "MainMenu" && settingsMenu.activeInHierarchy)
        {
            float value = (float)Mathf.Round(float.Parse(_value) * 100f) / 100f;
            if(value < mausSensitivitySlider.minValue)
            {
                value = mausSensitivitySlider.minValue;
            }
            else if(value > mausSensitivitySlider.maxValue)
            {
                value = mausSensitivitySlider.maxValue;
            }
            mausSensitivitySlider.value = value;
            mausSensitivityText.text = value.ToString();
            mausSensitivitySave = value;
            SaveMausSensitivitySave();
        }
        else if(SceneManager.GetActiveScene().name == "MainScene" && pauseMenu.activeInHierarchy)
        {
            float value = (float)Mathf.Round(float.Parse(_value) * 100f) / 100f;
            if (value < mausSensitivitySlider.minValue)
            {
                value = mausSensitivitySlider.minValue;
            }
            else if (value > mausSensitivitySlider.maxValue)
            {
                value = mausSensitivitySlider.maxValue;
            }
            mausSensitivitySlider.value = value;
            mausSensitivityText.text = value.ToString();
            mouselook.mouseSensitivity = value;
            mausSensitivitySave = value;
            SaveMausSensitivitySave();
        }
    }

    public void SetRenderDistanceFloat(float _value)
    {
        float value = (float)Mathf.Round(_value * 100f) / 100f;
        if (value < renderDistanceSlider.minValue)
        {
            value = renderDistanceSlider.minValue;
        }
        else if (value >= renderDistanceSlider.maxValue)
        {
            value = Mathf.Infinity;
        }
        renderDistanceSlider.value = value;

        if (value == Mathf.Infinity)
            renderDistanceText.text = "infinte";
        else
            renderDistanceText.text = value.ToString();

        renderDistanceSave = value;
        objectActivator.renderDistance = renderDistanceSave;
        SaveRenderDistanceSave();
    }

    public void SetRenderDistanceString(string _value)
    {
        if (settingsMenu.activeInHierarchy)
        {
            float value = (float)Mathf.Round(float.Parse(_value) * 100f) / 100f;
            if (value < renderDistanceSlider.minValue)
            {
                value = renderDistanceSlider.minValue;
            }
            else if (value >= renderDistanceSlider.maxValue)
            {
                value = Mathf.Infinity;
            }
            renderDistanceSlider.value = value;
            renderDistanceText.text = value.ToString();
            renderDistanceSave = value;
            objectActivator.renderDistance = renderDistanceSave;
            SaveRenderDistanceSave();
        }
    }

    public void SetFullScreen(bool _fullScreen)
    {
        if (settingsMenu.activeInHierarchy)
        {
            fullScreenSave = _fullScreen;
            Screen.fullScreen = _fullScreen;
            fullScreenToggle.isOn = _fullScreen;
            SaveFullscreenSave();
        }
    }

    public void SetQuality(int qualityIndex)
    {
        if (settingsMenu.activeInHierarchy)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
            qualityDropdown.value = qualityIndex;
            qualitySave = qualityIndex;
            qualityDropdown.RefreshShownValue();
            SaveQualitySave();
        }
    }

    public void SetDifficulty(int value)
    {
        difficultyDropdown.value = value;
        difficultySave = value;
        GameObject.Find("GameManager").GetComponent<GameManager>().diff = difficultySave;
        difficultyDropdown.RefreshShownValue();
        SaveDifficultySave();
    }

    public void SetGameMode(int value)
    {
        gameModeDropdown.value = value;
        gameModeSave = value;
        GameObject.Find("GameManager").GetComponent<GameManager>().gameMode = gameModeSave;
        gameModeDropdown.RefreshShownValue();
        SaveGameModeSave();
    }

    public void SetResolution(int resolutionIndex)
    {
        if (settingsMenu.activeInHierarchy)
        {
            Screen.SetResolution(sortedRes[resolutionIndex].width, sortedRes[resolutionIndex].height, Screen.fullScreen);
            resolutionDropdown.value = resolutionIndex;
            resolutionsIndexSave = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            SaveResolutionSave();
        }
    }

    void RefreshUI()
    {
        resolutionDropdown.RefreshShownValue();
        qualityDropdown.RefreshShownValue();
        difficultyDropdown.RefreshShownValue();
        gameModeDropdown.RefreshShownValue();
    }

    public void UpdateUI()
    {
        resolutionDropdown.value = resolutionsIndexSave;
        qualityDropdown.value = qualitySave;
        volumeSlider.value = volumeSave;
        fullScreenToggle.isOn = fullScreenSave;
        difficultyDropdown.value = difficultySave;
        gameModeDropdown.value = gameModeSave;

        RefreshUI();
    }
}
