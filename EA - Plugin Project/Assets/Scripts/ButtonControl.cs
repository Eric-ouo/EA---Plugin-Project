using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Draw draw;
    public Eraser eraser;
    public ColorControl colorControl;

    private Button PencilButton;
    private Button EraserButton;
    private Button ColorButton;

    private bool board = true;

    public GameObject colorBoard;
    public GameObject colorBar;

void Start()
    {
        PencilButton = GameObject.Find("Pencil").GetComponent<Button>();
        EraserButton = GameObject.Find("Eraser").GetComponent<Button>();
        ColorButton = GameObject.Find("Color").GetComponent <Button>();

        PencilButton.onClick.AddListener(EnableDrawing);
        EraserButton.onClick.AddListener(EnableErasing);
        ColorButton.onClick.AddListener(BoardAndBarControl);

        draw.enabled = false;
        eraser.enabled = false;

        colorBar.SetActive(false);
    }
    public void EnableDrawing()
    {
        //Debug.Log("trigger");
        draw.enabled = true;
        eraser.enabled = false;
    }

    public void EnableErasing()
    {
        //Debug.Log("trigger");
        draw.enabled = false;
        eraser.enabled = true;
    }

    public void BoardAndBarControl()
    {
        if (board == true)
        {
            colorBoard.SetActive(false);
            colorBar.SetActive(true);
            board = false;
            draw.lineMaterial = colorControl.CustomColor;

        }
        else if(board == false)
        {
            colorBoard.SetActive(true);
            colorBar.SetActive(false);  
            board = true;
        }
    }
}