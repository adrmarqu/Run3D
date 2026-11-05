using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Jugar un nuevo juego

    public void loadNewGame()
    {
        LevelSystem.level = 0;
        LevelSystem.levelUnlocked = 0;
        CoinSystem.coins = 0;
        SceneManager.LoadScene("Game");
    }

    // Continuar un juego

    public void loadGame()
    {
        LevelSystem.level = LevelSystem.levelUnlocked;
        SceneManager.LoadScene("Game");
    }

    // Ir a los creditos

    public void loadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
