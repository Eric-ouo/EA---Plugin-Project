using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Draw draw;
    public Eraser eraser;
    public DrawControl drawControl;
    public CircleTool circleTool;
    public SquareTool squareTool;
    public FillScreen fillscreen;
    private Button PencilButton;
    private Button EraserButton;
    private Button FillButton;
    private Button CircleButton;
    private Button SquareButton;
    //private Button LineButton;
    private Button ColorButton;
    private Color fillColor = Color.white;
    private bool colorboard = true;

    public GameObject colorBoard;
    public GameObject colorBar;
    public GameObject sizeBar;

void Start()
    {
        PencilButton = GameObject.Find("Pencil").GetComponent<Button>();
        EraserButton = GameObject.Find("Eraser").GetComponent<Button>();
        FillButton = GameObject.Find("Fill").GetComponent<Button>();
        CircleButton = GameObject.Find("Circle").GetComponent<Button>();
        SquareButton = GameObject.Find("Square").GetComponent<Button>();
        //LineButton = GameObject.Find("Line Tool").GetComponent<Button>();
        ColorButton = GameObject.Find("Color").GetComponent <Button>();

        PencilButton.onClick.AddListener(EnableDrawing);
        EraserButton.onClick.AddListener(EnableErasing);
        FillButton.onClick.AddListener(EnableFill);
        CircleButton.onClick.AddListener(EnableCircle);
        SquareButton.onClick.AddListener(EnableSquare);
        //LineButton.onClick.AddListener(EnableLine);
        ColorButton.onClick.AddListener(BoardAndBarControl);

        draw.enabled = false;
        eraser.enabled = false;
        circleTool.enabled = false;
        squareTool.enabled = false;
        fillscreen.enabled = false;

        colorBar.SetActive(false);
        sizeBar.SetActive(false);
    }
    public void EnableDrawing()
    {
        draw.enabled = true;
        eraser.enabled = false;
        circleTool.enabled = false;
        squareTool.enabled = false;
        fillscreen.enabled = false;
        sizeBar.SetActive(true);
        colorBoard.SetActive(false);
        colorboard = false;
        colorBar.SetActive(false);
    }

    public void EnableErasing()
    {
        draw.enabled = false;
        eraser.enabled = true;
        circleTool.enabled = false;
        squareTool.enabled = false;
        fillscreen.enabled = false;
    }
    public void EnableFill()
    {
        draw.enabled = false;
        eraser.enabled = false;
        fillscreen.enabled = true;
        circleTool.enabled = false;
        squareTool.enabled = false;
    }

    public void EnableCircle()
    {
        draw.enabled = false;
        eraser.enabled = false;
        circleTool.enabled = true;
        squareTool.enabled = false;
        fillscreen.enabled = false;
    }

    public void EnableSquare()
    {
        draw.enabled = true;
        eraser.enabled = false;
        circleTool.enabled = false;
        squareTool.enabled = true;
        fillscreen.enabled = false;
    }

   /*public void EnableLine()
    {

    }*/

    public void BoardAndBarControl()
    {
        if (colorboard == true)
        {
            colorBoard.SetActive(false);
            colorBar.SetActive(true);
            sizeBar.SetActive(false);
            colorboard = false;
            draw.lineMaterial = drawControl.CustomColor;

        }
        else if(colorboard == false)
        {
            colorBoard.SetActive(true);
            colorBar.SetActive(false);
            sizeBar.SetActive(false);
            colorboard = true;
        }
    }
}