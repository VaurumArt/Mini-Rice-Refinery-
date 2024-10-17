using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceMillerScript : MonoBehaviour
{
    public GameObject standardRice; // Assign the brown rice object to spawn in the Inspector
    public GameObject bran; // Assign the husk object to spawn in the Inspector
    public Transform standardRiceSpawn; // Assign the spawn point for brown rice in the Inspector
    public Transform branSpawn; // Assign the spawn point for husk in the Inspector
    public float spawnDelay = 3f; // Delay before starting production after reaching 50 BrownRice collisions
    public int brownRCollisionCount = 0; // Counter for "BrownRice" collisions
    public bool isProducing = false; // Flag to control the production process

    void Update()
    {
        // Production will start after the delay, handled in the coroutine
    }

    // Method to detect collisions with "BrownRice" tagged objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BrownRice"))
        {
            brownRCollisionCount++;
           

            // Destroy the BrownRice object after counting
            Destroy(collision.gameObject);

            // Start production only if the collision count reaches exactly 50
            if (brownRCollisionCount >= 50 && !isProducing)
            {
                isProducing = true;
                Debug.Log("Reached 50 BrownRice collisions. Starting production after delay.");

                // Start the production process with a 3-second delay
                StartCoroutine(StartProductionAfterDelay());
            }
        }
    }

    IEnumerator StartProductionAfterDelay()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(spawnDelay);

        // Spawn 45 to 50 standard rice
        int riceToSpawn = Random.Range(45, 51);
        for (int i = 0; i < riceToSpawn; i++)
        {
            StandardRiceOutput();
        }

        // Spawn 120 to 150 bran
        int branToSpawn = Random.Range(120, 151);
        for (int i = 0; i < branToSpawn; i++)
        {
            BranOutput();
        }

        // Reset the brown rice collision count after production
        brownRCollisionCount -= 50;
        isProducing = false; // Stop production after the batch is done
    }

    void StandardRiceOutput()
    {
        Instantiate(standardRice, standardRiceSpawn.position, standardRiceSpawn.rotation);
    }

    void BranOutput()
    {
        Instantiate(bran, branSpawn.position, branSpawn.rotation);
    }
}
