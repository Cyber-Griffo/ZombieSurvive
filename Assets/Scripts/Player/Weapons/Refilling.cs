using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refilling : MonoBehaviour
{
    public WaterGun waterGun;
    public Animator anim;

    public void IsRefillingOn()
    {
        waterGun.isRefilling = true;
    }

    public void IsRefillingOff()
    {
        waterGun.isRefilling = false;
    }

    public void PlayAnim(string name, bool value)
    {
        anim.SetBool(name, value);
        GameObject.Find("GameManager").GetComponent<GameManager>().audioManager.Play("Refilling");
    }

    public void RefillTank()
    {
        waterGun.RefillTank();
    }

    public void ResetRefillBool()
    {
        anim.SetBool("refill", false);
    }

    public void SetRefillingTime(float refillingTime)
    {
        anim.SetFloat("speed", refillingTime);
    }

    public void UpdateUI_WaterGun()
    {
        waterGun.tankScript.SetTankValue(waterGun.currentTank);
    }
}