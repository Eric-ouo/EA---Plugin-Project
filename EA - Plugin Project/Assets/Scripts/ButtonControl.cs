using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Draw drawScript;
    public Eraser eraserScript;
    private Button PencilButton;
    private Button EraserButton;

void Start()
    {
        PencilButton = GameObject.Find("Pencil").GetComponent<Button>();
        EraserButton = GameObject.Find("Eraser").GetComponent<Button>();
        PencilButton.onClick.AddListener(EnableDrawing);
        EraserButton.onClick.AddListener(EnableErasing);
        drawScript.enabled = false;
        eraserScript.enabled = false;
    }
    public void EnableDrawing()
    {
        Debug.Log("trigger");
        drawScript.enabled = true;
        eraserScript.enabled = false;
    }

    public void EnableErasing()
    {
        Debug.Log("trigger");
        drawScript.enabled = false;
        eraserScript.enabled = true;
    }
}