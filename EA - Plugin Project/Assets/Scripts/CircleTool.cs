using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTool : MonoBehaviour
{

    public float radius = 5f;
    public float lineWidth = 0.2f;
    public int segments = 360;
    public Material lineMaterial;


    public GameObject CreateCircle(Vector3 centerPosition)
    {

        GameObject circleGO = new GameObject("Circle");
        circleGO.transform.position = centerPosition;


        LineRenderer lineRenderer = circleGO.AddComponent<LineRenderer>();


        lineRenderer.material = lineMaterial;


        lineRenderer.positionCount = segments + 1;

        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;


        float deltaTheta = (2f * Mathf.PI) / segments;
        float theta = 0f;

        for (int i = 0; i < segments + 1; i++)
        {
            float x = radius * Mathf.Cos(theta);
            float y = radius * Mathf.Sin(theta);
            Vector3 pos = new Vector3(x, y, 0f) + centerPosition;
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }

        return circleGO; 
    }
}