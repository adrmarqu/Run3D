using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    // Para salir de la aplicación

    public void ExitButton()
    {
        Application.Quit();
    }

    // Para salir de la partida e ir al menu

    public void ExitGameButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
