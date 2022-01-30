using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGameOver = false;
    public GameObject gameOverUi;
    public GameObject winScreenUi;

    public void SetGameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        gameOverUi.SetActive(true);
    }

    public bool IsInGameOver()
    {
        return isGameOver;
    }

    public void SetLevelDone()
    {
        Time.timeScale = 0f;
        winScreenUi.SetActive(true);
    }
}
