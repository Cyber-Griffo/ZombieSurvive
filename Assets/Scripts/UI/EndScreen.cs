using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour {

    public Animator anim;
    public GameObject endScreen;
    public GameObject statistics;

    ui ui;

    void Start()
    {
        ui = GetComponent<ui>();
    }

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (endScreen.activeInHierarchy || (GameObject.Find("GameManager").GetComponent<GameManager>().gameIsCurrentlyEnded && statistics.activeInHierarchy)))
        {
            if (ui.isAYSOn)
                ui.SetAYSDeactive();
            else if (ui.isStatisticsOn)
            {
                anim.SetTrigger("hideStatistics");
            }
        }
    }

}
