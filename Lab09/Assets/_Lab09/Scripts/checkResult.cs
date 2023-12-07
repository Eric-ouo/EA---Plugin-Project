using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckResult : MonoBehaviour
{
    public static int score = 0;
    public static string leftFruit, rightFruit;

    void Start()
    {
        ResetFruits();
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collidedObjectName = collision.gameObject.name;
        Debug.Log(collidedObjectName);

        AssignFruitToPlatform(collidedObjectName);

        if (AreFruitsMatched())
        {
            ProcessMatchedFruits(collidedObjectName);
        }
    }

    private void AssignFruitToPlatform(string fruitName)
    {
        if (gameObject.name == "Platform01" && leftFruit == null)
        {
            leftFruit = fruitName;
        }

        if (gameObject.name == "Platform02" && rightFruit == null)
        {
            rightFruit = fruitName;
        }
    }

    private bool AreFruitsMatched()
    {
        return leftFruit == rightFruit;
    }

    private void ProcessMatchedFruits(string fruitName)
    {
        Debug.Log($"{leftFruit} {rightFruit}");
        score++;

        DestroyAllFruitsWithTag(fruitName);

        ResetFruits();
    }

    private void DestroyAllFruitsWithTag(string tagName)
    {
        foreach (GameObject fruit in GameObject.FindGameObjectsWithTag(tagName))
        {
            Destroy(fruit);
        }
    }

    private void ResetFruits()
    {
        leftFruit = rightFruit = null;
    }
}