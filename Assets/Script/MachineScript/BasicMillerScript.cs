using System.Collections;
using UnityEngine;

public class BasicMillerScript : MonoBehaviour
{
    // Public variables assigned in the Inspector
    public GameObject brownRice;          // Brown rice prefab to spawn
    public GameObject husk;               // Husk prefab to spawn
    public Transform brownRiceSpawn;      // Spawn point for brown rice
    public Transform huskSpawn;           // Spawn point for husk
    public float spawnDelay = 3f;         // Delay before production starts after 50 paddy collisions

    // Private variables for production logic
    private int paddyCollisionCount = 0;  // Tracks number of "Paddy" collisions
    private bool isProducing = false;     // Controls if the production process is running

    // Method detects collisions with "Paddy" tagged objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddy"))
        {
            paddyCollisionCount++;  // Increment collision count
            Debug.Log("Paddy collided " + paddyCollisionCount + " times.");

            // Start production when 50 paddy collisions are reached
            if (paddyCollisionCount >= 50 && !isProducing)
            {
                isProducing = true;  // Prevent further triggers during production
                Debug.Log("50 Paddy collisions reached. Starting production.");
                StartCoroutine(StartProductionAfterDelay());  // Start production process
            }
        }
    }

    // Coroutine handles production after a delay
    IEnumerator StartProductionAfterDelay()
    {
        // Wait for the specified delay before starting production
        yield return new WaitForSeconds(spawnDelay);

        // Produce 45 to 50 brown rice
        int riceToSpawn = Random.Range(45, 51);
        for (int i = 0; i < riceToSpawn; i++)
        {
            SpawnBrownRice();
        }

        // Produce 40 to 60 husk
        int husksToSpawn = Random.Range(40, 61);
        for (int i = 0; i < husksToSpawn; i++)
        {
            SpawnHusk();
        }

        // Reset the collision count for the next production cycle
        paddyCollisionCount -= 50;
        isProducing = false;  // Allow future production after the batch is done
    }

    // Spawn the brown rice at the designated spawn point
    void SpawnBrownRice()
    {
        Instantiate(brownRice, brownRiceSpawn.position, brownRiceSpawn.rotation);
    }

    // Spawn the husk at the designated spawn point
    void SpawnHusk()
    {
        Instantiate(husk, huskSpawn.position, huskSpawn.rotation);
    }
}
