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

        _reset = _level.GetComponent<ResetLevel>();
        _control = _level.GetComponent<LevelController>();

        numLevels = _control.GetNumLevels();

        levelPanel[0].SetActive(false);
        levelPanel[1].SetActive(false);
        levelPanel[2].SetActive(false);
    }

    public void activePanel()
    {
        PauseMenu.GameIsPaused = true;
        canvasInGame.SetActive(false);

        if (LevelSystem.level == LevelSystem.levelUnlocked)
        {
            LevelSystem.levelUnlocked = LevelSystem.level + 1;
        }

        if (LevelSystem.level < numLevels)
        {
            levelPanel[0].SetActive(true);
        }
        else
        {
            levelPanel[1].SetActive(true);
        }
        Debug.Log("Nivel compleatdo: " + LevelSystem.level + " Nivel desbloqueado: " + LevelSystem.levelUnlocked);
    }

    public void nextLevel()
    {
        levelPanel[0].SetActive(false);
        canvasInGame.SetActive(true);

        _control.NextLevel();

        PauseMenu.GameIsPaused = false;
    }

    public void restartLevel()
    {
        levelPanel[0].SetActive(false);
        levelPanel[1].SetActive(false);
        canvasInGame.SetActive(true);

        _reset.RestartLevel();

        PauseMenu.GameIsPaused = false;
    }

    public void ExitLevel()
    {
        levelPanel[0].SetActive(false);
        levelPanel[1].SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    public void deathPanel()
    {
        PauseMenu.GameIsPaused = true;
        canvasInGame.SetActive(false);
        levelPanel[2].SetActive(true);
    }
}
