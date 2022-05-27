using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour {

    public AreYouSure ays;
    public GameObject overLay;
    public bool isAYSOn = false;
    public bool isShopOn = false;
    public bool isStatisticsOn = false;
    public bool playerUpgradeVisible = false;
    public bool weaponUpgradeVisible = false;

    public Statistics statistics;
    
    public void fadeTo(string text)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(text);
    }

    public void SetAYSActive(int i)
    {
        ays.SetActionToPerform(i);
        overLay.SetActive(true);
        ays.gameObject.SetActive(true);
        SetAYSIsOn();
    }

    public void SetAYSDeactive()
    {
        ays.gameObject.SetActive(false);
        SetAYSIsOff();
        overLay.SetActive(false);
    }

    public void SetIsShopOn()
    {
        isShopOn = true;
        playerUpgradeVisible = true;
    }

    public void SetIsShopOff()
    {
        isShopOn = false;
    }

    public void SetIsStatisticsOn()
    {
        isStatisticsOn = true;
    }

    public void SetIsStatisticsOff()
    {
        isStatisticsOn = false;
    }

    public void SetPlayerUpgradeVisibleOn()
    {
        playerUpgradeVisible = true;
    }

    public void SetPlayerUpgradeVisibleOff()
    {
        playerUpgradeVisible = false;
    }

    public void SetWeaponUpgradeVisibleOn()
    {
        weaponUpgradeVisible = true;
    }

    public void SetWeaponUpgradeVisibleOff()
    {
        weaponUpgradeVisible = false;
    }

    public void SetAYSIsOn()
    {
        isAYSOn = true;
    }

    public void SetAYSIsOff()
    {
        isAYSOn = false;
    }

    public void ShowPlayerUpgrade()
    {
        if (!playerUpgradeVisible)
        {
            GetComponent<Animator>().SetTrigger("showPlayerUpgrade");
        }
    }

    public void ShowWeaponUpgrade()
    {
        if (!weaponUpgradeVisible)
        {
            GetComponent<Animator>().SetTrigger("showWeaponUpgrade");
        }
    }

    public void PlayAnimationInStatistic(string name)
    {
        statistics.playAnimation(name);
    }
}
