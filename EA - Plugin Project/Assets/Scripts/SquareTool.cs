using UnityEngine;

public class SquareTool : MonoBehaviour
{
    public float radius; 
    public float lineWidth = 0.1f; 
    public int segments = 4; 
    public Draw draw; 
    public CircleTool circleTool;
    public NoDrawArea noDrawArea; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            radius = circleTool.radius;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            CreateSquare(mousePosition);
        }
    }

    public GameObject CreateSquare(Vector3 centerPosition)
    {
        if (noDrawArea != null && noDrawArea.IsInsideNoDrawArea(centerPosition))
        {
            return null;
        }

        GameObject squareGO = new GameObject("Square");
        LineRenderer lineRenderer = squareGO.AddComponent<LineRenderer>();
        squareGO.tag = "line";
        lineRenderer.material = draw.lineMaterial;

        lineRenderer.positionCount = segments + 1; 

        lineRenderer.startWidth = draw.lineWidth;
        lineRenderer.endWidth = draw.lineWidth;

        Vector3[] points = new Vector3[segments + 1];

        points[0] = new Vector3(centerPosition.x - radius, centerPosition.y - radius, centerPosition.z); // Bottom left
        points[1] = new Vector3(centerPosition.x - radius, centerPosition.y + radius, centerPosition.z); // Top left
        points[2] = new Vector3(centerPosition.x + radius, centerPosition.y + radius, centerPosition.z); // Top right
        points[3] = new Vector3(centerPosition.x + radius, centerPosition.y - radius, centerPosition.z); // Bottom right
        points[4] = points[0]; // Close the square by returning to the start point

        lineRenderer.SetPositions(points);

        BoxCollider2D boxCollider = squareGO.AddComponent<BoxCollider2D>();
        Vector2 colliderSize = new Vector2(radius * 2, radius * 2);
        boxCollider.size = colliderSize;
        return squareGO;
    }
}
