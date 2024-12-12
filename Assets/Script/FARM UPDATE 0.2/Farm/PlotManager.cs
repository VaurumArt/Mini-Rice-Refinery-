using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    public bool isPlanted = false;
    SpriteRenderer plant;
    BoxCollider2D plantCollider;

    int plantStage = 0;
    float timer;

    PlantObject selectedPlant;

    FarmManager fm;

    //public UIManager uiManager;

    // Added for sack handling
    public GameObject sackPrefab; // A prefab for the sack
    private GameObject sackInstance;

    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        fm = transform.parent.GetComponent<FarmManager>();
    }

    void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
            {
                timer = selectedPlant.timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantStage == selectedPlant.plantStages.Length - 1)
                Harvest();
        }
        else if(fm.isPlanting && fm.selectedPlant.plant.buyPrice <= fm.money)
        {
            Plant(fm.selectedPlant.plant);
        }
        Debug.Log("Clicked");
    }

    void Harvest()
    {
        Debug.Log("Harvest");
        isPlanted = false;
        plant.gameObject.SetActive(false);
        fm.Transaction(selectedPlant.sellPrice);

        //uiManager.Harvest(10);
        //uiManager.UpdateSackUI();

        // Inform UIManager to add harvested rice
       // if (uiManager != null)
       // {
       //     uiManager.AddRice(1); // Assuming 1 rice per harvest
       // }

        // Spawn the sack immediately after harvest
        SpawnSack();
    }

    void SpawnSack()
    {
        // Adjust the spawn position to be slightly below the plant
        Vector3 spawnPosition = plant.transform.position;
        spawnPosition.y -= 1.3f; // Adjust the value as needed for your game

        // Instantiate the sack at the adjusted position
        sackInstance = Instantiate(sackPrefab, spawnPosition, Quaternion.identity);
    }


    //void SpawnSack()
    //{
    //    // If a sack is already there from a previous harvest, destroy it first
    //    //if (sackInstance != null)
    //    //{
    //    //    Destroy(sackInstance);
    //    //}

    //    // Instantiate the sack at the plant's position
    //    sackInstance = Instantiate(sackPrefab, plant.transform.position, Quaternion.identity);
    //}

    void Plant(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        Debug.Log("Planted");
        isPlanted = true;

        fm.Transaction(-selectedPlant.buyPrice);

        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwStages;
        plant.gameObject.SetActive(true);
        //uiManager.Plants(10);
    }

    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0, plant.bounds.size.y / 2);
    }
}
