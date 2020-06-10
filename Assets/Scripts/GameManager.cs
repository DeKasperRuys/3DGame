using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool pauseGame = false;

    private void Start()
    {
    }

    public void GameOver()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void ToggleTime()
    {
        pauseGame = !pauseGame;

        if (pauseGame)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

}