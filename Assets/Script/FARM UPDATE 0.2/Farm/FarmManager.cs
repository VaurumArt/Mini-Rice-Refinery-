using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{

    public PlantItem selectedPlant;
    public bool isPlanting = false;
    public int money = 50;
    public Text moneyTxt;
    public int harvestRice = 0;
    public Text harvestTxt;

    // Start is called before the first frame update
    void Start()
    {
        moneyTxt.text = "Coin " + money;
        harvestTxt.text = " " + harvestRice;
 
    }


    public void SelectedPlant(PlantItem newPlant)
    {
        if(selectedPlant == newPlant)
        {
            Debug.Log("Deselected" + selectedPlant.plant.plantName);
            selectedPlant = null;
            isPlanting = false;
        }
        else
        {
            selectedPlant = newPlant;
            Debug.Log("selected" + selectedPlant.plant.plantName);
            isPlanting = true;
        }
    }

    public void Transaction(int value)
    {
        money += value;
        moneyTxt.text = "$" + money;
    }

    public void NumberOfHarvestRice(int value)
    {
        harvestRice += value;
        harvestTxt.text = " " + harvestRice;
    }

}
