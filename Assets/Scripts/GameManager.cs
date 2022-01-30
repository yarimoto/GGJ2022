using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGameOver = false;
    public GameObject gameOverUi;

    // Update is called once per frame
    void Update()
    {
    }

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
}
