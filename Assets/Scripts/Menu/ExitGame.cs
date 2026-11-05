using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        // En WebGL no se puede cerrar la pestana del navegador desde el juego,
        // por lo que ocultamos el boton Exit para que no cause problemas.
        Transform exitBtn = transform.Find("Exit");
        if (exitBtn != null)
        {
            exitBtn.gameObject.SetActive(false);
        }
#endif
    }

    // Para salir de la aplicacion
    public void ExitButton()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        // En WebGL Application.Quit() cuelga el canvas.
        // Recargamos el menu para evitar que se quede pillado.
        SceneManager.LoadScene("Menu");
#else
        Application.Quit();
#endif
    }

    // Para salir de la partida e ir al menu
    public void ExitGameButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
