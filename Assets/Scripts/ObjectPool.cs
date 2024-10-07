using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject Prerefab;
    public int InitialObjectNumber = 30;

    private List<GameObject> objs;

    private void Start()
    {
        objs = new List<GameObject>();

        for (int i = 0; i<InitialObjectNumber; i++)
        {
            GameObject go = Instantiate(Prerefab, transform);
            go.SetActive(false);
            objs.Add(go);
        }
    }

    public GameObject GetObject()
    {
        foreach (GameObject go in objs)
        {
            if (!go.activeSelf)
            {
                go.SetActive(true);
                return go;
            }
        }
        
        GameObject obj = Instantiate(Prerefab, transform);
        objs.Add(obj);
        return obj;
    }
}
