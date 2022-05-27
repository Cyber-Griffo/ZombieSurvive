using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloading : MonoBehaviour
{
    public Glock glock;
    public Animator anim;

    public void ToggleIsReloading()
    {
        glock.isReloading = !glock.isReloading;
    }

    public void PlayAnim(string name, bool value)
    {
        anim.SetBool(name, value);
        GameObject.Find("GameManager").GetComponent<GameManager>().audioManager.Play("Reloading");
    }

    public void RefillAmmo()
    {
        glock.RefillAmmo();
    }

    public void ResetReloadBool()
    {
        anim.SetBool("reload", false);
    }

    public void SetReloadingTime(float reloadingTime)
    {
        anim.SetFloat("speed", reloadingTime);
    }

    public void UpdateUI()
    {
        glock.ammoScript.SetAmmoValue(glock.currentAmmo);
    }
}