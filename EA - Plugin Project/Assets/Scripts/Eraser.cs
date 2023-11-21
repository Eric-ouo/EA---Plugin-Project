using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    public Camera drawCamera;
    public LayerMask lineLayer;  // Set this in the inspector to the layer your lines are on

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Right mouse button to erase
        {
            Vector2 mousePosition = drawCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0f, lineLayer);
            if (hit.collider != null)
            {
                // Destroy the line
                Destroy(hit.collider.gameObject);
            }
        }
    }
}