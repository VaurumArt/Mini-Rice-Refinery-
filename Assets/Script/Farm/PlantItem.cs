using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObject plant;

    public Text nameTxt;
    public Text priceTxt;
    public Image icon;

    FarmManager fm;

    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
        InitialUI();
    }

    public void BuyPlant()
    {
        Debug.Log("Bought" + plant.name);
        fm.SelectedPlant(this);
    }

    void InitialUI()
    {
        nameTxt.text = plant.plantName;
        priceTxt.text = "$" + plant.buyPrice;
        icon.sprite = plant.icon;
    }

}
