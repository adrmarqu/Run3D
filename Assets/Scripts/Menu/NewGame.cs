using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class NewGame : MonoBehaviour, IPointerClickHandler
{
    public GameObject panelConfirmation;

    void Start()
    {
        panelConfirmation.SetActive(false);
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        NewGameButton();
    }

    public void NewGameButton()
    {
        if (LevelSystem.levelUnlocked > 0)
        {
            panelConfirmation.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
}
