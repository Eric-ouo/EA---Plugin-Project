using UnityEngine;

public class Draw : MonoBehaviour
{
    public Camera drawCamera;
    public Material lineMaterial;
    public float lineWidth = 0.1f;

    private GameObject line;
    private LineRenderer lineRenderer;
    private Collider2D lineCollider;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            line = new GameObject("Line");
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
            Vector3 mousePosition = drawCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
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