using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCoins : MonoBehaviour
{
    public Text point;

    private void Start()
    {
        CoinCanvas();
    }

    public void CoinCanvas()
    {
        point.text = "Points: " + CoinSystem.coins;
    }
}
