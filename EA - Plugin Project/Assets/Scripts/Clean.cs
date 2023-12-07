using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clean : MonoBehaviour
{
    public string linetag = "line";
    public Button clean;

    void Start()
    {
        clean = GameObject.Find("Clean").GetComponent<Button>();
        clean.onClick.AddListener(DestroyObjects);
    }
    public void DestroyObjects()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(linetag);

        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
}
