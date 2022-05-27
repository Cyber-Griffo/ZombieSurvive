using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreYouSure : MonoBehaviour {

    public Animator anim;
    public ui ui;

    public int whatActionToPerform;

    public void SetActionToPerform(int i)
    {
        whatActionToPerform = i;
    }

    public void SetTrigger(string text)
    {
        if(whatActionToPerform == 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().QuitApplication();
        }
        else if(whatActionToPerform == 1)
        {
            ui.gameObject.GetComponent<Animator>().SetTrigger("fadeOut");
        }
    }

    public void SetAYSDeactive()
    {
        ui.SetAYSDeactive();
    }  

    public void SetAYSIsOn()
    {
        ui.SetAYSIsOn();
    }

    public void SetAYSIsOff()
    {
        ui.SetAYSIsOff();
    }
}
