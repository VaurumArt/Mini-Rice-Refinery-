using UnityEngine;

public class DraggableObjects : MonoBehaviour
{
    private bool isDragging = false;

    void Update()
    {
        // If the object is being dragged
        if (isDragging)
        {
            // Get the mouse position in world space with proper Z-axis handling for 2D
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            // Set the object's position to the mouse position
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }

    void OnMouseDown()
    {
        isDragging = true; // Start dragging the object
    }

    void OnMouseUp()
    {
        isDragging = false; // Stop dragging the object
    }
}
