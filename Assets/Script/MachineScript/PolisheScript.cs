using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolisheScript : MonoBehaviour
{
    public GameObject polishedRice; // Assign the polished rice object to spawn in the Inspector
    public Transform polishedRiceSpawn; // Assign the spawn point for polished rice in the Inspector
    public float spawnDelay = 0.5f; // Delay between spawns while holding space

    private float timeSinceLastSpawn = 0f;
    private int polishedRiceCount = 0; // Counter for polished rice produced

    void Update()
    {
        // Check if the spacebar is held down
        if (Input.GetKey(KeyCode.Space))
        {
            // Check if enough time has passed since the last spawn
            if (timeSinceLastSpawn >= spawnDelay)
            {
                // Spawn 1 polished rice
                PolishedRiceOutput();

                // Increment polished rice count
                polishedRiceCount++;

                // Check if 1 polished rice has been produced
                if (polishedRiceCount >= 1)
                {
                    // Reset polished rice count after producing polished rice
                    polishedRiceCount = 0; // Reset the polished rice count after producing polished rice
                }

                // Reset the time since last spawn
                timeSinceLastSpawn = 0f;
            }
        }

        // Increment the timer by the time that has passed since the last frame
        timeSinceLastSpawn += Time.deltaTime;
    }

    void PolishedRiceOutput()
    {
        // Spawn the polished rice object at the spawnPoint position and rotation
        Instantiate(polishedRice, polishedRiceSpawn.position, polishedRiceSpawn.rotation);
    }
}
