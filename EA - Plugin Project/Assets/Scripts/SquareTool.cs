using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareTool : MonoBehaviour
{
    public GameObject squarePrefab;
    private GameObject currentSquare;
    private Vector2 startPosition;

    void Update()
    {
        // Check for the initial click
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentSquare = Instantiate(squarePrefab, startPosition, Quaternion.identity);
            currentSquare.transform.localScale = Vector3.zero; // Start with a scale of zero
        }

        // If the mouse is held down, update the scale of the square
        if (currentSquare != null)
        {
            Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = currentMousePosition - startPosition;
            currentSquare.transform.localScale = new Vector3(direction.x, direction.y, 1);
        }

        // If the mouse is released, finalize the square
        if (Input.GetMouseButtonUp(0) && currentSquare != null)
        {
            currentSquare = null; // Reset the currentSquare
        }
    }
}