using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillScreen : MonoBehaviour
{
    public Camera mainCamera; // Assign this through the inspector or find it via code

    public void FillWithColor(Color colorToFill)
    {
        // This assumes you have a reference to the main camera
        mainCamera.backgroundColor = colorToFill;
        mainCamera.clearFlags = CameraClearFlags.SolidColor;
    }

    // Call this method when you want to fill the screen with the selected color
    public void ApplyFillColor()
    {
        // Assuming you have a method to retrieve the selected color
        Color selectedColor = GetSelectedColor();
        FillWithColor(selectedColor);
    }

    private Color GetSelectedColor()
    {
        // This method should return the color you've picked with your color picker.
        // For this example, let's return a random color.
        return new Color(Random.value, Random.value, Random.value);
    }
}