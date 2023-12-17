using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillScreen : MonoBehaviour
{
    public Camera mainCamera; // Assign this through the inspector or find it via code
    public Draw draw;

    private void Update()
    {
            Material selectedMaterial = GetSelectedMaterial();
            FillWithMaterial(selectedMaterial);
    }

    public void FillWithMaterial(Material materialToFill)
    {
        // This assumes you have a reference to the main camera
        mainCamera.backgroundColor = materialToFill.color;
        mainCamera.clearFlags = CameraClearFlags.SolidColor;
    }

    // Call this method when you want to fill the screen with the selected color
    public void ApplyFillColor()
    {
        Material selectedMaterial = GetSelectedMaterial();
        FillWithMaterial(selectedMaterial);
    }

    private Material GetSelectedMaterial()
    {
        // This method should return the selected Material from your material picker.
        // For this example, let's assume you have a reference to the selected Material.
        Material selectedMaterial = draw.lineMaterial;
        return selectedMaterial;
    }
}