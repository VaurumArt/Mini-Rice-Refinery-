using UnityEngine;

public class ObjectSpawnerAndDragger2D : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign the prefab you want to spawn in the Inspector
    private GameObject spawnedObject; // Reference to the spawned object
    public Transform ObjectSpawn;
    private bool isDragging = false; // Flag to track if we're currently dragging an object

    void Update()
    {
        // Get the mouse position in world space
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // If dragging, keep the object following the mouse
        if (isDragging && spawnedObject != null)
        {
            spawnedObject.transform.position = mousePosition;
        }

        // If the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            if (!isDragging) // If not dragging, spawn and grab the object
            {
                // Spawn the object at the mouse position
                spawnedObject = Instantiate(objectToSpawn, ObjectSpawn.position, Quaternion.identity);
                isDragging = true; // Set the flag to true to start dragging
            }
            else // If dragging, release the object
            {
                isDragging = false; // Stop dragging the object
                spawnedObject = null; // Clear the reference
            }
        }
    }
}

