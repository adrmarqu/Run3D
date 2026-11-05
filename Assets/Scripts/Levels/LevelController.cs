using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject[] gameLevels;

    private int lastLevel;
    
    private ResetLevel _reset;

    private void Awake()
    {
        _reset = GetComponent<ResetLevel>();
    }

    private void Start()
    {
        lastLevel = gameLevels.Length - 1;

        for (int i = 0; i < gameLevels.Length; i++)
        {
            gameLevels[i].SetActive(false);
        }
        gameLevels[LevelSystem.level].SetActive(true);
    }

    // Esta funcion pasa al siguiente nivel

    public void NextLevel()
    {
        if (LevelSystem.level < lastLevel)  // Si no es el ultimo nivel
        {
            gameLevels[LevelSystem.level].SetActive(false);

            LevelSystem.level++;

            resetLevel();
        }
    }

    // Esta funcion es del god mode

    public void changeLevel(int lvl)
    {
        LevelSystem.level = lvl;
        
        for (int i = 0; i < gameLevels.Length; i++)
        {
            gameLevels[i].SetActive(false);
        }

        resetLevel();
    }

    void resetLevel()
    {
        _reset.RestartLevel();
    }

    public int GetNumLevels()
    {
        return gameLevels.Length - 1;
    }
}
