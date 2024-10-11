using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceMillerScript : MonoBehaviour
{
    public GameObject whiteRice; // Assign the white rice object to spawn in the Inspector
    public GameObject brokenRice; // Assign the broken rice object to spawn in the Inspector
    public Transform whiteRiceSpawn; // Assign the spawn point for white rice in the Inspector
    public Transform brokenRiceSpawn; // Assign the spawn point for broken rice in the Inspector
    public float spawnDelay = 0.5f; // Delay between spawns while holding space

    private float timeSinceLastSpawn = 0f;
    private int riceCount = 0; // Counter for white rice spawned

    void Update()
    {
        // Check if the spacebar is held down
        if (Input.GetKey(KeyCode.Space))
        {
            // Check if enough time has passed since the last spawn
            if (timeSinceLastSpawn >= spawnDelay)
            {
                // Spawn 1 white rice
                WhiteRiceOutput();

                // Increment rice count
                riceCount++;

                // Check if 1 white rice has been spawned
                if (riceCount >= 1)
                {
                    // Spawn 1-2 broken rice for every white rice produced
                    int brokenRiceToSpawn = Random.Range(1, 2); // Randomly choose between 1 or 2 broken rice
                    for (int i = 0; i < brokenRiceToSpawn; i++)
                    {
                        BrokenRiceOutput();
                    }

                    // Reset white rice count after spawning broken rice
                    riceCount = 0; // Reset the rice count after spawning broken rice
                }

                // Reset the time since last spawn
                timeSinceLastSpawn = 0f;
            }
        }

        // Increment the timer by the time that has passed since the last frame
        timeSinceLastSpawn += Time.deltaTime;
    }

    void WhiteRiceOutput()
    {
        // Spawn the white rice object at the spawnPoint position and rotation
        Instantiate(whiteRice, whiteRiceSpawn.position, whiteRiceSpawn.rotation);
    }

    void BrokenRiceOutput()
    {
        // Spawn the broken rice object at the spawnPoint position and rotation
        Instantiate(brokenRice, brokenRiceSpawn.position, brokenRiceSpawn.rotation);
    }
}
