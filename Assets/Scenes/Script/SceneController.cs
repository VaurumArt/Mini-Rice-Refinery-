using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public void GoToMachines()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToFarm()
    {
        SceneManager.LoadScene(0);
    }


}
