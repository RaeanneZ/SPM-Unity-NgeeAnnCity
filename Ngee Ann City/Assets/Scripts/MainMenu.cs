using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayNewArcadeGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void PlayNewFreePlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame()
    {
        // Shut down the application
        Application.Quit();
    }
}
