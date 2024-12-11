using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThresherScript : MonoBehaviour
{
    // Public variables assigned in the Inspector
    public GameObject paddy;           // Paddy object to spawn
    public GameObject stalk;           // Stalk object to spawn
    public Transform paddySpawn;       // Spawn point for paddy
    public Transform stalkSpawn;       // Spawn point for stalk
    public float spawnDelay = 3f;      // Delay between paddy production batches

    // Private variables to handle production logic
    private int spikeletCount = 0;     // Count of collisions with "Spikelet"
    private bool isProducing = false;  // Flag to track if production is active
    private float timeSinceLastBatch = 0f; // Timer to control batch spawning

    void Update()
    {
        // If in production mode and there are spikelets available
        if (isProducing && spikeletCount > 0)
        {
            // Check if it's time to spawn the next batch of paddy
            if (timeSinceLastBatch >= spawnDelay)
            {
                StartCoroutine(ProducePaddyBatch());
                timeSinceLastBatch = 0f; // Reset the timer after spawning
            }

            // Update the timer
            timeSinceLastBatch += Time.deltaTime;
        }
    }

    // Called when the thresher collides with a "Spikelet" object
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the object has the "Spikelet" tag, increment spikelet count
        if (collision.gameObject.CompareTag("Spiklet"))
        {
            spikeletCount++;
            Debug.Log("Spikelet collided " + spikeletCount + " times.");

            // Start production if not already started
            if (!isProducing)
            {
                isProducing = true;
                Debug.Log("Starting production.");
            }
        }
    }

    // Coroutine to spawn paddy and stalks
    IEnumerator ProducePaddyBatch()
    {
        // Spawn 50 paddy
        for (int i = 0; i < 50; i++)
        {
            Instantiate(paddy, paddySpawn.position, paddySpawn.rotation);
        }

        // Spawn 1 to 2 stalks randomly
        int stalksToSpawn = Random.Range(1, 3);
        for (int i = 0; i < stalksToSpawn; i++)
        {
            Instantiate(stalk, stalkSpawn.position, stalkSpawn.rotation);
        }

        // Decrease spikelet count after producing one batch
        spikeletCount--;

        // Wait before allowing the next batch to spawn
        yield return new WaitForSeconds(spawnDelay);

        // Stop production if there are no spikelets left
        if (spikeletCount <= 0)
        {
            isProducing = false;
            Debug.Log("Stopping production.");
        }
    }
}
