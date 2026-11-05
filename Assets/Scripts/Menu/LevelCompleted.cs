using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    public GameObject[] levelPanel;   // Panel de canvas cuando acabas un nivel o mueres
    public GameObject canvasInGame;   // Panel donde estan los seguidores, las monedas y la pausa
    /*
     
    0 - Panel acabar nivel
    1 - Panel acabar ultimo nivel
    2 - Panel muerte
     
     */

    private GameObject _level;
    private ResetLevel _reset;
    private LevelController _control;

    private int numLevels;

    private void Start()
    {
        _level = GameObject.FindGameObjectWithTag("levelController");

        if (_level != null)
        {
            _reset = _level.GetComponent<ResetLevel>();
            _control = _level.GetComponent<LevelController>();
            if (_control != null)
            {
                numLevels = _control.GetNumLevels();
            }
        }

        if (levelPanel != null)
        {
            for (int i = 0; i < levelPanel.Length; i++)
            {
                if (levelPanel[i] != null)
                {
                    levelPanel[i].SetActive(false);
                }
            }
        }
    }

    public void activePanel()
    {
        PauseMenu.GameIsPaused = true;
        if (canvasInGame != null)
        {
            canvasInGame.SetActive(false);
        }

        if (LevelSystem.level == LevelSystem.levelUnlocked)
        {
            LevelSystem.levelUnlocked = LevelSystem.level + 1;
        }

        if (levelPanel != null)
        {
            if (LevelSystem.level < numLevels)
            {
                if (levelPanel.Length > 0 && levelPanel[0] != null)
                {
                    levelPanel[0].SetActive(true);
                }
            }
            else
            {
                if (levelPanel.Length > 1 && levelPanel[1] != null)
                {
                    levelPanel[1].SetActive(true);
                }
            }
        }
        Debug.Log("Nivel compleatdo: " + LevelSystem.level + " Nivel desbloqueado: " + LevelSystem.levelUnlocked);
    }

    public void nextLevel()
    {
        InputSystemKeyBoard.moveMap = false;
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;

        if (levelPanel != null && levelPanel.Length > 0 && levelPanel[0] != null)
        {
            levelPanel[0].SetActive(false);
        }
        if (canvasInGame != null)
        {
            canvasInGame.SetActive(true);
        }

        if (_control != null)
        {
            _control.NextLevel();
        }
    }

    public void restartLevel()
    {
        InputSystemKeyBoard.moveMap = false;
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;

        if (levelPanel != null)
        {
            for (int i = 0; i < levelPanel.Length; i++)
            {
                if (levelPanel[i] != null)
                {
                    levelPanel[i].SetActive(false);
                }
            }
        }
        if (canvasInGame != null)
        {
            canvasInGame.SetActive(true);
        }

        if (_reset != null)
        {
            _reset.RestartLevel();
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void ExitLevel()
    {
        InputSystemKeyBoard.moveMap = false;
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;

        if (levelPanel != null)
        {
            for (int i = 0; i < levelPanel.Length; i++)
            {
                if (levelPanel[i] != null)
                {
                    levelPanel[i].SetActive(false);
                }
            }
        }
        SceneManager.LoadScene("Menu");
    }

    public void deathPanel()
    {
        PauseMenu.GameIsPaused = true;
        if (canvasInGame != null)
        {
            canvasInGame.SetActive(false);
        }
        if (levelPanel != null && levelPanel.Length > 2 && levelPanel[2] != null)
        {
            levelPanel[2].SetActive(true);
        }
    }
}
