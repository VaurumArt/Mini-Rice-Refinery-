using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    private MoneySystem moneySystem; // Reference to the MoneySystem script

    // Define positions for the floor based on the enabled machine
    public Vector3 defaultPosition; // Default position of the floor
    public Vector3 machine1Position; // Position when Machine 1 is enabled
    public Vector3 machine2Position; // Position when Machine 2 is enabled
    public Vector3 machine3Position; // Position when Machine 3 is enabled
    public Vector3 machine4Position; // Position when Machine 4 is enabled

    // References to the machines
    public GameObject machine1;
    public GameObject machine2;
    public GameObject machine3;
    public GameObject machine4;

    // Prices for each item type
    [Header("Item Prices")]
    public int branPrice = 5;
    public int brownRicePrice = 5;
    public int crackRicePrice = 5;
    public int huskPrice = 5;
    public int paddyPrice = 5;
    public int riceFlourPrice = 5;
    public int spikletPrice = 5;
    public int stalkPrice = 5;
    public int standardRicePrice = 5;
    public int premiumRicePrice = 5;

    void Start()
    {
        // Find the MoneySystem in the scene
        moneySystem = FindObjectOfType<MoneySystem>();

        if (moneySystem == null)
        {
            Debug.LogError("MoneySystem not found in the scene!");
        }

        // Set the floor to its default position at the start
        transform.position = defaultPosition;
    }

    public void FixedUpdate()
    {
        UpdateFloorPosition();
    }

    void UpdateFloorPosition()
    {
        // Check the state of the machines and prioritize the most expensive/last machine
        if (machine4.activeSelf)
        {
            transform.position = machine4Position;
        }
        else if (machine3.activeSelf)
        {
            transform.position = machine3Position;
        }
        else if (machine2.activeSelf)
        {
            transform.position = machine2Position;
        }
        else if (machine1.activeSelf)
        {
            transform.position = machine1Position;
        }
        else
        {
            transform.position = defaultPosition;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the object has already collided, do nothing
        if (collision.gameObject.CompareTag("Processed"))
            return;

        // Mark the object as processed by giving it a "Processed" tag
        collision.gameObject.tag = "Processed";

        if (collision.gameObject.CompareTag("Bran"))
        {
            moneySystem.AddMoney(branPrice);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("BrownRice"))
        {
            moneySystem.AddMoney(brownRicePrice);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("CrackRice"))
        {
            moneySystem.AddMoney(crackRicePrice);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Husk"))
        {
            moneySystem.AddMoney(huskPrice);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Paddy"))
        {
            moneySystem.AddMoney(paddyPrice);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("RiceFlour"))
        {
            moneySystem.AddMoney(riceFlourPrice);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Spiklet"))
        {
            moneySystem.AddMoney(spikletPrice);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Stalk"))
        {
            moneySystem.AddMoney(stalkPrice);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("StandardRice"))
        {
            moneySystem.AddMoney(standardRicePrice);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("PremiumRice"))
        {
            moneySystem.AddMoney(premiumRicePrice);
            Destroy(collision.gameObject);
        }
    }
}