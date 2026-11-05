using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemKeyBoard : MonoBehaviour
{
    public static bool moveMap = false; // Esta variable hara que te muevas, si no esta activada no te moveras

    public float hor { get; private set; } // get para obtener y set para asignar
    public float ver { get; private set; }

    private void Awake()
    {
        moveMap = false;
    }

    void Update()
    {
        hor = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            moveMap = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveMap = false;
        }
    }
}
