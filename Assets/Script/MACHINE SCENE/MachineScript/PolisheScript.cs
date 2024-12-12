using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolisheScript : MonoBehaviour
{
    [Header("Prefabs and Spawn Points")]
    public GameObject premiumRice; // Assign the premium rice object to spawn in the Inspector
    public GameObject crackRice;   // Assign the crack rice object to spawn in the Inspector
    public Transform premiumRiceSpawn; // Assign the spawn point for premium rice in the Inspector
    public Transform crackRiceSpawn;   // Assign the spawn point for crack rice in the Inspector

    [Header("Production Settings")]
    public float spawnDelay = 3f;      // Delay between batches
    public float spawnPerItem = 0.1f; // Delay per item spawned
    public int standardRicePerBatch = 50; // Number of collisions needed to start production
    public int minPremiumRice = 45;   // Minimum number of premium rice per batch
    public int maxPremiumRice = 50;   // Maximum number of premium rice per batch
    public int minCrackRice = 32;     // Minimum number of crack rice per batch
    public int maxCrackRice = 60;     // Maximum number of crack rice per batch

    // Queue to hold production batches for sequential processing
    private Queue<int> productionQueue = new Queue<int>();
    private bool isProcessing = false;

    // Method detects collisions with "StandardRice" tagged objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("StandardRice"))
        {
            productionQueue.Enqueue(standardRicePerBatch); // Enqueue a new batch for processing
            Debug.Log($"StandardRice added to queue. Queue size: {productionQueue.Count}");

            // Destroy the StandardRice object after counting
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

            // Produce premium rice
            int riceToSpawn = Random.Range(minPremiumRice, maxPremiumRice + 1);
            Debug.Log($"Spawning {riceToSpawn} premium rice.");
            for (int i = 0; i < riceToSpawn; i++)
            {
                Instantiate(premiumRice, premiumRiceSpawn.position, premiumRiceSpawn.rotation);
                yield return new WaitForSeconds(spawnPerItem);
            }

            // Produce crack rice
            int crackToSpawn = Random.Range(minCrackRice, maxCrackRice + 1);
            Debug.Log($"Spawning {crackToSpawn} crack rice.");
            for (int i = 0; i < crackToSpawn; i++)
            {
                Instantiate(crackRice, crackRiceSpawn.position, crackRiceSpawn.rotation);
                yield return new WaitForSeconds(spawnPerItem);
            }

            // Wait before processing the next batch
            yield return new WaitForSeconds(spawnDelay);
        }

        isProcessing = false;
        Debug.Log("Finished processing all batches.");
    }
}
