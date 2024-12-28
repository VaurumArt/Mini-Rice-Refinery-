using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Farm()
    {
        SceneManager.LoadScene(1);
    }

    public void Machines()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

}
