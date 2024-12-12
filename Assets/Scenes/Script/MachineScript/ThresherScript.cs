using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThresherScript : MonoBehaviour
{
    // Public variables assigned in the Inspector
    public GameObject paddy;               // Paddy object to spawn
    public GameObject stalk;               // Stalk object to spawn
    public Transform paddySpawn;           // Spawn point for paddy
    public Transform stalkSpawn;           // Spawn point for stalk
    public float spawnDelay = 3f;          // Delay between batches
    public float spawnPerPaddy = 0.3f;     // Delay per paddy spawn
    public int paddyPerBatch = 50;         // Number of paddy to spawn per batch
    public int minStalksPerBatch = 1;      // Minimum number of stalks per batch
    public int maxStalksPerBatch = 2;      // Maximum number of stalks per batch
    public float stalkSpawnChance = 0.03f; // Chance to spawn stalks

    // Queue to hold spikelets for sequential processing
    private Queue<int> spikeletQueue = new Queue<int>();
    private bool isProcessing = false;

    // Called when the thresher collides with a "Spikelet" object
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spiklet"))
        {
            spikeletQueue.Enqueue(paddyPerBatch); // Enqueue customizable paddy amount
            Debug.Log($"Spikelet added to queue. Queue size: {spikeletQueue.Count}");

            // Start processing if not already started
            if (!isProcessing)
            {
                StartCoroutine(ProcessQueue());
            }
        }
    }

    // Coroutine to process the queue sequentially
    IEnumerator ProcessQueue()
    {
        isProcessing = true;

        while (spikeletQueue.Count > 0)
        {
            int paddyToProduce = spikeletQueue.Dequeue();
            Debug.Log($"Processing spikelet. Remaining queue size: {spikeletQueue.Count}");

            // Produce paddy one by one with delay
            for (int i = 0; i < paddyToProduce; i++)
            {
                Instantiate(paddy, paddySpawn.position, paddySpawn.rotation);
                yield return new WaitForSeconds(spawnPerPaddy);
            }

            // Spawn stalks based on customizable chance
            if (Random.value <= stalkSpawnChance)
            {
                int stalksToSpawn = Random.Range(minStalksPerBatch, maxStalksPerBatch + 1);
                for (int i = 0; i < stalksToSpawn; i++)
                {
                    Instantiate(stalk, stalkSpawn.position, stalkSpawn.rotation);
                }
                Debug.Log($"{stalksToSpawn} stalk(s) spawned!");
            }

            // Wait before processing the next batch
            yield return new WaitForSeconds(spawnDelay);
        }

        isProcessing = false;
        Debug.Log("Finished processing all spikelets.");
    }
}
