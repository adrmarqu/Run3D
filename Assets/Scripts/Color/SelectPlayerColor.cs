using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPlayerColor : SelectColorSystem, IPointerClickHandler
{
    void Start()
    {
        _canvas = panelColor.GetComponent<CanvasCoins>();
        _change = character.GetComponent<ChangeColor>();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        OnButtonDown();
    }

    public void OnButtonDown()
    {
        index = (int)id;

        if (CoinSystem.coins >= price)
        {
            _canvas.CoinCanvas();

            PutColor();
        }
    }

    void PutColor()
    {
        ColorSystem.indexPlayerColor = index;
        _change.ChangeColorCharacter(index);
    }
}
