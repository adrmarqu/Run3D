using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializeMenu : MonoBehaviour
{
    public GameObject[] panels;

    void Start()
    {
        panels[0].SetActive(true);
        for (int i = 1; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
    }
}
