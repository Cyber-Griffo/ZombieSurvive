using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Animator anim;
    public GameManager gameManager;
    public AudioManager audioManager;

    public GameObject settingsMenu;
    public GameObject statisticsMenu;

    [System.NonSerialized]
    public bool settingsIsOn = false;
    [System.NonSerialized]
    public bool statisticsIsOn = false;
    [System.NonSerialized]
    public bool backIsOn = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsMenu.activeInHierarchy || statisticsMenu.activeInHierarchy)
                SetTrigger("back");
        }
    }

    public void SetTrigger(string name)
    {
        if(name == "showSettingsMenu")
        {
            settingsIsOn = true;
        }
        else if(name == "showStatisticsMenu")
        {
            statisticsIsOn = true;
        }
        else if(name == "back")
        {
            settingsIsOn = false;
            statisticsIsOn = false;
        }

        anim.SetTrigger(name);
    }

    public void ResetBack()
    {
        backIsOn = false;
    }

    public void StartGame()
    {
         gameManager.StartGame();
    }

    public void QuitGame()
    {
        gameManager.QuitApplication();
    }

    public void PlaySound(string name)
    {
        audioManager.Play(name);
    }

    public void PlayAnimationInStatistics(string name)
    {
        statisticsMenu.GetComponent<Statistics>().playAnimation(name);
    }
}
