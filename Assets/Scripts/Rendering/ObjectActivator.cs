using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ObjectActivator : MonoBehaviour
{
    public float renderDistance;

    private GameObject player;

    private List<ActivatorObject> activatorObjects;
    public List<ActivatorObject> addList;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            renderDistance = SaveSystem.LoadDataRenderDistanceSave().renderDistanceSave;
        }

        player = GameObject.FindGameObjectWithTag("Player");
        activatorObjects = new List<ActivatorObject>();
        addList = new List<ActivatorObject>();

        AddToList();
    }

    void AddToList()
    {
        if(addList.Count > 0)
        {
            foreach(ActivatorObject obj in addList)
            {
                if(obj.obj != null)
                    activatorObjects.Add(obj); 
            }

            addList.Clear();
        }

        StartCoroutine("CheckActivation");
    }

    IEnumerator CheckActivation()
    {
        List<ActivatorObject> removeList = new List<ActivatorObject>();

        if(activatorObjects.Count > 0)
        {
            foreach(ActivatorObject obj in activatorObjects)
            {
                if (obj.obj == null)
                {
                    removeList.Add(obj);
                }
                else
                {
                    if (Vector3.Distance(player.transform.position, obj.obj.transform.position) > renderDistance)
                        try
                        {
                            obj.obj.GetComponent<MeshRenderer>().enabled = false;
                        }
                        catch
                        {
                            obj.obj.GetComponent<Canvas>().enabled = false;
                        }
                    else
                        try
                        {
                            obj.obj.GetComponent<MeshRenderer>().enabled = true;
                        }
                        catch
                        {
                            obj.obj.GetComponent<Canvas>().enabled = true;
                        }
                }
            }

            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.01f);

        if(removeList.Count > 0)
        {
            foreach(ActivatorObject obj in removeList)
            {
                activatorObjects.Remove(obj);
            }
        }

        yield return new WaitForSeconds(0.01f);

        AddToList();
    }
}

public class ActivatorObject
{
    public GameObject obj;
}
