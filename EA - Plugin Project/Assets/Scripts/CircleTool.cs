using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTool : MonoBehaviour
{
    public float radius = 0.5f;
    public float lineWidth;
    public int segments = 360;
    public Draw draw;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CreateCircle(mousePosition);
        }
    }

    public GameObject CreateCircle(Vector2 centerPosition)
    {
        GameObject circleGO = new GameObject("Circle");
        circleGO.transform.position = centerPosition;

        LineRenderer lineRenderer = circleGO.AddComponent<LineRenderer>();

        lineRenderer.material = draw.lineMaterial;

        lineRenderer.positionCount = segments + 1;

        lineRenderer.startWidth = draw.lineWidth;
        lineRenderer.endWidth = draw.lineWidth;

        float deltaTheta = (2f * Mathf.PI) / segments;
        float theta = 0f;

        for (int i = 0; i < segments + 1; i++)
        {
            float x = radius * Mathf.Cos(theta);
            float y = radius * Mathf.Sin(theta);
            Vector2 pos = new Vector2(x, y) + centerPosition;
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }

        CircleCollider2D circleCollider = circleGO.AddComponent<CircleCollider2D>();
        circleCollider.radius = radius;

        return circleGO;
    }
}
