using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    public MainMenu mainMenu;
    public Settings settings;
    public Animator anim;
    public AudioManager audioManager;
    public Statistics statistic;

    private void Start()
    {
        audioManager = GameObject.Find("GameManager").GetComponent<GameManager>().audioManager;

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            statistic = GameObject.Find("UI").GetComponentInChildren<Statistics>();
        }
    }

    public void SetTriggerInMainMenu(string name)
    {
        if (name == "showSettingsMenu" && !mainMenu.settingsIsOn)
            mainMenu.SetTrigger(name);
        else if (name == "showStatisticsMenu" && !mainMenu.statisticsIsOn)
            mainMenu.SetTrigger(name);
        else if (name == "back" && !mainMenu.backIsOn)
        {
            mainMenu.backIsOn = true;
            mainMenu.SetTrigger(name);
        }
    }

    public void Quit()
    {
        mainMenu.QuitGame();
    }

    public void StartGame()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().StartGame();
    }

    public void SetBool(string name)
    {
        anim.SetBool(name, true);
    }

    public void UnSetBool(string name)
    {
        anim.SetBool(name, false);
    }

    public void PlaySound(string name)
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
            audioManager.Play(name);
    }

    public void StopSound(string name)
    {
        audioManager.Stop(name);
    }

    public void GetDiffLeft()
    {
        statistic.UpdateNextDiffToLookAt(0);

        statistic.playAnimation("left");
    }

    public void GetDiffRight()
    {
        statistic.UpdateNextDiffToLookAt(1);

        statistic.playAnimation("right");
    }

    public void DisableAll()
    {
        statistic.currentDiffLookingAt = 0;
        statistic.UpdateDifficultyText();
    }
}
