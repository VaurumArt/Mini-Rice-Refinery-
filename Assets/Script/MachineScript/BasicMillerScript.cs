using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMillerScript : MonoBehaviour
{
    public GameObject brownRice; // Assign the brown rice object to spawn in the Inspector
    public GameObject husk; // Assign the husk object to spawn in the Inspector
    public Transform brownRiceSpawn; // Assign the spawn point for brown rice in the Inspector
    public Transform huskSpawn; // Assign the spawn point for husk in the Inspector
    public float spawnDelay = 0.5f; // Delay between spawns while holding space

    private float timeSinceLastSpawn = 0f;
    private int riceCount = 0; // Counter for brown rice spawned

    void Update()
    {
        // Check if the spacebar is held down
        if (Input.GetKey(KeyCode.Space))
        {
            // Check if enough time has passed since the last spawn
            if (timeSinceLastSpawn >= spawnDelay)
            {
                // Spawn brown rice
                BrownRiceOutput();

                // Increment rice count
                riceCount++;

                // Check if 50 brown rice have been spawned
                if (riceCount >= 1)
                {
                    // Spawn 1-2 husk for every brown rice produced
                    int husksToSpawn = Random.Range(1, 2); // Randomly choose 1 or 2 husks
                    for (int i = 0; i < husksToSpawn; i++)
                    {
                        HuskOutput();
                    }

                    // Reset brown rice count after spawning husks
                    riceCount = 0; // Reset the rice count after spawning husks
                }

                // Reset the time since last spawn
                timeSinceLastSpawn = 0f;
            }
        }

        // Increment the timer by the time that has passed since the last frame
        timeSinceLastSpawn += Time.deltaTime;
    }

    void BrownRiceOutput()
    {
        // Spawn the brown rice object at the spawnPoint position and rotation
        Instantiate(brownRice, brownRiceSpawn.position, brownRiceSpawn.rotation);
    }

    void HuskOutput()
    {
        // Spawn the husk object at the spawnPoint position and rotation
        Instantiate(husk, huskSpawn.position, huskSpawn.rotation);
    }
}
