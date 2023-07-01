using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public GameObject[] objects;

    public void DisableObjects()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }

    public void EnableObjects()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
        }
    }
}
