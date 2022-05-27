using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tank : MonoBehaviour {

    public TMP_Text text;

    public void SetTankValue(int tankAmount)
    {
        text.text = (tankAmount + "");
    }
}
