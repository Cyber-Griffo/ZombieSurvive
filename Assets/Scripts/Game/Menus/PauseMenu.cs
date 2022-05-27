using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public Glock glock;
    public WaterGun waterGun;
    public Animator anim;
    public Slider volumeSlider;

    [System.NonSerialized]
    public GameManager gameManager;

    private bool gameIsPaused = false;
    private bool canPress = true;

    ui ui;

    int gameMode;

    void Start()
    {
        gameMode = SaveSystem.LoadDataGameMode().gameModeSave;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ui = GetComponent<ui>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPress && !gameManager.gameIsCurrentlyEnded)
        {
            if (gameIsPaused)
            {
                if (ui.isAYSOn)
                    ui.SetAYSDeactive();
                else if (ui.isShopOn)
                    anim.SetTrigger("hideShop");
                else if (ui.isStatisticsOn)
                    anim.SetTrigger("hideStatistics");
                else
                {
                    anim.SetTrigger("hidePauseMenu");
                    ClearAllTrigger();
                }
            }
            else
            {
                ToggleCanPress();
                anim.SetTrigger("showPauseMenu");
                GetComponent<Settings>().LoadVolumeSave();
            }
        }
	}

    void ClearAllTrigger()
    {
        anim.ResetTrigger("showStatistics");
        anim.ResetTrigger("hideStatistics");
        anim.ResetTrigger("showPauseMenu");
        anim.ResetTrigger("showShop");
        anim.ResetTrigger("hideShop");
        anim.ResetTrigger("showWeaponUpgrade");
        anim.ResetTrigger("showPlayerUpgrade");
    }

    public void Resume()
    {
        if (gameManager.mouseLook.mouseIsVisible)
        {
            gameManager.mouseLook.ToggleCursorMode();
        }

        Time.timeScale = 1f;

        if(!canPress)
            ToggleCanPress();

        ToggleShooting();

        ClearAllTrigger();

        gameIsPaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;

        if (!gameIsPaused)
        {
            ToggleCanPress();
            gameManager.mouseLook.ToggleCursorMode();
            ToggleShooting();
        }

        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        gameManager.LoadScene("MainMenu", 0);
    }

    public void ToggleCanPress()
    {
        canPress = !canPress;
    }

    void ToggleShooting()
    {
        switch (gameMode)
        {
            case 0:

                waterGun.ToggleCanShoot();

                break;
            case 1:

                glock.ToggleCanShoot();

                break;
        }
    }

    public void EndGame()
    {
        gameManager.EndGame();
    }
}
