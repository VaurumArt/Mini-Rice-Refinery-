using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThresherScript : MonoBehaviour
{
    public GameObject paddy; // Assign the object to spawn in the Inspector
    public GameObject stalk; // Assign the stalk object to spawn in the Inspector
    public Transform paddySpawn; // Assign the spawn point for paddy in the Inspector
    public Transform stalkSpawn; // Assign the spawn point for stalk in the Inspector
    public float spawnDelay = 3f; // Delay between each batch of paddy
    
    public int SpikletCount = 10; // Required collisions to start production

    public int collisionCount = 0; // Count of collisions with "Spiklet"
    public bool isProducing = false; // Flag to track if the machine is producing
    private int totalSpawnedPaddy = 0; // Track how much paddy has been spawned
    private float timeSinceLastBatch = 0f; // Timer to track the time since the last batch

    void Update()
    {
        // If the machine is producing and there are still collisions counted
        if (isProducing && collisionCount > 0)
        {
            // Check if enough time has passed since the last batch
            if (timeSinceLastBatch >= spawnDelay)
            {
                // Produce a batch of paddy
                StartCoroutine(ProducePaddyBatch());

                // Reset the timer for the next batch
                timeSinceLastBatch = 0f;
            }

            // Increment the timer by the time that has passed since the last frame
            timeSinceLastBatch += Time.deltaTime;
        }
    }

    // Method is called when another object with a collider enters the trigger
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Log the name of the object that collided to debug
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // Check if the colliding object is tagged "Spiklet"
        if (collision.gameObject.CompareTag("Spiklet"))
        {
            // Increment the collision count
            collisionCount++;
            Debug.Log("Spiklet collided " + collisionCount + " times.");

            // Check if production should start
            if (!isProducing)
            {
                isProducing = true;
                Debug.Log("Production started.");
            }
        }
    }

    // Coroutine to produce paddy and stalks
    IEnumerator ProducePaddyBatch()
    {
        // Produce 50 paddy
        for (int i = 0; i < 50; i++)
        {
            // Spawn the paddy at the spawnPoint position and rotation
            Instantiate(paddy, paddySpawn.position, paddySpawn.rotation);
            totalSpawnedPaddy++;
        }

        // Spawn 1 to 2 stalks
        int stalksToSpawn = Random.Range(1, 3); // Randomly choose between 1 or 2 stalks
        for (int i = 0; i < stalksToSpawn; i++)
        {
            // Spawn the stalk at the stalkSpawn position and rotation
            Instantiate(stalk, stalkSpawn.position, stalkSpawn.rotation);
        }

        // Decrement the collision count after producing paddy
        collisionCount--;

        // Wait for the spawn delay before the next batch
        yield return new WaitForSeconds(spawnDelay);

        // Stop production if the collision count reaches zero
        if (collisionCount <= 0)
        {
            isProducing = false;
            Debug.Log("Production stopped, no more collisions.");
        }
    }
}
