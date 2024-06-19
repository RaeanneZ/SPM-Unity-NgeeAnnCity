using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PlayArcade()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void GoMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}