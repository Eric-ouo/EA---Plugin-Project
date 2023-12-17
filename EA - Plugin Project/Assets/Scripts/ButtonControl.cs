using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Draw draw;
    public Eraser eraser;
    public DrawControl drawControl;
    public CircleTool circleTool;
    public SquareTool squareTool;
    public LineTool lineTool;
    public FillScreen fillscreen;
    public GameObject colorBoard;
    public GameObject colorBar;
    public GameObject sizeBar;
    public GameObject radiusBar;

    [SerializeField] private Button PencilButton;
    [SerializeField] private Button EraserButton;
    [SerializeField] private Button FillButton;
    [SerializeField] private Button CircleButton;
    [SerializeField] private Button SquareButton;
    [SerializeField] private Button ColorButton;
    [SerializeField] private Button LineButton;

    private bool colorboard = true;

    void Start()
    {
        PencilButton.onClick.AddListener(EnableDrawing);
        EraserButton.onClick.AddListener(EnableErasing);
        FillButton.onClick.AddListener(EnableFill);
        CircleButton.onClick.AddListener(EnableCircle);
        SquareButton.onClick.AddListener(EnableSquare);
        ColorButton.onClick.AddListener(BoardAndBarControl);
        LineButton.onClick.AddListener(Enableline);

        draw.enabled = false;
        eraser.enabled = false;
        circleTool.enabled = false;
        squareTool.enabled = false;
        fillscreen.enabled = false;
        lineTool.enabled = false;

        colorBar.SetActive(false);
        sizeBar.SetActive(false);
        radiusBar.SetActive(false);
    }
    public void EnableDrawing()
    {
        draw.enabled = true;
        eraser.enabled = false;
        circleTool.enabled = false;
        squareTool.enabled = false;
        fillscreen.enabled = false;
        lineTool.enabled = false;
        sizeBar.SetActive(true);
        colorBoard.SetActive(false);
        colorboard = false;
        colorBar.SetActive(false);
        radiusBar.SetActive(false);
    }

    public void EnableErasing()
    {
        draw.enabled = false;
        eraser.enabled = true;
        circleTool.enabled = false;
        squareTool.enabled = false;
        fillscreen.enabled = false;
        lineTool.enabled = false;
    }
    public void EnableFill()
    {
        draw.enabled = false;
        eraser.enabled = false;
        fillscreen.enabled = true;
        circleTool.enabled = false;
        squareTool.enabled = false;
        lineTool.enabled = false;
    }

    public void EnableCircle()
    {
        draw.enabled = false;
        eraser.enabled = false;
        circleTool.enabled = true;
        squareTool.enabled = false;
        fillscreen.enabled = false;
        lineTool.enabled = false;
        radiusBar.SetActive(true);
        colorBoard.SetActive(false);
        colorBar.SetActive(false);
        sizeBar.SetActive(false);
    }

    public void EnableSquare()
    {
        draw.enabled = true;
        eraser.enabled = false;
        circleTool.enabled = false;
        squareTool.enabled = true;
        fillscreen.enabled = false;
        lineTool.enabled = false;
    }

   public void Enableline()
    {
        draw.enabled = false;
        eraser.enabled = false;
        circleTool.enabled = false;
        squareTool.enabled = false;
        fillscreen.enabled = false;
        lineTool.enabled = true;
        radiusBar.SetActive(false);
        colorBoard.SetActive(false);
        colorBar.SetActive(false);
        sizeBar.SetActive(true);
    }

    public void BoardAndBarControl()
    {
        if (colorboard == true)
        {
            colorBoard.SetActive(false);
            colorBar.SetActive(true);
            sizeBar.SetActive(false);
            radiusBar.SetActive(false);
            colorboard = false;
            draw.lineMaterial = drawControl.CustomColor;

        }
        else if(colorboard == false)
        {
            colorBoard.SetActive(true);
            colorBar.SetActive(false);
            sizeBar.SetActive(false);
            radiusBar.SetActive(false);
            colorboard = true;
        }
    }
}