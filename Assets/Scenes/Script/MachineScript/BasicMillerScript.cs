using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMillerScript : MonoBehaviour
{
    // Public variables assigned in the Inspector
    [Header("Prefabs and Spawn Points")]
    public GameObject brownRice;          // Brown rice prefab to spawn
    public GameObject husk;               // Husk prefab to spawn
    public Transform brownRiceSpawn;      // Spawn point for brown rice
    public Transform huskSpawn;           // Spawn point for husk

    [Header("Production Settings")]
    public float spawnDelay = 3f;         // Delay between batches
    public float spawnPerItem = 0.1f;     // Delay per item spawned
    public int paddyPerBatch = 50;        // Number of collisions needed to start production
    public int minBrownRice = 45;         // Minimum number of brown rice per batch
    public int maxBrownRice = 50;         // Maximum number of brown rice per batch
    public int minHusk = 40;              // Minimum number of husk per batch
    public int maxHusk = 60;              // Maximum number of husk per batch

    // Queue to hold production batches for sequential processing
    private Queue<int> productionQueue = new Queue<int>();
    private bool isProcessing = false;

    // Method detects collisions with "Paddy" tagged objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddy"))
        {
            productionQueue.Enqueue(paddyPerBatch); // Enqueue a new batch for processing
            Debug.Log($"Paddy added to queue. Queue size: {productionQueue.Count}");

            // Start processing if not already active
            if (!isProcessing)
            {
                StartCoroutine(ProcessQueue());
            }
        }
    }

    // Coroutine to process production queue sequentially
    IEnumerator ProcessQueue()
    {
        isProcessing = true;

        while (productionQueue.Count > 0)
        {
            int paddyToProcess = productionQueue.Dequeue();
            Debug.Log($"Processing batch. Remaining queue size: {productionQueue.Count}");

            // Produce brown rice
            int riceToSpawn = Random.Range(minBrownRice, maxBrownRice + 1);
            Debug.Log($"Spawning {riceToSpawn} brown rice.");
            for (int i = 0; i < riceToSpawn; i++)
            {
                Instantiate(brownRice, brownRiceSpawn.position, brownRiceSpawn.rotation);
                yield return new WaitForSeconds(spawnPerItem);
            }

            // Produce husk
            int husksToSpawn = Random.Range(minHusk, maxHusk + 1);
            Debug.Log($"Spawning {husksToSpawn} husks.");
            for (int i = 0; i < husksToSpawn; i++)
            {
                Instantiate(husk, huskSpawn.position, huskSpawn.rotation);
                yield return new WaitForSeconds(spawnPerItem);
            }

            // Wait before processing the next batch
            yield return new WaitForSeconds(spawnDelay);
        }

        isProcessing = false;
        Debug.Log("Finished processing all batches.");
    }
}