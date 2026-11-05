using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectPlayerColor : SelectColorSystem, IPointerClickHandler
{
    void Start()
    {
        if (panelColor != null)
        {
            _canvas = panelColor.GetComponent<CanvasCoins>();
        }
        if (character != null)
        {
            _change = character.GetComponent<ChangeColor>();
        }
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
            CoinSystem.coins -= price;

            if (_canvas != null)
            {
                _canvas.CoinCanvas();
            }

            PutColor();
        }
    }

    void PutColor()
    {
        ColorSystem.indexPlayerColor = index;
        if (_change != null)
        {
            Text _textPrice = transform.Find("Puntos").GetComponent<Text>();

            _change.ChangeColorCharacter(index);
            price = 0;
            _textPrice.text = "";
        }
    }
}
