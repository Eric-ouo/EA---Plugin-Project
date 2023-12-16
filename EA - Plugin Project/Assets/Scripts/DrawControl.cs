using UnityEngine;
using UnityEngine.UI;

public class DrawControl : MonoBehaviour
{
    public Draw draw;
    public CircleTool circleTool;
    private Button white;
    private Button black;
    private Button sliver;
    private Button gray;
    private Button red;
    private Button marnoon;
    private Button fuchsia;
    private Button purple;
    private Button blue;
    private Button navy;
    private Button cyan;
    private Button teal;
    private Button green;
    private Button lime;
    private Button yellow;
    private Button oilve;

    public Material White;
    public Material Black;
    public Material Sliver;
    public Material Gray;
    public Material Red;
    public Material Marnoon;
    public Material Fuchsia;
    public Material Purple;
    public Material Blue;
    public Material Navy;
    public Material Cyan;
    public Material Teal;
    public Material Green;
    public Material Lime;
    public Material Yellow;
    public Material Oilve;
    public Material CustomColor;

    public Slider R;
    public Slider G;
    public Slider B;
    public Slider S;
    public Slider Radius;

    public float size;
    public float radius;


    public void Start()
    {
        white = GameObject.Find("white").GetComponent<Button>();
        white.onClick.AddListener(() => TaskOnClick("white"));

        black = GameObject.Find("black").GetComponent<Button>();
        black.onClick.AddListener(() => TaskOnClick("black"));

        sliver = GameObject.Find("sliver").GetComponent<Button>();
        sliver.onClick.AddListener(() => TaskOnClick("sliver"));

        gray = GameObject.Find("gray").GetComponent<Button>();
        gray.onClick.AddListener(() => TaskOnClick("gray"));

        red = GameObject.Find("red").GetComponent<Button>();
        red.onClick.AddListener(() => TaskOnClick("red"));

        marnoon = GameObject.Find("marnoon").GetComponent<Button>();
        marnoon.onClick.AddListener(() => TaskOnClick("marnoon"));

        fuchsia = GameObject.Find("fuchsia").GetComponent<Button>();
        fuchsia.onClick.AddListener(() => TaskOnClick("fuchsia"));

        purple = GameObject.Find("purple").GetComponent<Button>();
        purple.onClick.AddListener(() => TaskOnClick("purple"));

        blue = GameObject.Find("blue").GetComponent<Button>();
        blue.onClick.AddListener(() => TaskOnClick("blue"));

        navy = GameObject.Find("navy").GetComponent<Button>();
        navy.onClick.AddListener(() => TaskOnClick("navy"));

        cyan = GameObject.Find("cyan").GetComponent<Button>();
        cyan.onClick.AddListener(() => TaskOnClick("cyan"));

        teal = GameObject.Find("teal").GetComponent<Button>();
        teal.onClick.AddListener(() => TaskOnClick("teal"));

        green = GameObject.Find("green").GetComponent<Button>();
        green.onClick.AddListener(() => TaskOnClick("green"));

        lime = GameObject.Find("lime").GetComponent<Button>();
        lime.onClick.AddListener(() => TaskOnClick("lime"));

        yellow = GameObject.Find("yellow").GetComponent<Button>();
        yellow.onClick.AddListener(() => TaskOnClick("yellow"));

        oilve = GameObject.Find("oilve").GetComponent<Button>();
        oilve.onClick.AddListener(() => TaskOnClick("oilve"));

        R.onValueChanged.AddListener(changeR);
        G.onValueChanged.AddListener(changeG);
        B.onValueChanged.AddListener(changeB);
        S.onValueChanged.AddListener(changeS);
        Radius.onValueChanged.AddListener(changeRadius);
        CustomColor.color = Color.black;
    }

    public void TaskOnClick(string ButtonName)
    {
        switch (ButtonName)
        {
            case "white":
                draw.lineMaterial = White;
                break;
            case "black":
              draw.lineMaterial = Black;
                break;
            case "sliver":
                draw.lineMaterial = Sliver;
                break;
            case "gray":
                draw.lineMaterial = Gray;
                break;
            case "red":
                draw.lineMaterial = Red;
                break;
            case "marnoon":
                draw.lineMaterial = Marnoon;
                break;
            case "fuchsia":
                draw.lineMaterial = Fuchsia;
                break;
            case "purple":
                draw.lineMaterial = Purple;
                break;
            case "blue":
                draw.lineMaterial = Blue;
                break;
            case "navy":
                draw.lineMaterial = Navy;
                break;
            case "cyan":
                draw.lineMaterial = Cyan;
                break;
            case "teal":
                draw.lineMaterial = Teal;
                break;
            case "green":
                draw.lineMaterial = Green;
                break;
            case "lime":
                draw.lineMaterial = Lime;
                break;
            case "yellow":
                draw.lineMaterial = Yellow;
                break;
            case "oilve":
                draw.lineMaterial = Oilve;
                break;
            default:
                break;
        }
    }
    private void changeR(float value)
    {
        Color customcolor = CustomColor.color;
        customcolor.r = value;
        CustomColor.color = customcolor;
    }
    private void changeG(float value)
    {
        Color customcolor = CustomColor.color;
        customcolor.g = value;
        CustomColor.color = customcolor;
    }
    private void changeB(float value)
    {
        Color customcolor = CustomColor.color;
        customcolor.b = value;
        CustomColor.color = customcolor;
    }
    private void changeS(float value)
    {
        size = draw.lineWidth;
        size = value;
        draw.lineWidth = size;
    }
    private void changeRadius(float value)
    {
        float minRadius = 1f; // Minimum radius value
        float maxRadius = 5f; // Maximum radius value

        radius = Mathf.Lerp(minRadius, maxRadius, value);
        circleTool.radius = radius;
    }
}
