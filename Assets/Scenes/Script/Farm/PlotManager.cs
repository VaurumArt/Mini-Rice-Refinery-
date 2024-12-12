using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    public bool isPlanted = false;
    SpriteRenderer plant;
    BoxCollider2D plantCollider;

    public Sprite[] plantStages;
    int plantStage = 0;
    float timeBtwStages = 2f;
    float timer;

    public UIManager uiManager;

    // Added for sack handling
    public GameObject sackPrefab; // A prefab for the sack
    private GameObject sackInstance;

    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantStage < plantStages.Length - 1)
            {
                timer = timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantStage == plantStages.Length - 1)
                Harvest();
        }
        else
        {
            Plant();
        }
        Debug.Log("Clicked");
    }

    void Harvest()
    {
        Debug.Log("Harvest");
        isPlanted = false;
        plant.gameObject.SetActive(false);
        uiManager.Harvest(10);
        uiManager.UpdateSackUI();

        // Inform UIManager to add harvested rice
        if (uiManager != null)
        {
            uiManager.AddRice(1); // Assuming 1 rice per harvest
        }

        // Spawn the sack immediately after harvest
        SpawnSack();
    }

    void SpawnSack()
    {
        // If a sack is already there from a previous harvest, destroy it first
        //if (sackInstance != null)
        //{
        //    Destroy(sackInstance);
        //}

        // Instantiate the sack at the plant's position
        sackInstance = Instantiate(sackPrefab, plant.transform.position, Quaternion.identity);
    }

    void Plant()
    {
        Debug.Log("Planted");
        isPlanted = true;
        plantStage = 0;
        UpdatePlant();
        timer = timeBtwStages;
        plant.gameObject.SetActive(true);
        uiManager.Plants(10);
    }

    void UpdatePlant()
    {
        plant.sprite = plantStages[plantStage];
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0, plant.bounds.size.y / 2);
    }
}
