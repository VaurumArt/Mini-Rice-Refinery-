using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GivenSacks : MonoBehaviour
{

    [SerializeField] Text myText;

    public void Start()
    {
        string newText = StaticData.valueToKeep;
        myText.text = newText;
    }

    public void BackToFarm()
    {
        SceneManager.LoadScene(0);
    }


}
