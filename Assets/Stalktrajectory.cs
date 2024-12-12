using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalktrajectory : MonoBehaviour
{
    // Speed at which the object will fly
    public float speed = 5.0f;

    // Direction in which the object will fly
    public Vector3 direction = Vector3.forward;

    private void Start()
    {
        // Normalize the direction vector to ensure it has a length of 1
        direction = direction.normalized;

        // Start flying
        StartCoroutine(Fly());
    }

    private IEnumerator Fly()
    {
        while (true)
        {
            // Move the object in the specified direction at the specified speed
            transform.Translate(direction * speed * Time.deltaTime);

            // Wait for the next frame
            yield return null;
        }
    }
}
