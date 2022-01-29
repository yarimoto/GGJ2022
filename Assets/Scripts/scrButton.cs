using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrButton : MonoBehaviour
{
    public void GoToLevel()
    {
        SceneManager.LoadScene("Level01");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
