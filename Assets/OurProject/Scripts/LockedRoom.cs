using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedRoom : MonoBehaviour
{

    public string tag;
    public GameObject door;
    private GameObject[] sensedObjects;

    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        sensedObjects = GameObject.FindGameObjectsWithTag(tag);
        if (sensedObjects.Length == 0)
        {
            Destroy(door);
        }
    }
}
