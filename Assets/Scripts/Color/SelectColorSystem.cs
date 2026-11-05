using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectColorSystem : MonoBehaviour
{
    public GameObject panelColor;
    public GameObject character;

    public enum Id
    {
        colorWhite,
        colorBlack,
        colorYellow,
        colorRed,
        colorGreen,
        colorBlue,
        colorCyan,
        colorOrange,
        colorPink
    };

    public Id id;

    public int price;

    [Header("No hace falta llenar")]
    public CanvasCoins _canvas;
    public ChangeColor _change;
    public int index;
}
