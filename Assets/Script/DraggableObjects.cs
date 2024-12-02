using UnityEngine;

public class DraggableObjects : MonoBehaviour
{
    private bool isDragging = false; // Flag to track if we are dragging
    private Vector3 mouseOffset; // Offset between mouse and object position
    private Camera mainCamera; // Store reference to the Main Camera

    void Start()
    {
        // Ensure that we are using the correct camera
        mainCamera = Camera.main;
    }

    void Update()
    {
        // If the object is being dragged
        if (isDragging)
        {
            // Get the current mouse position in world space using the Main Camera
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // Preserve the Z position of the object, so it doesn't change in depth
            mousePosition.z = transform.position.z; // Ensuring Z is the same as the object's Z

            // Set the object's position to the mouse position
            transform.position = mousePosition + mouseOffset;
        }
    }

    void OnMouseDown()
    {
        // Start dragging the object when mouse is clicked
        isDragging = true;

        // Calculate the offset between the object's position and mouse position
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Keep the same Z position as the object
        mouseOffset = transform.position - mousePosition;
    }

    void OnMouseUp()
    {
        // Stop dragging the object when mouse button is released
        isDragging = false;
    }
}