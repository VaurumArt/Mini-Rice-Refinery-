using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    private MoneySystem moneySystem; // Reference to the MoneySystem script

    void Start()
    {
        // Find the MoneySystem in the scene
        moneySystem = FindObjectOfType<MoneySystem>();

        if (moneySystem == null)
        {
            Debug.LogError("MoneySystem not found in the scene!");
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
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("BrownRice"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("CrackRice"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Husk"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Paddy"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("RiceFlour"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Spiklet"))
        {
            moneySystem.AddMoney(5);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Stalk"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("StandardRice"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("PremiumRice"))
        {
            Destroy(collision.gameObject);
        }
    }
}

