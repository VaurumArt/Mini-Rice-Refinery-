using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceMillerScript : MonoBehaviour
{
    [Header("Prefabs and Spawn Points")]
    public GameObject standardRice; // Assign the brown rice object to spawn in the Inspector
    public GameObject bran;         // Assign the husk object to spawn in the Inspector
    public Transform standardRiceSpawn; // Assign the spawn point for brown rice in the Inspector
    public Transform branSpawn;     // Assign the spawn point for husk in the Inspector

    [Header("Production Settings")]
    public float spawnDelay = 3f;      // Delay between batches
    public float spawnPerItem = 0.1f; // Delay per item spawned
    public int brownRicePerBatch = 50; // Number of collisions needed to start production
    public int minStandardRice = 45;  // Minimum number of standard rice per batch
    public int maxStandardRice = 50;  // Maximum number of standard rice per batch
    public int minBran = 120;         // Minimum number of bran per batch
    public int maxBran = 150;         // Maximum number of bran per batch

    // Queue to hold production batches for sequential processing
    private Queue<int> productionQueue = new Queue<int>();
    private bool isProcessing = false;

    // Method detects collisions with "BrownRice" tagged objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BrownRice"))
        {
            productionQueue.Enqueue(brownRicePerBatch); // Enqueue a new batch for processing
            Debug.Log($"BrownRice added to queue. Queue size: {productionQueue.Count}");

            // Destroy the BrownRice object after counting
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

            // Produce standard rice
            int riceToSpawn = Random.Range(minStandardRice, maxStandardRice + 1);
            Debug.Log($"Spawning {riceToSpawn} standard rice.");
            for (int i = 0; i < riceToSpawn; i++)
            {
                Instantiate(standardRice, standardRiceSpawn.position, standardRiceSpawn.rotation);
                yield return new WaitForSeconds(spawnPerItem);
            }

            // Produce bran
            int branToSpawn = Random.Range(minBran, maxBran + 1);
            Debug.Log($"Spawning {branToSpawn} bran.");
            for (int i = 0; i < branToSpawn; i++)
            {
                Instantiate(bran, branSpawn.position, branSpawn.rotation);
                yield return new WaitForSeconds(spawnPerItem);
            }

            // Wait before processing the next batch
            yield return new WaitForSeconds(spawnDelay);
        }

        isProcessing = false;
        Debug.Log("Finished processing all batches.");
    }
}
