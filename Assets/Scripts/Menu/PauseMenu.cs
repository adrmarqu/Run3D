using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject[] panels;

    /*
    
    0 --> boton de pausa
    1 --> panel de pausa
    2 --> panel de opciones
    3 --> panel de musica
    4 --> panel de sonido
    5 --> panel de controles
     
    */

    // inicializar

    void Start()
    {
        panels[0].SetActive(true);

        for (int i = 1; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }

        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                PauseToGame();
            }
            else
            {
                GametoPause();
            }
        }
    }

    public void GametoPause()
    {
        panels[0].SetActive(false);
        panels[1].SetActive(true);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void PauseToGame()
    {
        panels[1].SetActive(false);
        panels[0].SetActive(true);
        
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
