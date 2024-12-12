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
    public Vector3 machine4Position; // Position when Machine 3 is enabled

    // References to the machines
    public GameObject machine1;
    public GameObject machine2;
    public GameObject machine3;
    public GameObject machine4;

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
            moneySystem.AddMoney(5);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("BrownRice"))
        {
            moneySystem.AddMoney(5);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("CrackRice"))
        {
            moneySystem.AddMoney(5);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Husk"))
        {
            moneySystem.AddMoney(5);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Paddy"))
        {
            moneySystem.AddMoney(5);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("RiceFlour"))
        {
            moneySystem.AddMoney(5);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Spiklet"))
        {
            moneySystem.AddMoney(5);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Stalk"))
        {
            moneySystem.AddMoney(5);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("StandardRice"))
        {
            moneySystem.AddMoney(5);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("PremiumRice"))
        {
            moneySystem.AddMoney(5);
            Destroy(collision.gameObject);
        }
    }
}

