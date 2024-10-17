using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SackManager : MonoBehaviour
{
    private bool isDragging = false;

    void Update()
    {
        if (isDragging)
        {
            // Move the sack with the mouse position while dragging
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }

    private void OnMouseDown()
    {
        // Start dragging when clicked
        isDragging = true;
        Debug.Log("Sack is being dragged");
    }

    private void OnMouseUp()
    {
        // Stop dragging when the mouse is released
        isDragging = false;
        Debug.Log("Sack dropped");
    }
}
