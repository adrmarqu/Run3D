using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour, IPointerClickHandler
{
    public enum Id
    {
        level1,
        level2,
        level3
    };

    public Id id;

    private int lvl;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        OnButtonDown();
    }

    public void OnButtonDown()
    {
        lvl = (int)id;

        if (lvl <= LevelSystem.levelUnlocked)
        {
            LevelSystem.level = lvl;
            SceneManager.LoadScene("Game");
        }
    }
}
