using UnityEngine;

public class NoDrawArea : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public bool IsInsideNoDrawArea(Vector3 position)
    {
        if (boxCollider != null)
        {
            return boxCollider.bounds.Contains(position);
        }

        return false;
    }
}