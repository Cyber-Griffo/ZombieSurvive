using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour {

    public TMP_Text text;

    public void SetAmmoValue(int ammoCount)
    {
        text.text = (ammoCount + "");
    }
}
