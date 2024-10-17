using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderScript : MonoBehaviour
{
    public GameObject RiceFlour; // Assign the brown rice object to spawn in the Inspector
  
    public Transform RiceFlourSpawn; // Assign the spawn point for brown rice in the Inspector
  
    public float spawnDelay = 3f; // Delay before starting production after reaching 50 BrownRice collisions
    public int standradRCollisionCount = 0; // Counter for "BrownRice" collisions
    public bool isProducing = false; // Flag to control the production process

    void Update()
    {
        // Production will start after the delay, handled in the coroutine
    }

    // Method to detect collisions with "BrownRice" tagged objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CrackRice"))
        {
            standradRCollisionCount++;
          
            Destroy(collision.gameObject);

            // Start production only if the collision count reaches exactly 50
            if (standradRCollisionCount >= 50 && !isProducing)
            {
                isProducing = true;
                Debug.Log("Reached 50 FlourRice collisions. Starting production after delay.");

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
        int flourToSpawn = Random.Range(100,120);
        for (int i = 0; i < flourToSpawn; i++)
        {
            StandardRiceOutput();
        }
        // Reset the brown rice collision count after production
        standradRCollisionCount -= 50;
        isProducing = false; // Stop production after the batch is done
    }

    void StandardRiceOutput()
    {
        Instantiate(RiceFlour, RiceFlourSpawn.position, RiceFlourSpawn.rotation);
    }

   
}
