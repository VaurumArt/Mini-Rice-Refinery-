using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  

    public GameObject machine1;
    public GameObject machine2;
    public GameObject machine3;
    public GameObject machine4;

    [Header("Scrolling Settings")]
    public float scrollSpeed = 20f;       // Speed of the camera movement
    public float edgeThickness = 10f;    // Thickness of the screen edge to trigger movement

    [Header("Camera Bounds")]
    public float minY = 70f; //50 //30 //10  //last machine -10  // Minimum Y boundary for the camera
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

    public void FixedUpdate()
    {
        UpdateCamPosition();
    }

        void UpdateCamPosition()
    {
        // Check the state of the machines and prioritize the most expensive/last machine
        if (machine4.activeSelf)
        {
            minY = -10f;
        }
        else if (machine3.activeSelf)
        {
            minY = 10f;
        }
        else if (machine2.activeSelf)
        {
            minY = 30f;
        }
        else if (machine1.activeSelf)
        {
            minY = 50f;
        }
        else
        {
            minY = 70f;
        }
    }
}

