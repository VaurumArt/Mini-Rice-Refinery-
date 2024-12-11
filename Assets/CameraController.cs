using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Scrolling Settings")]
    public float scrollSpeed = 20f;       // Speed of the camera movement
    public float edgeThickness = 10f;    // Thickness of the screen edge to trigger movement

    [Header("Camera Bounds")]
    public float minY = 70f; //50 //last machine -10              // Minimum Y boundary for the camera
    public float maxY = 70f;             // Maximum Y boundary for the camera

    void Update()
    {
        Vector3 newPosition = transform.position;

        // Get mouse position on the screen
        Vector3 mousePosition = Input.mousePosition;

        // Check if the mouse is near the bottom screen edge
        if (mousePosition.y <= edgeThickness)
        {
            newPosition.y -= scrollSpeed * Time.deltaTime;
        }
        // Check if the mouse is near the top screen edge
        else if (mousePosition.y >= Screen.height - edgeThickness)
        {
            newPosition.y += scrollSpeed * Time.deltaTime;
        }

        // Clamp the camera's Y position to the defined boundaries
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // Apply the new position
        transform.position = newPosition;
    }

}

