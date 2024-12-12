using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderScript : MonoBehaviour
{
    [Header("Prefabs and Spawn Points")]
    public GameObject riceFlour; // Assign the rice flour object to spawn in the Inspector
    public Transform riceFlourSpawn; // Assign the spawn point for rice flour in the Inspector

    [Header("Production Settings")]
    public float spawnDelay = 3f;      // Delay between batches
    public float spawnPerItem = 0.1f; // Delay per item spawned
    public int crackRicePerBatch = 50; // Number of collisions needed to start production
    public int minRiceFlour = 100;    // Minimum number of rice flour per batch
    public int maxRiceFlour = 120;    // Maximum number of rice flour per batch

    // Queue to hold production batches for sequential processing
    private Queue<int> productionQueue = new Queue<int>();
    private bool isProcessing = false;

    // Method detects collisions with "CrackRice" tagged objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CrackRice"))
        {
            productionQueue.Enqueue(crackRicePerBatch); // Enqueue a new batch for processing
            Debug.Log($"CrackRice added to queue. Queue size: {productionQueue.Count}");

            // Destroy the CrackRice object after counting
            Destroy(collision.gameObject);

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
            int batchToProcess = productionQueue.Dequeue();
            Debug.Log($"Processing batch. Remaining queue size: {productionQueue.Count}");

            // Produce rice flour
            int flourToSpawn = Random.Range(minRiceFlour, maxRiceFlour + 1);
            Debug.Log($"Spawning {flourToSpawn} rice flour.");
            for (int i = 0; i < flourToSpawn; i++)
            {
                Instantiate(riceFlour, riceFlourSpawn.position, riceFlourSpawn.rotation);
                yield return new WaitForSeconds(spawnPerItem);
            }

            // Wait before processing the next batch
            yield return new WaitForSeconds(spawnDelay);
        }

        isProcessing = false;
        Debug.Log("Finished processing all batches.");
    }
}