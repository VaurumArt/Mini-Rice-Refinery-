using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderScript : MonoBehaviour
{
    public GameObject flour; // Assign the flour object to spawn in the Inspector
    public Transform flourSpawn; // Assign the spawn point for flour in the Inspector
    public float spawnDelay = 0.5f; // Delay between spawns while holding space

    private float timeSinceLastSpawn = 0f;
    private int flourCount = 0; // Counter for flour produced

    void Update()
    {
        // Check if the spacebar is held down
        if (Input.GetKey(KeyCode.Space))
        {
            // Check if enough time has passed since the last spawn
            if (timeSinceLastSpawn >= spawnDelay)
            {
                // Spawn 1 flour
                FlourOutput();

                // Increment flour count
                flourCount++;

                // Check if 1 flour has been produced
                if (flourCount >= 1)
                {
                    // Reset flour count after producing flour
                    flourCount = 0; // Reset the flour count after producing flour
                }

                // Reset the time since last spawn
                timeSinceLastSpawn = 0f;
            }
        }

        // Increment the timer by the time that has passed since the last frame
        timeSinceLastSpawn += Time.deltaTime;
    }

    void FlourOutput()
    {
        // Spawn the flour object at the spawnPoint position and rotation
        Instantiate(flour, flourSpawn.position, flourSpawn.rotation);
    }
}
