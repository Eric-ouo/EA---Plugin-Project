using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTool : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    private LineRenderer lineRenderer;
    public float lineWidth;
    public Draw draw;
    public NoDrawArea noDrawArea;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (noDrawArea.IsInsideNoDrawArea(Input.mousePosition)) // Check if mouse position is inside the no draw area
            {
                return; // Do not create a new line if inside the no draw area
            }
            // Set the start position of the line
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosition.z = 0f;

            // Create a new game object to hold the line renderer
            GameObject lineObject = new GameObject("Line");
            lineObject.tag = "line";
            lineWidth = draw.lineWidth;

            // Add a line renderer component to the game object
            lineRenderer = lineObject.AddComponent<LineRenderer>();
            lineRenderer.material = draw.lineMaterial;
            lineRenderer.positionCount = 2;
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;

            // Set the positions of the line renderer
            lineRenderer.SetPosition(0, startPosition);
            lineRenderer.SetPosition(1, startPosition); // Set the end position to start position initially
        }
        else if (Input.GetMouseButton(0))
        {
            // Check if the end position is inside the no draw area
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePosition.z = 0f;

            if (noDrawArea.IsInsideNoDrawArea(currentMousePosition))
            {
                // Delete the line object
                return;
            }
            else
            {
                // Set the end position of the line renderer
                lineRenderer.SetPosition(1, currentMousePosition);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Check if the end position is inside the no draw area
            if (noDrawArea.IsInsideNoDrawArea(endPosition))
            {
                // Delete the line object
                return;
            }
        }
    }
}