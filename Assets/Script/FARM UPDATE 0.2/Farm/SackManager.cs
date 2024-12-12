using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SackManager : MonoBehaviour
{
    FarmManager fm;

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

    private void Start()
    {
        if (fm == null)
        {
            fm = FindObjectOfType<FarmManager>();
            if (fm == null)
            {
                Debug.LogError("FarmManager not found in the scene!");
            }
        }
    }


    //private void OnMouseDown()
    //{
    //    fm.NumberOfHarvestRice(1);
    //    Destroy(gameObject);
    //    // Start dragging when clicked
    //    //isDragging = true;
    //    //Debug.Log("Sack is being dragged");
    //}

    private void OnMouseDown()
    {
        if (gameObject == null)
        {
            Debug.LogError("GameObject is null!");
            return;
        }

        fm.NumberOfHarvestRice(1);
        Debug.Log("Destroying Sack: " + gameObject.name);
        Destroy(gameObject);
    }


    //private void OnMouseUp()
    //{
    //    // Stop dragging when the mouse is released
    //    isDragging = false;
    //    Debug.Log("Sack dropped");
    //}
}
