using UnityEngine;

public class Draw : MonoBehaviour
{
    public Camera drawCamera;
    public Material lineMaterial;
    public float lineWidth = 0.1f;

    private GameObject line;
    private LineRenderer lineRenderer;
    private int pointsCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (line != null)
            {
                line = null;  // Reset the line when the mouse is pressed
                pointsCount = 0;  // Reset the points count
            }

            line = new GameObject("Line");
            lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = lineMaterial;
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;
            lineRenderer.useWorldSpace = true;
            lineRenderer.positionCount = 1;
            pointsCount++;
            Vector3 mousePosition = drawCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            lineRenderer.SetPosition(0, mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = drawCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            lineRenderer.positionCount = pointsCount + 1;
            lineRenderer.SetPosition(pointsCount, mousePosition);
            pointsCount++;
        }
    }
}