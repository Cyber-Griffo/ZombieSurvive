using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfFarAway : MonoBehaviour
{

    private GameObject objectAvtivatorObject;
    private ObjectActivator activationScript;

    // Start is called before the first frame update
    void Start()
    {
        objectAvtivatorObject = GameObject.Find("ObjectActivator");
        activationScript = objectAvtivatorObject.GetComponent<ObjectActivator>();

        StartCoroutine(AddToList());
    }

    IEnumerator AddToList()
    {
        yield return new WaitForSeconds(0.1f);

        activationScript.addList.Add(new ActivatorObject { obj = this.gameObject });
    }
}
