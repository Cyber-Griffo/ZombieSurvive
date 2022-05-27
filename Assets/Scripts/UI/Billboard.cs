using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [System.NonSerialized]
    public Transform fpv;
    [System.NonSerialized]
    public Transform healthbar;

    private Vector3 position;

    void Awake()
    {
        fpv = GameObject.Find("FPV Cam").transform;
        healthbar = transform.Find("Healthbar");
        position = transform.parent.position - transform.position;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + (fpv.forward * -1));
    }

    void Update()
    {
        transform.position = transform.parent.position - position;
    }
}
