using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour {

    //Maussensitivität
    public float mouseSensitivity = 100f;

    //Kamera initialisierung
    [Header("Cams")]
    public GameObject fpv;

    //Weapon Holds
    [Header("Weapon Holds")]
    public GameObject rightHand;
    public GameObject leftHand;

    [Header("Weapons")]
    public GameObject glock;
    public GameObject waterGun;

    [System.NonSerialized]
    public bool mouseIsVisible = false;

    float xRotation = 0f;
    bool cursorVisible = true;
    bool isInRightHand;

    int gameMode;

    public void SetUpGuns(int gm)
    {
        glock.transform.position = rightHand.transform.position;
        glock.transform.SetParent(rightHand.transform);

        waterGun.transform.position = rightHand.transform.position;
        waterGun.transform.SetParent(rightHand.transform);

        isInRightHand = true;
    }

    // Update is called once per frame
    void Update ()
    {
        //Maus Input erkennen
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (isInRightHand)
            {
                glock.transform.SetParent(leftHand.transform);
                glock.transform.position = leftHand.transform.position;
                waterGun.transform.SetParent(leftHand.transform);
                waterGun.transform.position = leftHand.transform.position;
                isInRightHand = false;
            }
            else
            {
                glock.transform.SetParent(rightHand.transform);
                glock.transform.position = rightHand.transform.position;
                waterGun.transform.SetParent(rightHand.transform);
                waterGun.transform.position = rightHand.transform.position;
                isInRightHand = true;
            }
        }

        //Maus Input
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        fpv.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Spieler drehen
        transform.Rotate(Vector3.up * mouseX);
	}

    public void ToggleCursorMode()
    {
        cursorVisible = !cursorVisible;
        if (!cursorVisible)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            mouseIsVisible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mouseIsVisible = true;
        }
    }

    public void LookAtPoint(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}
