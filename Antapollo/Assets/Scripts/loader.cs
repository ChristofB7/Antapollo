 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loader : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(4);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void HowTwo()
    {
        SceneManager.LoadScene(0);
    }

}
