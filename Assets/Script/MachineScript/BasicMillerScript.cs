using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMillerScript : MonoBehaviour
{
    public GameObject brownRice; // Assign the brown rice object to spawn in the Inspector
    public GameObject husk; // Assign the husk object to spawn in the Inspector
    public Transform brownRiceSpawn; // Assign the spawn point for brown rice in the Inspector
    public Transform huskSpawn; // Assign the spawn point for husk in the Inspector
    public float spawnDelay = 3f; // Delay before starting production after reaching 50 Paddy collisions
    public int paddyCollisionCount = 0; // Counter for "Paddy" collisions
    public bool isProducing = false; // Flag to control the production process

    void Update()
    {
        // Production will start after the delay, handled in the coroutine
    }

    // Method to detect collisions with "Paddy" tagged objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddy"))
        {
            paddyCollisionCount++;
            Debug.Log("Paddy collided " + paddyCollisionCount + " times.");

            // Start production only if the collision count reaches exactly 50
            if (paddyCollisionCount >= 50 && !isProducing)
            {
                isProducing = true;
                Debug.Log("Reached 50 Paddy collisions. Starting production after delay.");

                // Start the production process with a 3-second delay
                StartCoroutine(StartProductionAfterDelay());
            }
        }
    }

    IEnumerator StartProductionAfterDelay()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(spawnDelay);

        // Spawn 45 to 50 brown rice
        int riceToSpawn = Random.Range(45, 51);
        for (int i = 0; i < riceToSpawn; i++)
        {
            BrownRiceOutput();
        }

        // Spawn 40 to 60 husk
        int husksToSpawn = Random.Range(40, 61);
        for (int i = 0; i < husksToSpawn; i++)
        {
            HuskOutput();
        }

        // Reset the paddy collision count after production
        paddyCollisionCount -= 50;
        isProducing = false; // Stop production after the batch is done
    }

    void BrownRiceOutput()
    {
        // Spawn the brown rice object at the brownRiceSpawn position and rotation
        Instantiate(brownRice, brownRiceSpawn.position, brownRiceSpawn.rotation);
    }

    void HuskOutput()
    {
        // Spawn the husk object at the huskSpawn position and rotation
        Instantiate(husk, huskSpawn.position, huskSpawn.rotation);
    }
}
