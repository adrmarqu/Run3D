using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeMenu : MonoBehaviour, IPointerClickHandler
{
    public GameObject currentPanel;
    public GameObject nextPanel;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        OnChangePanel();
    }

    public void OnChangePanel()
    {
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
}
