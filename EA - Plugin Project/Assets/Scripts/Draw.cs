using UnityEngine;

public class Draw : MonoBehaviour
{
    public Camera drawCamera;
    public Material lineMaterial;
    public float lineWidth = 0.1f;
    private GameObject line;
    public LineRenderer lineRenderer;
    private Collider2D lineCollider;
    private const string LineTag = "line";
    public NoDrawArea noDrawArea; // Reference to the NoDrawArea script

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (noDrawArea.IsInsideNoDrawArea(Input.mousePosition)) // Check if mouse position is inside the no draw area
            {
                Debug.Log("trigger");
                return; // Do not create a new line if inside the no draw area
            }

            line = new GameObject("Line");
            line.tag = LineTag;
            lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = lineMaterial;
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;
            lineRenderer.useWorldSpace = true;
            lineRenderer.positionCount = 0; // Set initial position count to 0

            lineCollider = line.AddComponent<PolygonCollider2D>(); // Add PolygonCollider2D component
        }
        else if (Input.GetMouseButton(0))
        {
            if (line == null)
            {
                return; // Exit the function if there is no active line
            }

            Vector3 mousePosition = drawCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

            if (noDrawArea.IsInsideNoDrawArea(mousePosition)) // Check if the new point is inside the no draw area
            {
                return; // Do not add the point to the line if inside the no draw area
            }

            lineRenderer.positionCount++; // Increase position count
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, mousePosition); // Set position for the newly added point

            UpdateLineCollider(); // Update the line collider
        }
    }

    private void UpdateLineCollider()
    {
        if (lineRenderer == null || lineRenderer.positionCount == 0)
        {
            return;
        }

        Vector2[] colliderPoints = new Vector2[lineRenderer.positionCount];
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            colliderPoints[i] = lineRenderer.GetPosition(i);
        }

        ((PolygonCollider2D)lineCollider).points = colliderPoints;

        // Set the first point of the line to match the new position
        lineRenderer.SetPosition(0, lineRenderer.GetPosition(0));
    }
}